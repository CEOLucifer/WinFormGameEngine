using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace 炮打飞机.Assets.Framework
{
    /// <summary>
    /// 渲染系统。处理游戏窗口所有渲染相关
    /// </summary>
    internal class RenderSys : BaseSingleton<RenderSys>
    {
        private List<IRenderer> m_rendererList = new();

        internal List<IRenderer> RendererList { get => m_rendererList; }

        public RenderSys()
        {
            // 监听GameSys
            GameSys.Instance.OnEnter += () =>
            {
                // 在游戏窗口Paint事件中订阅渲染函数
                GameSys.Instance.Form.Paint += (object? sender, PaintEventArgs e) =>
                {
                    RenderAll(e.Graphics);
                };

                // 创建RenderUpdater游戏对象
                GameObject obj = new GameObject("RendererUpdater");
                obj.DontDestroyOnDestroyAll = true;
                obj.AddComponent<RendererUpdater>();
            };

            GameSys.Instance.OnExit += () =>
            {
                m_rendererList.Clear();
            };
        }

        /// <summary>
        /// 渲染一次全部的渲染组件
        /// </summary>
        private void RenderAll(Graphics g)
        {
            // 遍历每一个IRenderer
            foreach (IRenderer eachSp in m_rendererList)
            {
                eachSp.Render(g);
            }
        }

        internal void Sort()
        {
            m_rendererList.Sort(new RendererComparer());
        }
    }
}
