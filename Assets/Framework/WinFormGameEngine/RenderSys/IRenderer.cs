using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 炮打飞机.Assets.Framework;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 渲染器接口
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// 渲染排行
        /// </summary>
        public int SortingOrder { get; set; }

        /// <summary>
        /// 注册到RenderSys，必须在Awake中调用。
        /// </summary>
        internal void RegisterToRenderSys()
        {
            // 注册到RenderSys
            RenderSys.Instance.RendererList.Add(this);

            // 排序一次
            RenderSys.Instance.Sort();
        }

        /// <summary>
        /// 渲染逻辑。由RenderSys循环调用
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g);
    }
}
