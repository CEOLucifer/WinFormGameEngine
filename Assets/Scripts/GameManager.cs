using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 炮打飞机;

public class GameManager : SingletonBaseSys<GameManager>
{
    public void EnterBattle()
    {
        // UI
        BattleUIPanelSys.Instance.Show();

        // 敌机生成器
        GameObject obj = new GameObject("PlaneGenerater");
        obj.AddComponent<PlaneGenerater>();

        // 炮塔
        GameObject turretObj = new GameObject("Turret");
        turretObj.AddComponent<Turret>();

    }

    /// <summary>
    /// 显示初始界面
    /// </summary>
    public void ShowInitPanel()
    {
        InitPanelSys.Instance.Show();
    }
}
