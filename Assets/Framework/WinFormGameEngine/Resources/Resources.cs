using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 资源管理模块
    /// </summary>
    public class Resources
    {
        /// <summary>
        /// Bitmap缓存
        /// </summary>
        private static Dictionary<string, Bitmap> m_bitmapDic = new();

        /// <summary>
        /// 异步加载Bitmap时的锁对象
        /// </summary>
        private static object m_lock = new();

        /// <summary>
        /// 同步加载图片资源
        /// </summary>
        public static Bitmap LoadBitmap(string path)
        {
            if (m_bitmapDic.ContainsKey(path))
                return m_bitmapDic[path];

            Bitmap newBitmap = new(path);
            m_bitmapDic.Add(path, newBitmap);

            return newBitmap;
        }

        /// <summary>
        /// 异步加载图片资源
        /// </summary>
        /// <param name="path"></param>
        /// <param name="callback"></param>
        public static void LoadBitmapAsync(string path, Action<Bitmap> callback)
        {
            Task.Run(() =>
            {
                Bitmap newBitmap = null;

                lock (m_lock)
                {
                    if (m_bitmapDic.ContainsKey(path))
                    {
                        callback?.Invoke(m_bitmapDic[path]);
                        return;
                    }

                    newBitmap = new(path);
                    m_bitmapDic.Add(path, newBitmap);
                }

                callback?.Invoke(newBitmap);
            });
        }

        /// <summary>
        /// 同步加载一个SoundPlayer
        /// </summary>
        /// <returns></returns>
        public static SoundPlayer LoadSoundPlayer(string audioPath)
        {
            SoundPlayer sd = new SoundPlayer();
            sd.SoundLocation = audioPath;
            sd.Load();
            return sd;
        }

        /// <summary>
        /// 异步加载一个SoundPlayer
        /// </summary>
        /// <param name="audioPath"></param>
        /// <param name="callback"></param>
        public static void LoadSoundPlayerAsync(string audioPath, Action<SoundPlayer> callback)
        {
            Task.Run(() =>
            {
                SoundPlayer sd = new SoundPlayer();
                sd.SoundLocation = audioPath;
                sd.Load();
                callback?.Invoke(sd);
            });
        }
    }
}
