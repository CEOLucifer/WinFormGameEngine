namespace Com.WWZ.WinFormGameEngine.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// UI系统
/// </summary>
public class UISys : BaseSingleton<UISys>
{
    private Dictionary<string, GameObject> m_panelDic = new Dictionary<string, GameObject>();

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T? ShowPanel<T>() where T : BaseComponent, IUIPanel, new()
    {
        string name = typeof(T).Name;
        if (m_panelDic.ContainsKey(name))
            return m_panelDic[name].GetComponent<T>();

        GameObject obj = new GameObject(name);
        T ct = obj.AddComponent<T>();
        m_panelDic.Add(name, obj);
        ct.PanelShow();
        return ct;
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void HidePanel<T>() where T : BaseComponent, IUIPanel
    {
        string name = typeof(T).Name;
        if (!m_panelDic.ContainsKey(name))
            return;

        T? panel = m_panelDic[name].GetComponent<T>();
        panel?.PanelHide();
        m_panelDic.Remove(name);
    }

    /// <summary>
    /// 获取面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public T? GetPanel<T>() where T : BaseComponent, IUIPanel
    {
        string name = typeof(T).Name;
        if (m_panelDic.ContainsKey(name))
            return m_panelDic[name].GetComponent<T>();

        return null;
    }
}
