using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 导弹向前飞行
/// </summary>
public class MissileMove : BaseComponent
{
    private float m_maxSpeed = 50.0f;
    private float m_acceleration = 20.0f;
    private float m_curSpeed = 0.0f;

    public override void Update()
    {
        m_curSpeed = Math.Clamp(m_curSpeed + m_acceleration * Time.DeltaTime, 0.0f, m_maxSpeed);

        Vector2 delta = this.Transform.Right;
        delta *= m_curSpeed;

        this.Transform.Position += delta;
    }
}