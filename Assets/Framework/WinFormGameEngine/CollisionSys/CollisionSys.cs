using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 处理碰撞逻辑
    /// </summary>
    public class CollisionSys : SingletonBaseSys<CollisionSys>
    {
        private List<ICollider> m_colliderList = new();
        private List<ICollider> m_nextFrameToAdd = new();
        private List<ICollider> m_nextFrameToRemove = new();

        public CollisionSys()
        {
            // 监听GameSys
            GameSys.Instance.OnEnter += () =>
            {
                // 创建CollisionUpdater游戏对象
                GameObject obj = new GameObject("CollisionUpdater");
                obj.AddComponent<CollisionUpdater>();
            };

            GameSys.Instance.OnExit += () =>
            {
                m_colliderList.Clear();
                m_nextFrameToAdd.Clear();
                m_nextFrameToRemove.Clear();
            };

        }


        /// <summary>
        /// 添加一个Collider
        /// </summary>
        /// <param name="collider"></param>
        public void AddCollider(ICollider collider)
        {
            m_nextFrameToAdd.Add(collider);
        }

        /// <summary>
        /// 移除一个Collider
        /// </summary>
        /// <param name="collider"></param>
        public void RemoveCollider(ICollider collider)
        {
            // 并不是立即移除，而是移动到待移除队列，避免Update中的迭代器出错
            m_nextFrameToRemove.Add(collider);
        }


        internal void Update()
        {
            // 遍历添加队列
            foreach (ICollider each in m_nextFrameToAdd)
            {
                m_colliderList.Add(each);
            }
            m_nextFrameToAdd.Clear();

            // 遍历移除队列
            foreach (ICollider each in m_nextFrameToRemove)
            {
                m_colliderList.Remove(each);
            }
            m_nextFrameToRemove.Clear();

            // 遍历colliderList，调用UpdateCollision函数并传入colliderList
            foreach (ICollider each in m_colliderList)
            {
                each.UpdateCollision(m_colliderList);
            }
        }
    }
}
