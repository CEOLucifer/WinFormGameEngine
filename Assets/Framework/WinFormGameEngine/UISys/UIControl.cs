namespace Com.WWZ.WinFormGameEngine.UI;

/// <summary>
/// 由游戏引擎托管的控件
/// </summary>
public class UIControl<T> : BaseComponent where T : Control, new()
{
    // 基于WinForm的Control

    private T m_control;

    /// <summary>
    /// 托管的Control对象
    /// </summary>
    public T Control { get => m_control; }

    public override void Awake()
    {
        m_control = new T();

        // 添加到窗口控件列表
        GameSys.Instance.Form.Controls.Add(m_control);
    }

    public override void Update()
    {
        if (m_control == null)
            return;

        m_control.Location = new Point((int)this.Transform.Position.X, (int)this.Transform.Position.Y);
    }

    public override void OnDestroy()
    {
        // 从窗口控件列表中移除
        m_control.Dispose();
        GameSys.Instance.Form.Controls.Remove(m_control);
    }
}
