using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class SimpleMove : BaseComponent
{


    public override void Update()
    {
        Vector2 delta = new Vector2(100 * Time.DeltaTime, 0);
        this.Transform.Position += delta;
    }
}
