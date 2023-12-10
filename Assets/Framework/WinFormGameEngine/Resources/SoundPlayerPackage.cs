namespace Com.WWZ.WinFormGameEngine;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// SoundPlayer包装
/// </summary>
public class SoundPlayerPackage : IResourcePackage
{
    private SoundPlayer m_soundPlayer;
    private bool m_isLoadCompleted = false;

    public SoundPlayer SoundPlayer { get => m_soundPlayer; internal set => m_soundPlayer = value; }

    bool IResourcePackage.IsLoadCompleted => m_isLoadCompleted;

    void IResourcePackage.Load(string path)
    {
        m_soundPlayer = new SoundPlayer();
        m_soundPlayer.SoundLocation = path;
        m_soundPlayer.Load();

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
