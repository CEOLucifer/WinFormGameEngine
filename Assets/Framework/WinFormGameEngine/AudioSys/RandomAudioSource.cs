using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 随机音频播放源组件
    /// </summary>
    public class RandomAudioSource : BaseComponent
    {
        // 基于SoundPlayer

        private List<SoundPlayer> m_soundPlayerList = new List<SoundPlayer>();

        /// <summary>
        /// SoundPlayer列表。存储随机播放的几个SoundPlayer
        /// </summary>
        public List<SoundPlayer> SoundPlayerList { get => m_soundPlayerList; }



        /// <summary>
        /// (随机)播放
        /// </summary>
        public void Play()
        {
            if (m_soundPlayerList.Count == 0)
                return;

            int index = Mathf.RandomRangeInt(0, m_soundPlayerList.Count - 1);

            m_soundPlayerList[index].Play();
        }

        /// <summary>
        /// 停止播放。此时可能正在播放多个SoundPlayer，它们会全部停止
        /// </summary>
        public void Stop()
        {
            foreach (SoundPlayer each in m_soundPlayerList)
            {
                each.Stop();
            }
        }

        public override void OnDestroy()
        {
            // 每个SoundPlayer都调用Dispose
            foreach (SoundPlayer each in m_soundPlayerList)
            {
                each.Dispose();
            }
        }
    }
}
