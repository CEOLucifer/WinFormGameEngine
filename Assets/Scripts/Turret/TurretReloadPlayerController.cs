using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TurretReloadPlayerController : BaseComponent
{
    private Turret m_turret;
    private EventHandler m_onReloadBtnClick;

    public Turret Turret { get => m_turret; set => m_turret = value; }

    public override void Awake()
    {
        m_onReloadBtnClick += (_, _) =>
        {
            m_turret.Reload.Reload();
        };

        BattleUIPanel battleUiPanel = UISys.Instance.GetPanel<BattleUIPanel>();
        battleUiPanel.C_turretBtnsPanel.Control.reloadBtn.Click += m_onReloadBtnClick;
    }
}
