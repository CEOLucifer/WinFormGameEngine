using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TurretRotatePlayerController : BaseComponent
{
    private Turret m_turret;
    private MouseEventHandler m_onLeftBtnMouseDown;
    private MouseEventHandler m_onLeftBtnMouseUp;
    private MouseEventHandler m_onRightBtnMouseDown;
    private MouseEventHandler m_onRightBtnMouseUp;

    public Turret Turret { get => m_turret; set => m_turret = value; }

    public override void Awake()
    {
        m_onLeftBtnMouseDown += (_, _) =>
        {
            m_turret.TurretRotate.Enter();
            m_turret.TurretRotate.LorR = E_LorR.Left;
        };

        m_onLeftBtnMouseUp += (_, _) =>
        {
            m_turret.TurretRotate.Exit();
        };

        m_onRightBtnMouseDown += (_, _) =>
        {
            m_turret.TurretRotate.Enter();
            m_turret.TurretRotate.LorR = E_LorR.Right;
        };

        m_onRightBtnMouseUp += (_, _) =>
        {
            m_turret.TurretRotate.Exit();
        };

        // 订阅UI事件
        BattleUIPanel battleUiPanel = UISys.Instance.GetPanel<BattleUIPanel>();
        battleUiPanel.C_turretBtnsPanel.Control.leftBtn.MouseDown += m_onLeftBtnMouseDown;
        battleUiPanel.C_turretBtnsPanel.Control.leftBtn.MouseUp += m_onLeftBtnMouseUp;
        battleUiPanel.C_turretBtnsPanel.Control.rightBtn.MouseDown += m_onRightBtnMouseDown;
        battleUiPanel.C_turretBtnsPanel.Control.rightBtn.MouseUp += m_onRightBtnMouseUp;
    }

    public override void OnDestroy()
    {
        BattleUIPanel battleUiPanel = UISys.Instance.GetPanel<BattleUIPanel>();
        battleUiPanel.C_turretBtnsPanel.Control.leftBtn.MouseDown -= m_onLeftBtnMouseDown;
        battleUiPanel.C_turretBtnsPanel.Control.leftBtn.MouseUp -= m_onLeftBtnMouseUp;
        battleUiPanel.C_turretBtnsPanel.Control.rightBtn.MouseDown -= m_onRightBtnMouseDown;
        battleUiPanel.C_turretBtnsPanel.Control.rightBtn.MouseUp -= m_onRightBtnMouseUp;
    }
}
