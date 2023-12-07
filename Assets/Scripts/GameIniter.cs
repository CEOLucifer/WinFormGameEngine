using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections;
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
        //DebuggerSys.Instance.IsShowGameObject = true;
        DebuggerSys.Instance.Enter();
        Time.FPS = 120;

        GameManager.Instance.EnterInit();


        GameObject obj = new GameObject("CoroutineTest");
        CoroutineComp cc = obj.AddComponent<CoroutineComp>();
        cc.StartCoroutine(FooCor());
    }

    private IEnumerator FooCor()
    {
        Console.WriteLine("哈哈");
        yield return new WaitForSeconds(3);
        Console.WriteLine("呵呵");
        yield return new WaitForSeconds(3);
        Console.WriteLine("嘿嘿");
    }
}
