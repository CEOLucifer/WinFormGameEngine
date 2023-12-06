namespace Com.WWZ.WinFormGameEngine;

using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 调试系统
/// </summary>
public class DebuggerSys : SingletonBaseSys<DebuggerSys>
{
    private bool m_isUpdating;

    public bool IsUpdating { get => m_isUpdating; }

    public void Enter()
    {
        if (m_isUpdating)
            return;

        GameObjectMonitorPanelSys.Instance.Show();
    }

    public void Exit()
    {
        if (!m_isUpdating)
            return;

        GameObjectMonitorPanelSys.Instance.Hide();
    }
}
