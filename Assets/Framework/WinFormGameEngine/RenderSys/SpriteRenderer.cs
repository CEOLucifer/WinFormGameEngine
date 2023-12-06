using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using 炮打飞机.Assets.Framework;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 精灵渲染器
    /// </summary>
    public sealed class SpriteRenderer : BaseComponent, IRenderer
    {
        private Bitmap m_bitmap;
        private Vector2 m_pivot;
        private int m_sortingOrder;

        /// <summary>
        /// 渲染的图片
        /// </summary>
        public Bitmap Bitmap { get => m_bitmap; set => m_bitmap = value; }

        /// <summary>
        /// 轴心
        /// </summary>
        public Vector2 Pivot { get => m_pivot; set => m_pivot = value; }

        public int SortingOrder
        {
            get => m_sortingOrder;
            set
            {
                m_sortingOrder = value;

                // 修改一次，就要对渲染队列排序一次
                RenderSys.Instance.Sort();
            }
        }

        public void Render(Graphics g)
        {
            // 基于Transform和Pivot
            // 先旋转，后平移


            // 如果没有关联Bitmap，返回
            if (m_bitmap == null)
                return;



            // Pivot矩阵
            Matrix4x4 mPivot = new Matrix4x4
                (
                    1, 0, 0, -(this.Transform.Position.X + this.Pivot.X),
                    0, 1, 0, -(this.Transform.Position.Y + this.Pivot.Y),
                    0, 0, 1, 0,
                    0, 0, 0, 1
                );


            // 旋转矩阵
            Matrix4x4 mRotate = Mathf.CreateRotation(this.Transform.Rotation);

            // 平移矩阵

            // 这个CreateTranslation到底是啥？用了的话计算结果不一样
            //Matrix4x4 mTranslate =
            //    Matrix4x4.CreateTranslation(new Vector3(eachSp.Transform.Position, 0));

            Matrix4x4 mTranslate = Mathf.CreateTranslation(new Vector2(this.Transform.Position.X, this.Transform.Position.Y));

            // 求destinationPoints

            // 矩阵运算

            // 先计算原位置矩阵
            Matrix4x4[] mDests = new Matrix4x4[3]
            {
                    Mathf.CreatePointMatrix(this.Transform.Position),
                    Mathf.CreatePointMatrix(this.Transform.Position + new Vector2(this.Bitmap.Width, 0)),
                    Mathf.CreatePointMatrix(this.Transform.Position + new Vector2(
                        0, this.Bitmap.Height))
            };

            // 最终变换矩阵
            Matrix4x4 resM = mTranslate * mRotate * mPivot;

            // 乘以最终变换矩阵
            for (int i = 0; i < 3; ++i)
            {
                mDests[i] = resM * mDests[i];
            }

            // Point数组。这里用Point数组是因为DrawImage函数只能传Point数组
            Point[] destinationPoints = new Point[3];
            for (int i = 0; i < 3; ++i)
            {
                destinationPoints[i].X = (int)mDests[i].M11;
                destinationPoints[i].Y = (int)mDests[i].M21;
            }

            g.DrawImage(this.Bitmap, destinationPoints);

        }

        public override void OnDestroy()
        {
            // 从渲染队列移除
            RenderSys.Instance.RendererList.Remove(this);
        }

        public override void Awake()
        {
            (this as IRenderer).RegisterToRenderSys();
        }
    }
}
