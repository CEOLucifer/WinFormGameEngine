using Com.WWZ.WinFormGameEngine;
using System.Numerics;

/// <summary>
/// 炮塔
/// </summary>
public class Turret : BaseComponent
{
    private GameObject m_baseObj;
    private GameObject m_rotaterObj;
    private Missile m_missile;
    private TurretRotate m_turretRotate;
    private TurretRotatePlayerController m_playerController;
    private TurretLaunchMissile m_launchMissile;
    private LaunchMissileUIListener m_launchMissileUIListener;
    private TurretReload m_reload;
    private TurretReloadPlayerController m_turretReloadPlayerController;
    private RandomAudioSource m_randomAudioSource;
    private LerpMove m_lerpMove;

    public GameObject RotaterObj { get => m_rotaterObj; }
    public TurretRotatePlayerController PlayerController { get => m_playerController; }
    public TurretRotate TurretRotate { get => m_turretRotate; set => m_turretRotate = value; }
    public TurretLaunchMissile LaunchMissile { get => m_launchMissile; set => m_launchMissile = value; }
    public TurretReload Reload { get => m_reload; set => m_reload = value; }
    public Missile Missile { get => m_missile; set => m_missile = value; }
    public RandomAudioSource RandomAudioSource { get => m_randomAudioSource; set => m_randomAudioSource = value; }
    public LerpMove LerpMove { get => m_lerpMove; set => m_lerpMove = value; }

    public override void Awake()
    {
        {
            m_baseObj = new GameObject("Base");
            SpriteRenderer sp = m_baseObj.AddComponent<SpriteRenderer>();
            // 异步加载图片
            Resources.LoadBitmapAsync("Assets/Resources/Sprites/base.png", (bitmap) =>
            {
                sp.Bitmap = bitmap;
            });
            sp.Pivot = new(130, 260);


            m_baseObj.Transform.Parent = this.Transform;
        }

        {
            m_rotaterObj = new GameObject("Rotater");
            SpriteRenderer sp = m_rotaterObj.AddComponent<SpriteRenderer>();
            // 异步加载图片
            Resources.LoadBitmapAsync("Assets/Resources/Sprites/rotater.png", (bitmap) =>
            {
                sp.Bitmap = bitmap;
            });
            sp.Pivot = new(136, 129);
            m_rotaterObj.Transform.Position = this.Transform.Position + new Vector2(0, -128);
            sp.SortingOrder = 1;
            m_rotaterObj.Transform.Parent = this.Transform;
        }

        {
            m_turretRotate = this.GameObject.AddComponent<TurretRotate>();
            m_turretRotate.Turret = this;
        }

        {
            m_playerController = this.GameObject.AddComponent<TurretRotatePlayerController>();
            m_playerController.Turret = this;
        }

        {
            m_launchMissile = this.GameObject.AddComponent<TurretLaunchMissile>();
            m_launchMissile.Turret = this;
        }

        {
            m_launchMissileUIListener = this.GameObject.AddComponent<LaunchMissileUIListener>();
            m_launchMissileUIListener.Turret = this;
        }

        {
            m_reload = this.GameObject.AddComponent<TurretReload>();
            m_reload.Turret = this;
        }

        {
            m_turretReloadPlayerController = this.GameObject.AddComponent<TurretReloadPlayerController>();
            m_turretReloadPlayerController.Turret = this;
        }

        m_reload.Reload();

        // RandomAudioSource
        m_randomAudioSource = this.AddComponent<RandomAudioSource>();
        Resources.LoadSoundPlayerAsync("Assets/Resources/Audio/launch_0.wav", (soundPlayer) =>
        {
            m_randomAudioSource.SoundPlayerList.Add(soundPlayer);
        });
        Resources.LoadSoundPlayerAsync("Assets/Resources/Audio/launch_1.wav", (soundPlayer) =>
        {
            m_randomAudioSource.SoundPlayerList.Add(soundPlayer);
        });
        Resources.LoadSoundPlayerAsync("Assets/Resources/Audio/launch_2.wav", (soundPlayer) =>
        {
            m_randomAudioSource.SoundPlayerList.Add(soundPlayer);
        });
        Resources.LoadSoundPlayerAsync("Assets/Resources/Audio/launch_3.wav", (soundPlayer) =>
        {
            m_randomAudioSource.SoundPlayerList.Add(soundPlayer);
        });


        // LerpMove
        m_lerpMove = this.AddComponent<LerpMove>();
        m_lerpMove.EndPos = new Vector2(GameSys.Instance.Form.Width / 2, GameSys.Instance.Form.Height);

        // 设置初始位置
        this.Transform.Position = new(GameSys.Instance.Form.Width / 2, GameSys.Instance.Form.Height + 400);
    }
}
