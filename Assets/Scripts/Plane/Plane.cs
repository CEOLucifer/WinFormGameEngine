using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class Plane : BaseComponent
{
    private SpriteRenderer m_spriteRenderer;
    private PlaneFly m_fly;
    private CircleCollider m_collider;
    private PlaneDrop m_planeDrop;
    private ReachGroudToDie m_reachGroundToDie;

    public PlaneDrop PlaneDrop { get => m_planeDrop; set => m_planeDrop = value; }
    public PlaneFly Fly { get => m_fly; set => m_fly = value; }
    public CircleCollider Collider { get => m_collider; set => m_collider = value; }

    public override void Awake()
    {
        m_spriteRenderer = this.GameObject.AddComponent<SpriteRenderer>();

        // 异步加载图片
        ResSys.LoadAsync<BitmapPackage>("Assets/Resources/Sprites/plane.png", (bitmapPackage) =>
        {
            m_spriteRenderer.Bitmap = bitmapPackage.Bitmap;
            m_spriteRenderer.Pivot = new Vector2(134, 132);
        });

        m_fly = this.GameObject.AddComponent<PlaneFly>();

        m_collider = this.GameObject.AddComponent<CircleCollider>();
        m_collider.Radius = 100.0f;

        m_planeDrop = this.AddComponent<PlaneDrop>();

        m_reachGroundToDie = this.AddComponent<ReachGroudToDie>();
    }
}
