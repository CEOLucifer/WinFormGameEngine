namespace Com.WWZ.WinFormGameEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 协程返回类型：表示协程中的间隔时间
/// </summary>
public class WaitForSeconds
{
    private float m_interval = 0.0f;
    private float m_timer = 0.0f;

    /// <summary>
    /// 计时器
    /// </summary>
    internal float Timer { get => m_timer; set => m_timer = value; }

    /// <summary>
    /// 间隔时间
    /// </summary>
    internal float Interval => m_interval;

    public WaitForSeconds(float interval)
    {
        m_interval = interval;
    }
}
