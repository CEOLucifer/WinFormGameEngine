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
    private LerpMove m_lerpMove;

    public UIControl<BattleUIControl> C_turretBtnsPanel { get => m_c_turretBtnsPanel; set => m_c_turretBtnsPanel = value; }
    public LerpMove LerpMove { get => m_lerpMove; set => m_lerpMove = value; }

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

        Form form = GameSys.Instance.Form;
        BattleUIControl control = m_c_turretBtnsPanel.Control;

        // 动画
        m_lerpMove = this.AddComponent<LerpMove>();
        m_lerpMove.EndPos = new Vector2(form.Width - control.Width, form.Height - control.Height);

        // 设置初始位置
        this.Transform.Position = new Vector2(form.Width + 500, form.Height - control.Height);

        control.Dock = DockStyle.Fill;
    }
}
