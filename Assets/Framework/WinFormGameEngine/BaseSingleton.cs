using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 单例类基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseSingleton<T> where T : BaseSingleton<T>, new()
    {
        private static T m_instance;

        public static T Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new();
                return m_instance;
            }
        }
    }
}
