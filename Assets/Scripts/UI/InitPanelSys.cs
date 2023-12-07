using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InitPanelSys : BaseSingleton<InitPanelSys>
{
    public void Show()
    {
        InitPanel panel = UISys.Instance.ShowPanel<InitPanel>();

        // 点击开始按钮，进入游戏
        panel.StartBtn.Control.Click += (_, _) =>
        {
            UISys.Instance.HidePanel<InitPanel>();
            GameManager.Instance.EnterBattle();
        };

        // 点击退出按钮，退出程序
        panel.ExitBtn.Control.Click += (_, _) =>
        {
            Application.Exit();
        };
    }

    public void Hide()
    {
        UISys.Instance.HidePanel<InitPanel>();
    }
}
