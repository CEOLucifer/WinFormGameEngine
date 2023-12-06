using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 处理装填的逻辑
/// </summary>
public class TurretReload : BaseComponent
{
    private Turret m_turret;

    public Turret Turret { get => m_turret; set => m_turret = value; }

    /// <summary>
    /// 装填
    /// </summary>
    public void Reload()
    {
        //if (m_turret.Missile != null && !m_turret.Missile.IsLaunched)
        //    return;

        // 原来的导弹要销毁
        if (m_turret.Missile != null)
            m_turret.Missile.GameObject.Destroy();

        // 创建一个新的导弹对象
        GameObject missileObj = new("Missile");
        Missile missile = missileObj.AddComponent<Missile>();
        missile.Turret = m_turret;

        // 设置导弹于正确的位置
        missileObj.Transform.Position = m_turret.RotaterObj.Transform.Position;
        missileObj.Transform.Rotation = m_turret.RotaterObj.Transform.Rotation;
        m_turret.Missile = missile;
        missileObj.Transform.Parent = m_turret.RotaterObj.Transform;

        BattleUIPanelSys.Instance.ShowLaunchBtn();
    }
}
