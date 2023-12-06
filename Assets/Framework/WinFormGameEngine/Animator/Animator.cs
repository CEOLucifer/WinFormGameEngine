using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 动画组件
    /// </summary>
    public sealed class Animator : BaseComponent
    {
        // 基于SpriteRenderer

        private List<Bitmap> m_bitMapList = new();
        private SpriteRenderer m_spriteRenderer;
        private float m_interval = 0.3f;
        private float m_time = 0.0f;
        private int m_curIndex = 0;
        private bool m_isUpdating;

        public List<Bitmap> BitMapList { get => m_bitMapList; }
        public SpriteRenderer SpriteRenderer { get => m_spriteRenderer; set => m_spriteRenderer = value; }

        /// <summary>
        /// 帧间隔时间
        /// </summary>
        public float Interval { get => m_interval; set => m_interval = value; }
        public bool IsUpdating { get => m_isUpdating; }

        public override void Update()
        {
            if (!m_isUpdating)
                return;

            if (m_spriteRenderer == null)
                return;

            // 如果列表为空，则返回
            if (m_bitMapList.Count == 0)
                return;

            m_time += Time.DeltaTime;

            if (m_time >= m_interval)
            {
                m_time = 0.0f;

                m_curIndex = Mathf.ScrollUpInt(m_curIndex, 0, m_bitMapList.Count - 1);
                m_spriteRenderer.Bitmap = m_bitMapList[m_curIndex];
            }
        }

        public void Play()
        {
            if (m_isUpdating)
                return;

            m_isUpdating = true;
        }

        public void Stop()
        {
            if (!m_isUpdating)
                return;

            m_isUpdating = false;
        }
    }
}
