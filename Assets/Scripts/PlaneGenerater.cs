using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 处理敌机生成的逻辑
/// </summary>
public class PlaneGenerater : BaseComponent
{
    /// <summary>
    /// 生成的数量
    /// </summary>
    private int m_amount = 5;



    public override void Awake()
    {
        for (int i = 0; i < m_amount; ++i)
        {
            GameManager.Instance.GeneratePlane();
        }
    }
}
