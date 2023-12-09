namespace Com.WWZ.WinFormGameEngine;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 公共组件
/// </summary>
internal class PublicComponent : BaseComponent
{
    public event Action OnUpdate;

    public override void Update()
    {
        OnUpdate?.Invoke();
    }
}
