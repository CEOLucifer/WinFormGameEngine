namespace Com.WWZ.WinFormGameEngine;


using System;

/// <summary>
/// 公共组件系统
/// </summary>
public class PublicComponentSys : BaseSingleton<PublicComponentSys>
{
    private PublicComponent m_publicComponent;

    public PublicComponentSys()
    {
        GameSys.Instance.OnEnter += () =>
        {
            GameObject obj = new GameObject("PublicComponent");
            obj.DontDestroyOnDestroyAll = true;
            m_publicComponent = obj.AddComponent<PublicComponent>();
        };

        GameSys.Instance.OnExit += () =>
        {
            m_publicComponent.GameObject.Destroy();
        };
    }

    /// <summary>
    /// 添加要帧更新的委托
    /// </summary>
    /// <param name="func"></param>
    public void AddFuncToUpdate(Action func)
    {
        m_publicComponent.OnUpdate += func;
    }

    /// <summary>
    /// 移除要帧更新的委托
    /// </summary>
    /// <param name="func"></param>
    public void RemoveFuncUpdating(Action func)
    {
        m_publicComponent.OnUpdate -= func;
    }
}
