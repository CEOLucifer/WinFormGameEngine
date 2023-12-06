using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System.Windows.Forms;

/// <summary>
/// 初始面板
/// </summary>
public class InitPanel : BaseComponent, IUIPanel
{
    private UIControl<Label> m_titleLab;
    private UIControl<Button> m_startBtn;
    private UIControl<Button> m_exitBtn;

    private LerpMove m_titleLabLerpMove;
    private LerpMove m_startBtnLerpMove;
    private LerpMove m_exitBtnLerpMove;

    private float m_titleLabEndPosY = 0.2f;
    private float m_startLabEndPosY = 0.5f;
    private float m_exitLabEndPosY = 0.7f;

    private float m_titleLabEndPosY2 = -500.0f;
    private float m_startLabEndPosY2 = 500.0f;
    private float m_exitLabEndPosY2 = 500.0f;

    private float m_destroyTime = 3.0f;
    private float m_destroyTimer = 0.0f;
    private bool m_isDestroting = false;


    public UIControl<Label> TitleLab { get => m_titleLab; set => m_titleLab = value; }
    public UIControl<Button> StartBtn { get => m_startBtn; set => m_startBtn = value; }
    public UIControl<Button> ExitBtn { get => m_exitBtn; set => m_exitBtn = value; }

    public void PanelHide()
    {
        Form form = GameSys.Instance.Form;

        m_titleLabLerpMove.EndPos = new((form.Width - m_titleLab.Control.Width) / 2, m_titleLabEndPosY2);

        m_startBtnLerpMove.EndPos = new((form.Width - m_startBtn.Control.Width) / 2, form.Height + m_startLabEndPosY2);

        m_exitBtnLerpMove.EndPos = new((form.Width - m_exitBtn.Control.Width) / 2, form.Height + m_exitLabEndPosY2);

        m_isDestroting = true;
    }


    public void PanelShow()
    {
        Form form = GameSys.Instance.Form;

        // 创建标题、按钮，监听按钮点击事件
        GameObject titleLabObj = new GameObject("TitleLabObj");
        m_titleLab = titleLabObj.AddComponent<UIControl<Label>>();
        m_titleLab.Control.Text = "炮打飞机";
        m_titleLab.Control.Font = new Font("微软雅黑", 72);
        m_titleLab.Control.AutoSize = true;
        m_titleLab.Control.BackColor = Color.Transparent;
        titleLabObj.Transform.Position = new((form.Width - m_titleLab.Control.Width) / 2, m_titleLabEndPosY2);
        m_titleLabLerpMove = titleLabObj.AddComponent<LerpMove>();
        m_titleLabLerpMove.EndPos = new((form.Width - m_titleLab.Control.Width) / 2, form.Height * m_titleLabEndPosY);

        GameObject startBtnObj = new GameObject("StartBtnObj");
        m_startBtn = startBtnObj.AddComponent<UIControl<Button>>();
        m_startBtn.Control.Text = "开炮！！！";
        m_startBtn.Control.Font = new Font("微软雅黑", 20);
        m_startBtn.Control.Size = new(300, 100);
        startBtnObj.Transform.Position = new((form.Width - m_startBtn.Control.Width) / 2, form.Height + m_startLabEndPosY2);
        m_startBtnLerpMove = startBtnObj.AddComponent<LerpMove>();
        m_startBtnLerpMove.EndPos = new((form.Width - m_startBtn.Control.Width) / 2, form.Height * m_startLabEndPosY);


        GameObject exitBtnObj = new GameObject("ExitBtnObj");
        m_exitBtn = exitBtnObj.AddComponent<UIControl<Button>>();
        m_exitBtn.Control.Text = "退出";
        m_exitBtn.Control.Font = new Font("微软雅黑", 20);
        m_exitBtn.Control.Size = new(300, 100);
        exitBtnObj.Transform.Position = new((form.Width - m_exitBtn.Control.Width) / 2, form.Height + m_exitLabEndPosY2);
        m_exitBtnLerpMove = exitBtnObj.AddComponent<LerpMove>();
        m_exitBtnLerpMove.EndPos = new((form.Width - m_exitBtn.Control.Width) / 2, form.Height * m_exitLabEndPosY);
    }

    public override void Update()
    {
        if (!m_isDestroting)
            return;

        m_destroyTimer += Time.DeltaTime;

        if (m_destroyTimer >= m_destroyTime)
        {
            m_titleLab.GameObject.Destroy();
            m_startBtn.GameObject.Destroy();
            m_exitBtn.GameObject.Destroy();

            this.GameObject.Destroy();
        }
    }
}
