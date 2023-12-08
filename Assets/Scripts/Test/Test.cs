using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Test : BaseComponent
{
    public ContinueToken ct1 = new ContinueToken();
    public ContinueToken ct2 = new ContinueToken();
    public ContinueToken ct3 = new ContinueToken();
    private CoroutineComp m_cc;

    public override void Awake()
    {
        m_cc = this.AddComponent<CoroutineComp>();
        m_cc.StartCoroutine(GetEnumerator());
    }

    public IEnumerator GetEnumerator()
    {
        Console.WriteLine("哈哈");
        yield return ct1;
        Console.WriteLine("呵呵");
        yield return ct2;
        Console.WriteLine("嘿嘿");
        yield return ct3;
    }
}
