using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 游戏对象空间变换组件
    /// </summary>
    public sealed class Transform : BaseComponent
    {
        private Vector2 m_position;
        private float m_rotation;

        private Transform m_parent;
        private List<Transform> m_childrenList = new();

        /// <summary>
        /// 游戏对象的世界空间下的位置
        /// </summary>
        public Vector2 Position
        {
            get => m_position;
            set
            {
                Vector2 delta = value - m_position;
                m_position = value;

                // 修改子Transform的position
                foreach (Transform each in m_childrenList)
                {
                    // 用Position属性而不是用m_position字段，是为了递归
                    each.Position += delta;
                }
            }
        }

        /// <summary>
        /// 游戏对象的世界空间下的旋转量
        /// </summary>
        public float Rotation
        {
            get => m_rotation;
            set
            {
                float delta = value - m_rotation;
                m_rotation = value;

                // 修改子Transform的Rotation和Postion
                foreach (Transform each in m_childrenList)
                {
                    // Rotation直接加delta即可，关键是position的同步
                    each.Rotation += delta;

                    // 原坐标矩阵
                    Matrix4x4 mOrigin = Mathf.CreatePointMatrix(each.Position);

                    // 归位矩阵
                    Matrix4x4 mReturn = Mathf.CreateTranslation(new Vector2(-this.m_position.X, -this.m_position.Y));

                    // 旋转矩阵
                    Matrix4x4 mRotation = Mathf.CreateRotation(delta);

                    // 平移矩阵
                    Matrix4x4 mTranslation = Mathf.CreateTranslation(new Vector2(this.m_position.X, this.m_position.Y));

                    // 矩阵相乘
                    Matrix4x4 res = mTranslation * mRotation * mReturn * mOrigin;

                    each.Position = new Vector2(res.M11, res.M21);
                }
            }
        }

        /// <summary>
        /// 本地空间x轴相对于世界空间下的方向向量
        /// </summary>
        public Vector2 Right
        {
            get
            {
                return Mathf.RotateVector2(new Vector2(1, 0), m_rotation);
            }
        }

        /// <summary>
        /// 父Transform
        /// </summary>
        public Transform Parent
        {
            get => m_parent;
            set
            {
                // 不能设置为自己
                if (value == this)
                {
                    throw new Exception("Cannot set self Transform parent.");
                }

                // 从原来parent的子transform列表中移除自己
                m_parent?.m_childrenList.Remove(this);

                m_parent = value;

                // 如果新parent为null，则返回
                if (value == null)
                    return;

                // 设置父Transform的子Transform
                value.m_childrenList.Add(this);
            }
        }

        /// <summary>
        /// 子Transform列表
        /// </summary>
        internal List<Transform> ChildrenList { get => m_childrenList; set => m_childrenList = value; }

        public override void OnDestroy()
        {
            // 不允许销毁一个Transform组件
            throw new Exception("You cannot destroy a transform.");
        }
    }
}
