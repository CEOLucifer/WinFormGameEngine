using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    internal class RendererUpdater : BaseComponent
    {
        public override void Update()
        {
            GameSys.Instance.Form.Refresh();
        }
    }
}
