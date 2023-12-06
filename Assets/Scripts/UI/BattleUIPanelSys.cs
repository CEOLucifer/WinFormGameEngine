using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;

/// <summary>
/// 战斗UI面板系统
/// </summary>
public class BattleUIPanelSys : SingletonBaseSys<BattleUIPanelSys>
{
    private Action m_onExitBtnClick;

    public BattleUIPanelSys()
    {
        m_onExitBtnClick += () =>
        {
            // 销毁飞机


            // 销毁炮塔

            // 销毁战斗面板

            GameManager.Instance.EnterInit();


        };
    }

    public void Show()
    {
        BattleUIPanel panel = UISys.Instance.ShowPanel<BattleUIPanel>();

        panel.C_turretBtnsPanel.Control.exitBtn.Click += (_, _) =>
        {
            m_onExitBtnClick?.Invoke();
        };
    }

    public void Hide()
    {
        UISys.Instance.HidePanel<BattleUIPanel>();
    }

    public void ShowReloadBtn()
    {
        BattleUIPanel panel = UISys.Instance.GetPanel<BattleUIPanel>();
        panel.C_turretBtnsPanel.Control.launchBtn.Visible = false;
        panel.C_turretBtnsPanel.Control.reloadBtn.Visible = true;
    }

    public void ShowLaunchBtn()
    {
        BattleUIPanel panel = UISys.Instance.GetPanel<BattleUIPanel>();
        panel.C_turretBtnsPanel.Control.launchBtn.Visible = true;
        panel.C_turretBtnsPanel.Control.reloadBtn.Visible = false;
    }
}
