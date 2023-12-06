namespace Com.WWZ.WinFormGameEngine;

using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 炮打飞机.Assets.Framework.WinFormGameEngine.CustomControl;


/// <summary>
/// 对象监视面板
/// </summary>
internal class GameObjectMonitorPanel : BaseComponent, IUIPanel
{
    private UIControl<GameObjectMonitorControl> m_gmc;

    public UIControl<GameObjectMonitorControl> Gmc { get => m_gmc; set => m_gmc = value; }

    public void PanelHide()
    {
        m_gmc.Destroy();
        this.Destroy();
    }

    public void PanelShow()
    {
        GameObject obj = new GameObject(typeof(GameObjectMonitorControl).Name);
        m_gmc = obj.AddComponent<UIControl<GameObjectMonitorControl>>();
    }

    /// <summary>
    /// 添加一个Label对象
    /// </summary>
    /// <param name="content"></param>
    public void AddLabel(string content)
    {
        FlowLayoutPanel panel = m_gmc.Control.flowLayoutPanel;

        Label lab = new Label();
        lab.AutoSize = true;
        lab.Text = content;
        lab.Font = new("微软雅黑", 8);
        lab.BackColor = Color.Green;
        lab.Margin = new(3);


        panel.Controls.Add(lab);
    }

    /// <summary>
    /// 清除所有Label
    /// </summary>
    public void ClearAllLabel()
    {
        FlowLayoutPanel panel = m_gmc.Control.flowLayoutPanel;

        foreach (Control each in panel.Controls)
        {
            each.Dispose();
        }

        panel.Controls.Clear();
    }
}
