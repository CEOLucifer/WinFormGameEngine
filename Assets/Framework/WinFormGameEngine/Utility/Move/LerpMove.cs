namespace Com.WWZ.WinFormGameEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 先快后慢插值平移组件
/// </summary>
public class LerpMove : BaseComponent
{
    private Vector2 m_endPos = new Vector2(0, 0);
    private float m_speed = 4.0f;

    public Vector2 EndPos { get => m_endPos; set => m_endPos = value; }
    public float Speed { get => m_speed; set => m_speed = value; }

    public override void Update()
    {
        this.Transform.Position = Vector2.Lerp(this.Transform.Position, m_endPos, m_speed * Time.DeltaTime);
    }
}
