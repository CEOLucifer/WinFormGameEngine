namespace Com.WWZ.WinFormGameEngine;

using Com.WWZ.WinFormGameEngine.UI;
using System;

internal class GameObjectMonitorPanelSys : SingletonBaseSys<GameObjectMonitorPanelSys>
{
    private Action<GameObject> m_onNewGameObject;
    private Action<GameObject> m_onGameObjectRemoveFromObjList;

    public GameObjectMonitorPanelSys()
    {
        m_onNewGameObject += (_) =>
        {
            Fresh();
        };

        m_onGameObjectRemoveFromObjList += (_) =>
        {
            Fresh();
        };
    }

    public void Show()
    {
        UISys.Instance.ShowPanel<GameObjectMonitorPanel>();

        GameObject.OnNewGameObject += m_onNewGameObject;
        GameSys.OnGameObjectRemoveFromObjList += m_onGameObjectRemoveFromObjList;
    }

    public void Hide()
    {
        GameObject.OnNewGameObject -= m_onNewGameObject;
        GameSys.OnGameObjectRemoveFromObjList -= m_onGameObjectRemoveFromObjList;

        UISys.Instance.HidePanel<GameObjectMonitorPanel>();
    }

    private void Fresh()
    {
        // 删除原来所有控件
        GameObjectMonitorPanel panel = UISys.Instance.GetPanel<GameObjectMonitorPanel>();
        panel.ClearAllLabel();

        // 遍历游戏对象列表，生成Label
        foreach (GameObject each in GameSys.Instance.ObjList)
        {
            panel.AddLabel(each.Name);
        }

        foreach (GameObject each in GameSys.Instance.NextFrameToAdd)
        {
            panel.AddLabel(each.Name);
        }
    }
}
