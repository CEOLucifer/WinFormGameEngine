using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MissileRotatePlayerController : BaseComponent
{
    private Missile m_missile;
    private MouseEventHandler m_onLeftBtnMouseDown;
    private MouseEventHandler m_onLeftBtnMouseUp;
    private MouseEventHandler m_onRightBtnMouseDown;
    private MouseEventHandler m_onRightBtnMouseUp;

    public Missile Missile { get => m_missile; set => m_missile = value; }

    public override void Start()
    {
        m_onLeftBtnMouseDown += (_, _) =>
        {
            m_missile.MissileRotate.Enter();
            m_missile.MissileRotate.LorR = E_LorR.Left;
        };

        m_onLeftBtnMouseUp += (_, _) =>
        {
            m_missile.MissileRotate.Exit();
        };

        m_onRightBtnMouseDown += (_, _) =>
        {
            m_missile.MissileRotate.Enter();
            m_missile.MissileRotate.LorR = E_LorR.Right;
        };

        m_onRightBtnMouseUp += (_, _) =>
        {
            m_missile.MissileRotate.Exit();
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
