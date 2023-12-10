using System.Drawing.Text;
using System.IO;
using System.Media;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 资源管理模块
    /// </summary>
    public class ResSys
    {
        /// <summary>
        /// 资源缓存
        /// </summary>
        private static Dictionary<string, IResourcePackage> m_resDic = new Dictionary<string, IResourcePackage>();

        /// <summary>
        /// 同步加载资源包装
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Load<T>(string path) where T : class, IResourcePackage, new()
        {
            if (m_resDic.ContainsKey(path))
            {
                return m_resDic[path] as T;
            }

            T t = new T();

            t.Load(path);

            // 加入到缓存
            m_resDic.Add(path, t);

            return t;
        }

        /// <summary>
        /// 异步加载资源包装
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name=""></param>
        public static void LoadAsync<T>(string path, Action<T> callback) where T : class, IResourcePackage, new()
        {
            // 如果有缓存
            if (m_resDic.ContainsKey(path))
            {
                T res = m_resDic[path] as T;

                // 监视
                Monitor(res, () =>
                {
                    callback?.Invoke(res);
                });

                return;
            }

            T t = new T();

            // 加入缓存。此时该资源还未加载完毕
            m_resDic.Add(path, t);

            t.LoadAsync(path);

            Monitor(t, () =>
            {
                callback?.Invoke(t);
            });
        }

        /// <summary>
        /// 监视异步加载资源
        /// </summary>
        /// <param name="resourcePackage"></param>
        /// <param name="callBack"></param>
        private static void Monitor(IResourcePackage resourcePackage, Action callback)
        {
            // 创建一个监视委托
            Action loadCallback = null;
            loadCallback = () =>
            {
                // 加载完毕
                if (resourcePackage.IsLoadCompleted)
                {
                    // 执行回调
                    callback?.Invoke();

                    PublicComponentSys.Instance.RemoveFuncUpdating(loadCallback);
                }
            };

            PublicComponentSys.Instance.AddFuncToUpdate(loadCallback);
        }
    }
}
