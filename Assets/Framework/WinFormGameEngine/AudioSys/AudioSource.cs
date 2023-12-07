using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 音频源组件
    /// </summary>
    public class AudioSource : BaseComponent
    {
        // 基于SoundPlayer

        private SoundPlayer m_soundPlayer;

        /// <summary>
        /// 使用的SoundPlayer
        /// </summary>
        public SoundPlayer SoundPlayer { get => m_soundPlayer; set => m_soundPlayer = value; }

        public void Play()
        {
            m_soundPlayer?.Play();
        }

        public void Stop()
        {
            m_soundPlayer?.Stop();
        }

        public override void OnDestroy()
        {
            m_soundPlayer?.Dispose();
        }
    }
}
