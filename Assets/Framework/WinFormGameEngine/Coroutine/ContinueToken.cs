namespace Com.WWZ.WinFormGameEngine;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 协程返回类型：协程继续令牌
/// </summary>
public class ContinueToken
{
    private bool isAllowContinue = false;

    public bool IsAllowContinue { get => isAllowContinue; set => isAllowContinue = value; }
}
