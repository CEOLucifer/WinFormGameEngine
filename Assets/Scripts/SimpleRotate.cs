using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SimpleRotate : BaseComponent
{
    private float m_speed = 30.0f;

    public override void Update()
    {
        this.Transform.Rotation += m_speed * Time.DeltaTime;
    }
}
