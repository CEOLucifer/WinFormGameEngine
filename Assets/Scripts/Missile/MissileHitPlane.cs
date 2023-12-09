using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 处理导弹命中敌机的逻辑
/// </summary>
public class MissileHitPlane : BaseComponent
{
    private Missile m_missile;

    public Missile Missile { get => m_missile; set => m_missile = value; }

    public override void Start()
    {
        m_missile.ColliderObj.GetComponent<CircleCollider>().OnCollisionEnter += (collision) =>
        {
            //Console.WriteLine("命中敌机");
            CircleCollider cc = collision.AnotherCollider as CircleCollider;
            Plane plane = cc.GetComponent<Plane>();

            // 敌机坠落
            plane.PlaneDrop.Drop();
            plane.Collider.Destroy(); // 销毁碰撞器，避免和导弹再次碰撞

            // 炮塔重新装填
            m_missile.Turret.Reload.Reload();
        };
    }
}
