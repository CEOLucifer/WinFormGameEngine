using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    internal class CollisionUpdater : BaseComponent
    {
        public override void Update()
        {
            CollisionSys.Instance.Update();
        }
    }
}
