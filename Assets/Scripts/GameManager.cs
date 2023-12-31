﻿using Com.WWZ.WinFormGameEngine;
using System.Numerics;

/// <summary>
/// 游戏管理器
/// </summary>
public class GameManager : BaseSingleton<GameManager>
{
    /// <summary>
    /// 当所有飞机杯销毁时触发
    /// </summary>
    public event Action OnAllPlaneDestroyed;

    private HashSet<Plane> m_planeSet = new HashSet<Plane>();
    private Turret m_turret;
    private Missile m_missile;
    private Alice m_alice;

    public HashSet<Plane> PlaneSet { get => m_planeSet; set => m_planeSet = value; }
    public Turret Turret { get => m_turret; set => m_turret = value; }
    public Missile Missile { get => m_missile; set => m_missile = value; }

    public void EnterBattle()
    {
        // 敌机生成器
        GameObject obj = new GameObject("PlaneGenerater");
        obj.AddComponent<PlaneGenerater>();

        // 爱丽丝
        GameObject aliceObj = new GameObject("Alice");
        m_alice = aliceObj.AddComponent<Alice>();
    }

    /// <summary>
    /// 进入初始界面
    /// </summary>
    public void EnterInit()
    {
        // 清除所有飞机
        foreach (Plane each in m_planeSet)
        {
            each.GameObject.Destroy();
        }
        m_planeSet.Clear();

        // 清除炮塔
        if (m_turret != null)
        {
            if (!m_turret.GameObject.IsDestroyed)
                m_turret.GameObject.Destroy();
            m_turret = null;

            // 清除导弹
            if (m_missile != null && !m_missile.GameObject.IsDestroyed)
                m_missile.GameObject.Destroy();
        }

        // 清除爱丽丝
        if (m_alice != null)
        {
            m_alice.GameObject.Destroy();
        }

        // 隐藏战斗UI面板
        BattleUIPanelSys.Instance.Hide();

        // 显示初始面板
        InitPanelSys.Instance.Show();
    }

    public void GeneratePlane()
    {
        GameObject obj = new GameObject("Plane");
        Plane plane = obj.AddComponent<Plane>();
        float x = Mathf.RandomRangeFloat(-300.0f, 1920.0f);
        float y = Mathf.RandomRangeFloat(50.0f, 500.0f);
        obj.Transform.Position = new Vector2(x, y);

        // 添加到planeSet
        m_planeSet.Add(plane);
    }


    /// <summary>
    /// 生成炮塔
    /// </summary>
    public void GenerateTurret()
    {
        GameObject turretObj = new GameObject("Turret");
        m_turret = turretObj.AddComponent<Turret>();
    }

    public void DestroyPlane(Plane plane)
    {
        plane.GameObject.Destroy();

        m_planeSet.Remove(plane);

        if (m_planeSet.Count == 0)
        {
            OnAllPlaneDestroyed?.Invoke();
        }
    }
}
