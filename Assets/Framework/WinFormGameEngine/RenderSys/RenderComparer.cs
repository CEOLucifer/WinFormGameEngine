using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 基于SortingOrder的SpriteRenderer的排序器
    /// </summary>
    internal class RendererComparer : Comparer<IRenderer>
    {
        public override int Compare(IRenderer? x, IRenderer? y)
        {
            if (x.SortingOrder < y.SortingOrder)
            {
                return -1;
            }
            else if (x.SortingOrder == y.SortingOrder)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
