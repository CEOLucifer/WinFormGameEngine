namespace Com.WWZ.WinFormGameEngine;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 文本渲染组件
/// </summary>
public class ProTextRenderer : BaseComponent, IRenderer
{
    // 基于DrawString

    private int m_sortingOrder = 0;
    private Font m_font = new Font("Arial", 20);
    private string m_text = string.Empty;

    public int SortingOrder { get => m_sortingOrder; set => m_sortingOrder = value; }
    public Font Font { get => m_font; set => m_font = value; }
    public string Text { get => m_text; set => m_text = value; }

    public void Render(Graphics g)
    {
        PointF pos = new(this.Transform.Position.X, this.Transform.Position.Y);
        g.DrawString(m_text, m_font, RenderConst.SolidBrush, pos);

    }

    public override void Awake()
    {
        (this as IRenderer).RegisterToRenderSys();
    }
}
