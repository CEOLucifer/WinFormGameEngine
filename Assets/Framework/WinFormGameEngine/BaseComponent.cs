using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 游戏对象组件基类。请不要new任何一个它的基类对象！
    /// </summary>
    public abstract class BaseComponent
    {
        private GameObject m_gameObject;
        private bool m_isStarted;
        private bool m_isDestroyed;

        /// <summary>
        /// 所依附的GameObject
        /// </summary>
        public GameObject GameObject
        {
            get => m_gameObject;

            // 由于只能在AddComponent时设置所依附的GameObject，故用internal修饰set访问器
            internal set => m_gameObject = value;
        }

        public Transform Transform => m_gameObject.Transform;

        /// <summary>
        /// 是否调用过Start函数
        /// </summary>
        public bool IsStarted { get => m_isStarted; internal set => m_isStarted = value; }

        /// <summary>
        /// 是否被销毁
        /// </summary>
        public bool IsDestroyed { get => m_isDestroyed; }


        #region 生命周期函数
        /// <summary>
        /// 当AddComponent时候调用此函数
        /// </summary>
        public virtual void Awake() { }

        /// <summary>
        /// 此函数在第一次Update函数即将被调用之前，立即被调用。
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        /// 帧更新函数
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// 此函数在该对象调用Destroy函数时，立即被调用
        /// </summary>
        public virtual void OnDestroy() { }
        #endregion

        public T GetComponent<T>() where T : BaseComponent
        {
            return m_gameObject.GetComponent<T>();
        }

        public T AddComponent<T>() where T : BaseComponent, new()
        {
            return this.GameObject.AddComponent<T>();
        }

        /// <summary>
        /// 销毁该组件
        /// </summary>
        public void Destroy()
        {
            if (m_isDestroyed)
            {
                throw new Exception("Component has been destroyed but still attempt to destroy it.");
            }

            // 标记删除
            m_isDestroyed = true;

            // 添加到所依附的GameObject对象的下一帧销毁组件列表
            m_gameObject.NextFrameToRemove.Add(this);

            // 调用OnDestroy函数
            OnDestroy();
        }
    }
}
