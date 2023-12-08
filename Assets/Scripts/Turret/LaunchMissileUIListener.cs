using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 监听UI事件，发射导弹
/// </summary>
public class LaunchMissileUIListener : BaseComponent
{
    private Turret m_turret;
    private EventHandler m_onLaunchBtnClick;

    public Turret Turret { get => m_turret; set => m_turret = value; }

    public override void Awake()
    {
        m_onLaunchBtnClick += (_, _) =>
        {
            m_turret.LaunchMissile.Launch();

            BattleUIPanelSys.Instance.ShowReloadBtn();
        };

        BattleUIPanel battleUiPanel = UISys.Instance.GetPanel<BattleUIPanel>();
        battleUiPanel.C_battleUIControl.Control.launchBtn.Click += m_onLaunchBtnClick;
    }
}

