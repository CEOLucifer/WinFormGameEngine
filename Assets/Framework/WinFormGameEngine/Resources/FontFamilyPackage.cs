namespace Com.WWZ.WinFormGameEngine;


using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// FontFamily包装
/// </summary>
public class FontFamilyPackage : IResourcePackage
{
    private static PrivateFontCollection s_pfc = new PrivateFontCollection();

    private FontFamily m_fontFamily;
    private bool m_isLoadCompleted = false;


    public FontFamily FontFamily { get => m_fontFamily; internal set => m_fontFamily = value; }

    bool IResourcePackage.IsLoadCompleted => m_isLoadCompleted;

    void IResourcePackage.Load(string path)
    {
        // 从外部文件加载字体文件  
        s_pfc.AddFontFile(path);

        // 获取字体族
        m_fontFamily = s_pfc.Families[s_pfc.Families.Length - 1];

        m_isLoadCompleted = true;
    }

    void IResourcePackage.LoadAsync(string path)
    {
        Task.Run(() =>
        {
            // 从外部文件加载字体文件  
            s_pfc.AddFontFile(path);

            // 获取字体族
            m_fontFamily = s_pfc.Families[s_pfc.Families.Length - 1];

            m_isLoadCompleted = true;
        });
    }
}
