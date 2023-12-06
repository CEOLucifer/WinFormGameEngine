using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 炮打飞机;

/// <summary>
/// 游戏初始化组件
/// </summary>
public class GameIniter : BaseComponent
{
    public override void Awake()
    {
        DebuggerSys.Instance.IsShowCurFps = true;
        DebuggerSys.Instance.Enter();
        Time.FPS = 120;
        GameManager.Instance.EnterInit();
    }
}
