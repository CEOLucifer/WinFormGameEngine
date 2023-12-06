using System.Numerics;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 圆形碰撞器组件
    /// </summary>
    public sealed class CircleCollider : BaseComponent, ICollider
    {
        /// <summary>
        /// 碰撞进入事件
        /// </summary>
        public event Action<Collision> OnCollisionEnter;

        private float m_radius = 10;

        /// <summary>
        /// 半径
        /// </summary>
        public float Radius { get => m_radius; set => m_radius = value; }


        public CircleCollider()
        {
            // 注册到碰撞器列表
            CollisionSys.Instance.AddCollider(this);
        }

        public void UpdateCollision(List<ICollider> colliders)
        {
            // 遍历一遍colliders，判断是否碰撞
            foreach (ICollider each in colliders)
            {
                // 在OnCollisionEnter事件中，本碰撞器可能被销毁了，这时候要终止循环
                if (this.IsDestroyed)
                    break;

                // 如果是自己则跳过
                if (each == this)
                    continue;


                // 圆形碰撞器的碰撞检测
                if (each is CircleCollider)
                {
                    CircleCollider anotherCircle = each as CircleCollider;

                    // 根据数学知识进行重叠检测
                    // 两点之间距离小于半径之和则重叠
                    bool isCollided = false;

                    if (Vector2.Distance(this.Transform.Position, anotherCircle.Transform.Position) <= m_radius + anotherCircle.Radius)
                    {
                        isCollided = true;
                    }

                    // 若碰撞，发布碰撞事件
                    if (isCollided)
                    {
                        Collision collison = new Collision();
                        collison.AnotherCollider = each;
                        OnCollisionEnter?.Invoke(collison);
                    }
                }
            }
        }

        public override void OnDestroy()
        {
            // 从碰撞器队列中移除
            CollisionSys.Instance.RemoveCollider(this);
        }
    }
}
