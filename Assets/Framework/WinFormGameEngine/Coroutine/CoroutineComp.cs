namespace Com.WWZ.WinFormGameEngine;


using System.Collections;

/// <summary>
/// 协程组件
/// </summary>
public class CoroutineComp : BaseComponent
{
    private IEnumerator m_curEnumerator;
    private bool m_isRuning = false;

    /// <summary>
    /// 是否正在运行某个协程函数
    /// </summary>
    public bool IsRunning => m_isRuning;

    /// <summary>
    /// 开启协程
    /// </summary>
    /// <param name="enumerator"></param>
    public void StartCoroutine(IEnumerator enumerator)
    {
        m_curEnumerator = enumerator;

        m_isRuning = true;

        // 先执行第一步
        m_isRuning = m_curEnumerator.MoveNext();
    }

    /// <summary>
    /// 停止协程
    /// </summary>
    public void Stop()
    {
        m_isRuning = false;
    }

    public override void Update()
    {
        if (m_curEnumerator == null)
            return;

        if (!m_isRuning)
            return;

        object cur = m_curEnumerator.Current;

        if (cur is WaitForSeconds)
        {
            WaitForSeconds wfs = cur as WaitForSeconds;
            wfs.Timer += Time.DeltaTime;
            if (wfs.Timer >= wfs.Interval)
            {
                MoveNext();
            }
        }
        else if (cur is ContinueToken)
        {
            ContinueToken continueToken = cur as ContinueToken;
            if (continueToken.IsAllowContinue)
            {
                MoveNext();
            }
        }
        else
        {
            MoveNext();
        }
    }

    /// <summary>
    /// 迭代器迭代
    /// </summary>
    private void MoveNext()
    {
        m_isRuning = m_curEnumerator.MoveNext();
    }
}
