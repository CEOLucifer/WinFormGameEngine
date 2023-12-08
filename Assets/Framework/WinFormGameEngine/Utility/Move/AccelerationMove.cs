namespace Com.WWZ.WinFormGameEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 加速平移组件
/// </summary>
public class AccelerationMove : BaseComponent
{
    private float m_maxSpeed = 50.0f;
    private float m_acceleration = 20.0f;
    private float m_curSpeed = 0.0f;
    private Vector2 m_dir = new(1.0f, 0.0f);

    public float MaxSpeed { get => m_maxSpeed; set => m_maxSpeed = value; }
    public float Acceleration { get => m_acceleration; set => m_acceleration = value; }
    public float CurSpeed { get => m_curSpeed; set => m_curSpeed = value; }

    /// <summary>
    /// 平移方向
    /// </summary>
    public Vector2 Dir
    {
        get => m_dir;
        set => m_dir = Vector2.Normalize(value);
    }

    public override void Update()
    {
        m_curSpeed = Math.Clamp(m_curSpeed + m_acceleration * Time.DeltaTime, 0.0f, m_maxSpeed);

        Vector2 delta = m_dir;
        delta *= m_curSpeed;

        this.Transform.Position += delta;
    }
}
