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
public class DebuggerSys : BaseSingleton<DebuggerSys>
{
    private bool m_isUpdating;
    private bool m_isShowCurFps = false;
    private CurFpsMonitor m_curFpsMonitor;
    private bool m_isShowGameObject = false;

    public bool IsUpdating { get => m_isUpdating; }
    public bool IsShowCurFps { get => m_isShowCurFps; set => m_isShowCurFps = value; }
    public bool IsShowGameObject { get => m_isShowGameObject; set => m_isShowGameObject = value; }

    public void Enter()
    {
        if (m_isUpdating)
            return;


        if (m_isShowCurFps)
        {
            GameObject obj = new GameObject("CurFpsMonitor");
            m_curFpsMonitor = obj.AddComponent<CurFpsMonitor>();
            obj.DontDestroyOnDestroyAll = true;
        }

        if (m_isShowGameObject)
        {
            GameObjectMonitorPanelSys.Instance.Show();
        }
    }

    public void Exit()
    {
        if (!m_isUpdating)
            return;


        if (m_curFpsMonitor != null)
        {
            m_curFpsMonitor.GameObject.Destroy();
            m_curFpsMonitor = null;
        }

        if (m_isShowGameObject)
        {
            GameObjectMonitorPanelSys.Instance.Hide();
        }
    }
}
