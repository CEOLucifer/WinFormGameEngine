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

        private SoundPlayer m_soundPlayer = new();

        /// <summary>
        /// 音频文件路径
        /// </summary>
        public string AudioPath
        {
            get => m_soundPlayer.SoundLocation;
            set
            {
                // 原先的应该停止播放
                m_soundPlayer.Stop();

                m_soundPlayer.SoundLocation = value;
                m_soundPlayer.Load();
            }
        }


        public void Play()
        {
            m_soundPlayer.Play();

        }

        public void Stop()
        {
            m_soundPlayer.Stop();
        }
    }
}
