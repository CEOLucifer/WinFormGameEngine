using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlaneDrop : BaseComponent
{
    /// <summary>
    /// 坠落
    /// </summary>
    public void Drop()
    {
        AccelerationMove lp = this.AddComponent<AccelerationMove>();
        lp.Dir = new(1, 1);
    }
}
