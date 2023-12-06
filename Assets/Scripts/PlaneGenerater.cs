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
    private int m_amount = 10;

    private void GeneratePlane()
    {
        GameObject obj = new GameObject("Plane");
        obj.AddComponent<Plane>();
        float x = Mathf.RandomRangeFloat(-300.0f, 1920.0f);
        float y = Mathf.RandomRangeFloat(50.0f, 500.0f);
        obj.Transform.Position = new Vector2(x, y);
    }

    public override void Awake()
    {
        for (int i = 0; i < m_amount; ++i)
        {
            GeneratePlane();
        }
    }
}
