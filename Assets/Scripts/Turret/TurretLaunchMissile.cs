using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 处理导弹发射的逻辑
/// </summary>
public class TurretLaunchMissile : BaseComponent
{
    public event Action OnLaunch;

    private Turret m_turret;

    public Turret Turret { get => m_turret; set => m_turret = value; }


    /// <summary>
    /// 发射导弹
    /// </summary>
    public void Launch()
    {
        if (m_turret.Missile.IsLaunched)
            return;

        m_turret.Missile.GameObject.AddComponent<MissileMove>();
        m_turret.Missile.IsLaunched = true;

        // 播放动画
        m_turret.Missile.Animator.Play();

        // 播放音效
        m_turret.RandomAudioSource.Play();

        // 断绝父子关系
        m_turret.Missile.Transform.Parent = null;

        OnLaunch?.Invoke();
    }
}
