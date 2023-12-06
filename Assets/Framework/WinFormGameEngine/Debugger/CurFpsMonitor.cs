namespace Com.WWZ.WinFormGameEngine;

using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Fps监视组件
/// </summary>
internal class CurFpsMonitor : BaseComponent
{
    private ProTextRenderer m_proTextRenderer;

    public override void Awake()
    {
        m_proTextRenderer = this.AddComponent<ProTextRenderer>();
        m_proTextRenderer.SortingOrder = 1000;
    }

    public override void Update()
    {
        m_proTextRenderer.Text = $"Fps:{Time.CurFps}";
    }
}
