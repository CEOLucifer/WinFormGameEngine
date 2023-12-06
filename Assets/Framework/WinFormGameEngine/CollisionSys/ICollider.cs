using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 碰撞器接口
    /// </summary>
    public interface ICollider
    {
        /// <summary>
        /// 碰撞进入事件
        /// </summary>
        public event Action<Collision> OnCollisionEnter;

        /// <summary>
        /// 碰撞器是否被销毁
        /// </summary>
        public bool IsDestroyed { get; }

        /// <summary>
        /// 碰撞判断逻辑。在此函数体内编写碰撞判断逻辑，并发布碰撞进入事件OnCollisionEnter
        /// </summary>
        /// <param name="colliders">处于碰撞系统中的所有碰撞器，包含自己</param>
        public void UpdateCollision(List<ICollider> colliders);

    }
}
