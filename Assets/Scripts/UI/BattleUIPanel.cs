using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 炮打飞机.Assets.Form;

/// <summary>
/// 战斗UI面板
/// </summary>
public class BattleUIPanel : BaseComponent, IUIPanel
{
    private UIControl<BattleUIControl> m_c_turretBtnsPanel;

    public UIControl<BattleUIControl> C_turretBtnsPanel { get => m_c_turretBtnsPanel; set => m_c_turretBtnsPanel = value; }

    public void PanelHide()
    {
        this.GameObject.Destroy();
    }

    public void PanelShow()
    {
        GameObject obj = new GameObject(typeof(BattleUIControl).Name);
        m_c_turretBtnsPanel = obj.AddComponent<UIControl<BattleUIControl>>();

        // 作为子物体
        obj.Transform.Parent = this.Transform;

        BattleUIControl control = m_c_turretBtnsPanel.Control;

        control.Dock = DockStyle.Fill;
    }
}
