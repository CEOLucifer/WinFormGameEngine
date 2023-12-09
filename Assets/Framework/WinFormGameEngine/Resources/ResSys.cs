using System.Drawing.Text;
using System.Media;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 资源管理模块
    /// </summary>
    public class ResSys
    {
        /// <summary>
        /// Bitmap缓存
        /// </summary>
        private static Dictionary<string, Bitmap> m_bitmapDic = new();

        private static PrivateFontCollection m_pfc = new PrivateFontCollection();

        /// <summary>
        /// 字体族缓存
        /// </summary>
        private static Dictionary<string, FontFamily> m_fontFamiltDic = new();

        /// <summary>
        /// 同步加载图片资源
        /// </summary>
        public static Bitmap LoadBitmap(string path)
        {
            if (m_bitmapDic.ContainsKey(path))
                return m_bitmapDic[path];

            Bitmap bitmap = new(path);
            m_bitmapDic.Add(path, bitmap);

            return bitmap;
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
                   Bitmap bitmap = null;

                   lock (m_bitmapDic)
                   {
                       if (!m_bitmapDic.ContainsKey(path))
                       {
                           bitmap = new(path);
                           m_bitmapDic.Add(path, bitmap);
                       }
                       else
                       {
                           bitmap = m_bitmapDic[path];
                       }
                   }

                   callback?.Invoke(bitmap);
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

        /// <summary>
        /// 同步加载字体族
        /// </summary>
        /// <param name="fontPath"></param>
        public static FontFamily LoadFontFamily(string fontPath)
        {
            if (m_fontFamiltDic.ContainsKey(fontPath))
                return m_fontFamiltDic[fontPath];

            // 从外部文件加载字体文件  
            m_pfc.AddFontFile(fontPath);

            // 获取字体族
            FontFamily newFontFamily = m_pfc.Families[m_pfc.Families.Length - 1];

            // 存到缓存
            m_fontFamiltDic.Add(fontPath, newFontFamily);

            return newFontFamily;
        }

        /// <summary>
        /// 异步加载字体族
        /// </summary>
        /// <param name="fontPath"></param>
        /// <param name="callback"></param>
        public static void LoadFontFamilyAsync(string fontPath, Action<FontFamily> callback)
        {
            Task.Run(() =>
            {
                FontFamily fontFamily = null;

                lock (m_fontFamiltDic)
                {
                    if (!m_fontFamiltDic.ContainsKey(fontPath))
                    {
                        // 从外部文件加载字体文件  
                        m_pfc.AddFontFile(fontPath);

                        // 获取字体族
                        fontFamily = m_pfc.Families[m_pfc.Families.Length - 1];

                        // 存到缓存
                        m_fontFamiltDic.Add(fontPath, fontFamily);
                    }
                    else
                    {
                        fontFamily = m_fontFamiltDic[fontPath];
                    }
                }

                callback?.Invoke(fontFamily);
            });

        }
    }
}
