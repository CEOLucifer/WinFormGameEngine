namespace Com.WWZ.WinFormGameEngine;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 资源包装接口。用于实现各种资源的多态
/// </summary>
public interface IResourcePackage
{
    /// <summary>
    /// 资源是否加载完毕
    /// </summary>
    internal bool IsLoadCompleted { get; }


    /// <summary>
    /// 同步加载资源
    /// </summary>
    /// <param name="path"></param>
    internal void Load(string path);

    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <param name="path"></param>
    internal void LoadAsync(string path);
}
