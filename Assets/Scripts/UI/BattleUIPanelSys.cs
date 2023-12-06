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
/// 战斗UI面板系统
/// </summary>
public class BattleUIPanelSys : SingletonBaseSys<BattleUIPanelSys>
{
    public void Show()
    {
        BattleUIPanel panel = UISys.Instance.ShowPanel<BattleUIPanel>();
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
