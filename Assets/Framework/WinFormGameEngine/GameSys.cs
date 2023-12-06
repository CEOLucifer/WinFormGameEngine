using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 炮打飞机;
using 炮打飞机.Assets.Framework;
using Timer = System.Windows.Forms.Timer;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 游戏系统
    /// </summary>
    public class GameSys : SingletonBaseSys<GameSys>
    {
        // 界面：基于Form
        // 帧更新：基于Timer

        #region 字段
        /// <summary>
        /// 当调用Enter函数时立即调用
        /// </summary>
        public event Action OnEnter;

        /// <summary>
        /// 当调用Exit函数时立即调用
        /// </summary>
        public event Action OnExit;

        /// <summary>
        /// 当一个游戏对象从ObjList移除时触发
        /// </summary>
        internal static event Action<GameObject> OnGameObjectRemoveFromObjList;



        private Form m_form;
        private List<GameObject> m_objList = new();
        private List<GameObject> m_nextFrameToAdd = new();
        private List<GameObject> m_nextFrameToRemove = new();
        private bool m_isUpdating;
        #endregion


        #region 属性
        public bool IsUpdating { get => m_isUpdating; }

        /// <summary>
        /// 游戏窗口
        /// </summary>
        internal Form Form { get => m_form; }

        internal List<GameObject> NextFrameToAdd { get => m_nextFrameToAdd; set => m_nextFrameToAdd = value; }

        internal List<GameObject> NextFrameToRemove { get => m_nextFrameToRemove; set => m_nextFrameToRemove = value; }

        internal List<GameObject> ObjList { get => m_objList; set => m_objList = value; }
        #endregion


        #region 函数
        public GameSys()
        {
            Timer timer = new Timer();
            timer.Tick += UpdateTick;
            Time.Timer = timer;
        }


        /// <summary>
        /// 开启引擎。开启游戏循环
        /// </summary>
        /// <param name="form">依赖的窗口</param>
        public void Enter(Form form)
        {
            if (m_isUpdating)
            {
                throw new AlreadyEnterException();
            }

            m_isUpdating = true;

            m_form = form;

            Time.Timer.Start();
            Time.OldTime = DateTime.Now;

            // 触发一下单例模式类的构造函数
            string str = $"{RenderSys.Instance}{CollisionSys.Instance}";

            OnEnter?.Invoke();
        }

        /// <summary>
        /// 关闭引擎。结束游戏循环
        /// </summary>
        public void Exit()
        {
            if (!m_isUpdating)
            {
                throw new AlreadyExitException();
            }


            m_isUpdating = false;

            // 移除所有东西
            m_form = null;

            // 销毁所有游戏对象
            foreach (GameObject each in m_objList)
            {
                each.Destroy();
            }
            foreach (GameObject each in m_nextFrameToAdd)
            {
                each.Destroy();
            }

            OnExit?.Invoke();
        }


        /// <summary>
        /// 帧更新内容
        /// </summary>
        private void Update()
        {
            // 遍历加入列表
            foreach (GameObject each in m_nextFrameToAdd)
            {
                m_objList.Add(each);
            }
            m_nextFrameToAdd.Clear();

            // 遍历移除列表
            foreach (GameObject each in m_nextFrameToRemove)
            {
                m_objList.Remove(each);
                OnGameObjectRemoveFromObjList?.Invoke(each);
            }
            m_nextFrameToRemove.Clear();


            // 遍历游戏对象以帧更新
            foreach (GameObject eachGameObject in m_objList)
            {
                // 遍历组件
                eachGameObject.UpdateComponent();
            }
        }

        private void UpdateTick(object? sender, EventArgs e)
        {
            Update();

            // 更新DeltaTime
            Time.DeltaTime = (DateTime.Now - Time.OldTime).Milliseconds / 1000.0f * Time.Scale;

            // 记录旧时间
            Time.OldTime = DateTime.Now;
        }

        /// <summary>
        /// 根据名称查找一个GameObject
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal GameObject? Find(string name)
        {
            // 在objList里查找
            foreach (GameObject each in m_objList)
            {
                if (each.Name == name)
                    return each;
            }

            // 在nextFrameToAdd里查找
            foreach (GameObject each in m_nextFrameToAdd)
            {
                if (each.Name == name)
                    return each;
            }

            return null;
        }
        #endregion
    }
}
