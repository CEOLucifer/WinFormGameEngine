using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 接触地面销毁逻辑
/// </summary>
public class ReachGroudToDie : BaseComponent
{
    public override void Update()
    {
        if (this.Transform.Position.Y >= GameSys.Instance.Form.Height)
        {
            GameManager.Instance.DestroyPlane(this.GetComponent<Plane>());
        }
    }
}
