using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 处理炮塔旋转的逻辑
/// </summary>
public class TurretRotate : BaseComponent
{
    private Turret m_turret;
    private bool m_isRotating;
    private E_LorR m_LorR;
    private float m_speed = 30.0f;

    public Turret Turret { get => m_turret; set => m_turret = value; }
    public bool IsRotating { get => m_isRotating; }
    public E_LorR LorR { get => m_LorR; set => m_LorR = value; }
    public float Speed { get => m_speed; set => m_speed = value; }

    public void Enter()
    {
        if (m_isRotating)
            return;

        // 导弹已经发射，返回
        if (m_turret.Missile.IsLaunched)
            return;

        m_isRotating = true;
    }

    public void Exit()
    {
        if (!m_isRotating)
            return;

        m_isRotating = false;
    }

    public override void Start()
    {
    }

    public override void Update()
    {
        if (!m_isRotating)
            return;

        float delta = m_speed * Time.DeltaTime;

        if (m_LorR == E_LorR.Left)
            delta = -delta;

        // 旋转转子
        m_turret.RotaterObj.Transform.Rotation += delta;

        // 钳制于0度到180度之间
        m_turret.RotaterObj.Transform.Rotation = Math.Clamp(m_turret.RotaterObj.Transform.Rotation, -180.0f, 0.0f);
    }
}
