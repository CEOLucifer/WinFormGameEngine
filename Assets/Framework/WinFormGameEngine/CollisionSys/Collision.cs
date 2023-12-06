using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 表示一次碰撞的信息
    /// </summary>
    public class Collision
    {
        private ICollider m_anotherCollider;

        /// <summary>
        /// 另一个碰撞器
        /// </summary>
        public ICollider AnotherCollider { get => m_anotherCollider; internal set => m_anotherCollider = value; }
    }
}
