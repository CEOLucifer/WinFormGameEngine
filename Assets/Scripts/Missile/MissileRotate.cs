using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 处理导弹旋转逻辑
/// </summary>
public class MissileRotate : BaseComponent
{
    private Missile m_missile;
    private bool m_isRotating;
    private E_LorR m_LorR;
    private float m_speed = 60.0f;

    public Missile Missile { get => m_missile; set => m_missile = value; }
    public bool IsRotating { get => m_isRotating; }
    public E_LorR LorR { get => m_LorR; set => m_LorR = value; }
    public float Speed { get => m_speed; set => m_speed = value; }

    public void Enter()
    {
        if (m_isRotating)
            return;

        // 没有发射，返回
        if (!m_missile.IsLaunched)
            return;

        m_isRotating = true;
    }

    public void Exit()
    {
        if (!m_isRotating)
            return;

        m_isRotating = false;
    }

    public override void Update()
    {
        if (!m_isRotating)
            return;

        float delta = m_speed * Time.DeltaTime;

        if (m_LorR == E_LorR.Left)
            delta = -delta;

        this.Transform.Rotation += delta;
    }
}
