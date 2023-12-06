using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 游戏时间模块
    /// </summary>
    public class Time
    {
        private static Timer m_timer;
        private static DateTime m_oldTime = DateTime.Now;
        private static float m_deltaTime;
        private static float m_scale = 1.0f;
        private static float m_originDeltaTime;

        internal static Timer Timer
        {
            get => m_timer;
            set
            {
                if (value == null)
                    return;

                m_timer = value;
                FPS = 120.0f;
            }
        }

        /// <summary>
        /// 帧间隔
        /// </summary>
        public static float DeltaTime { get => m_deltaTime; internal set => m_deltaTime = value; }

        internal static DateTime OldTime { get => m_oldTime; set => m_oldTime = value; }

        /// <summary>
        /// 最大帧率
        /// </summary>
        public static float FPS
        {
            get
            {
                if (m_timer == null)
                    return 0.0f;
                return 1000.0f / m_timer.Interval;
            }

            set
            {
                if (m_timer == null)
                    return;
                m_timer.Interval = (int)(1000.0f / value);
            }
        }

        /// <summary>
        /// 时间流动倍率
        /// </summary>
        public static float Scale { get => m_scale; set => m_scale = value; }

        /// <summary>
        /// 当前帧率
        /// </summary>
        public static float CurFps
        {
            get
            {
                return 1.0f / m_originDeltaTime;
            }
        }

        /// <summary>
        /// 不受Scale影响的帧间隔时间
        /// </summary>
        public static float OriginDeltaTime { get => m_originDeltaTime; internal set => m_originDeltaTime = value; }
    }
}
