namespace Com.WWZ.WinFormGameEngine;

using Com.WWZ.WinFormGameEngine.UI;
using System.Collections;

/// <summary>
/// 文本打印效果组件
/// </summary>
public class TextPrinter : BaseComponent
{
    private ProTextRenderer m_protextRenderer;
    private float m_interval = 0.05f;

    private CoroutineComp m_coroutineComp;

    public ProTextRenderer ProTextRenderer { get => m_protextRenderer; set => m_protextRenderer = value; }

    /// <summary>
    /// 打印时间间隔
    /// </summary>
    public float Interval { get => m_interval; set => m_interval = value; }

    /// <summary>
    /// 打印一段内容
    /// </summary>
    /// <param name="content"></param>
    public void PrintContent(string content)
    {
        m_coroutineComp.StartCoroutine(PrintCoroutine(content));
    }

    public void Clear()
    {
        // 停止执行协程函数
        m_coroutineComp.Stop();

        // 文本
        m_protextRenderer.Text = string.Empty;
    }

    /// <summary>
    /// 打印协程函数
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    private IEnumerator PrintCoroutine(string content)
    {
        foreach (char each in content)
        {
            m_protextRenderer.Text += each;
            yield return new WaitForSeconds(m_interval);
        }
    }

    public override void Awake()
    {
        m_coroutineComp = this.AddComponent<CoroutineComp>();
    }

    public override void OnDestroy()
    {
        m_coroutineComp.Destroy();
    }
}