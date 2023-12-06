namespace Com.WWZ.WinFormGameEngine;

internal class RenderConst
{
    private static SolidBrush m_solidBrush = new SolidBrush(Color.Black);

    public static SolidBrush SolidBrush { get => m_solidBrush; set => m_solidBrush = value; }
}
