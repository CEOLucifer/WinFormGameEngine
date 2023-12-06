using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 飞机飞行组件
/// </summary>
public class PlaneFly : BaseComponent
{
    private float m_speed = 500.0f;

    public float Speed { get => m_speed; set => m_speed = value; }

    public override void Awake()
    {
        // 随机速度
        m_speed = Mathf.RandomRangeFloat(100.0f, 500.0f);
    }

    public override void Update()
    {
        Vector2 delta = new Vector2(m_speed * Time.DeltaTime, 0);
        this.Transform.Position += delta;

        // 如果x轴坐标大于右边，则设置为-300
        if (this.Transform.Position.X > GameSys.Instance.Form.Width + 300)
        {
            this.Transform.Position = new Vector2(-300.0f, this.Transform.Position.Y);
        }
    }
}
