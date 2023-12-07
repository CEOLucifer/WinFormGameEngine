using Com.WWZ.WinFormGameEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Test
{
    public IEnumerator GetEnumerator()
    {
        Console.WriteLine("哈哈");
        yield return 1;
        Console.WriteLine("呵呵");
        yield return 2;
        Console.WriteLine("嘿嘿");
        yield return 3;
    }
}
