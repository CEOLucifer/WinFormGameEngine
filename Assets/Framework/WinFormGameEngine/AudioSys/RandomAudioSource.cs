using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 随机音频播放源组件。需关联AudioSource组件
    /// </summary>
    public class RandomAudioSource : BaseComponent
    {
        // 基于AudioSource

        private List<string> m_audioPathList = new();
        private AudioSource m_audioSource;

        /// <summary>
        /// 关联的AudioSource
        /// </summary>
        public AudioSource AudioSource { get => m_audioSource; set => m_audioSource = value; }

        /// <summary>
        /// 随机播放列表
        /// </summary>
        public List<string> AudioPathList { get => m_audioPathList; }

        public void Play()
        {
            //if (m_audioPathList.Count == 0)
            //    return;

            //// 生成audioPathList的随机下标
            //m_audioSource.AudioPath = m_audioPathList[Mathf.RandomRangeInt(0, m_audioPathList.Count - 1)];

            //m_audioSource.Play();
        }

        public void Stop()
        {
            m_audioSource.Stop();
        }
    }
}
