using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 导弹
/// </summary>
public class Missile : BaseComponent
{
    private SpriteRenderer m_sp;
    private MissileRotate m_missileRotate;
    private MissileRotatePlayerController m_missileRotatePlayerController;
    private GameObject m_colliderObj;
    private MissileHitPlane m_missileHitPlane;
    private Turret m_turret;
    private Animator m_animator;

    private bool m_isLaunched;

    public MissileRotate MissileRotate { get => m_missileRotate; set => m_missileRotate = value; }
    public MissileRotatePlayerController MissileRotatePlayerController { get => m_missileRotatePlayerController; set => m_missileRotatePlayerController = value; }

    /// <summary>
    /// 是否已经发射
    /// </summary>
    public bool IsLaunched { get => m_isLaunched; set => m_isLaunched = value; }
    public GameObject ColliderObj { get => m_colliderObj; set => m_colliderObj = value; }
    public Turret Turret { get => m_turret; set => m_turret = value; }
    public SpriteRenderer Sp { get => m_sp; set => m_sp = value; }
    public Animator Animator { get => m_animator; set => m_animator = value; }

    public override void Awake()
    {
        m_sp = this.GameObject.AddComponent<SpriteRenderer>();
        // 异步加载图片
        ResSys.LoadBitmapAsync("Assets/Resources/Sprites/missile.png", (bitmap) =>
        {
            m_sp.Bitmap = bitmap;
        });
        m_sp.Pivot = new(145, 129);
        m_sp.SortingOrder = 2;

        {
            m_missileRotate = this.GameObject.AddComponent<MissileRotate>();
            m_missileRotate.Missile = this;
        }

        {
            m_missileRotatePlayerController = this.GameObject.AddComponent<MissileRotatePlayerController>();
            m_missileRotatePlayerController.Missile = this;

        }

        {
            // 碰撞器
            m_colliderObj = new("MissileCollider");
            CircleCollider cc = m_colliderObj.AddComponent<CircleCollider>();
            cc.Radius = 10.0f;
            m_colliderObj.Transform.Parent = this.Transform;
            m_colliderObj.Transform.Position = this.Transform.Position + this.Transform.Right * 67.0f;

        }

        m_missileHitPlane = this.AddComponent<MissileHitPlane>();
        m_missileHitPlane.Missile = this;

        {
            // 动画组件
            m_animator = this.AddComponent<Animator>();
            m_animator.SpriteRenderer = m_sp;
            m_animator.Interval = 0.05f;
            ResSys.LoadBitmapAsync("Assets/Resources/Sprites/missile_1.png", (bitmap1) =>
            {
                ResSys.LoadBitmapAsync("Assets/Resources/Sprites/missile_2.png", (bitmap2) =>
                {
                    m_animator.BitMapList.Add(bitmap1);
                    m_animator.BitMapList.Add(bitmap2);
                });
            });
        }

        // 记录到GameManager
        GameManager.Instance.Missile = this;
    }
}

