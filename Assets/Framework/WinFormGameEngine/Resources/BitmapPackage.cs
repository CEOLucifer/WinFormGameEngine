namespace Com.WWZ.WinFormGameEngine;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Bitmap包装
/// </summary>
public class BitmapPackage : IResourcePackage
{
    private Bitmap m_bitmap;
    private bool m_isLoadCompleted = false;

    public Bitmap Bitmap { get => m_bitmap; internal set => m_bitmap = value; }

    bool IResourcePackage.IsLoadCompleted => m_isLoadCompleted;

    void IResourcePackage.Load(string path)
    {
        m_bitmap = new(path);
        m_isLoadCompleted = true;
    }

    void IResourcePackage.LoadAsync(string path)
    {
        Task.Run(() =>
           {
               (this as IResourcePackage).Load(path);
           });
    }
}
