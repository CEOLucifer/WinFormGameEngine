using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 炮打飞机;

/// <summary>
/// 爱丽丝
/// </summary>
public class Alice : BaseComponent
{
    private SpriteRenderer m_spriteRenderer;
    private LerpMove m_lerpMove;
    private CoroutineComp m_coroutineComp;
    private ContinueToken m_continueToken = new ContinueToken();

    // 讲话
    private GameObject m_speakObj;
    private ProTextRenderer m_proTextRenderer;
    private TextPrinter m_textPrinter;

    public ContinueToken ContinueToken { get => m_continueToken; set => m_continueToken = value; }

    public override void Awake()
    {
        this.Transform.Position = new(300, GameSys.Instance.Form.Height + 600);

        m_spriteRenderer = this.AddComponent<SpriteRenderer>();
        m_spriteRenderer.Pivot = new(288, 500);
        m_spriteRenderer.Bitmap = Resources.LoadBitmap("Assets/Resources/Sprites/Alice/Alice_idle.png");

        m_coroutineComp = this.AddComponent<CoroutineComp>();
        m_coroutineComp.StartCoroutine(GuideCoroutine());

        // 创建讲话相关组件
        m_speakObj = new GameObject("FontObj");
        m_speakObj.Transform.Position = new(400, GameSys.Instance.Form.Height - 500);
        m_proTextRenderer = m_speakObj.AddComponent<ProTextRenderer>();
        m_proTextRenderer.Font = new Font(Resources.LoadFontFamily("Assets/Resources/Font/IPix中文像素字体.ttf"), 15);
        m_textPrinter = m_speakObj.AddComponent<TextPrinter>();
        m_textPrinter.ProTextRenderer = m_proTextRenderer;
    }

    private IEnumerator GuideCoroutine()
    {
        // 出现动画
        m_lerpMove = this.AddComponent<LerpMove>();
        m_lerpMove.EndPos = new System.Numerics.Vector2(300, GameSys.Instance.Form.Height);

        // 等一会儿
        yield return new WaitForSeconds(1.5f);

        // 讲话
        m_spriteRenderer.Bitmap = Resources.LoadBitmap("Assets/Resources/Sprites/Alice/Alice_speak.png");
        m_textPrinter.PrintContent("警告！爱丽丝检测到有大量敌机来袭。");

        // 监听点击界面事件
        // 由于窗口被挡住了，故监听面板的事件
        BattleUIPanel panel = UISys.Instance.GetPanel<BattleUIPanel>();
        panel.C_battleUIControl.Control.Click += (_, _) =>
        {
            m_continueToken.IsAllowContinue = true;
        };

        // 点击之后
        yield return m_continueToken;

        // 讲话，出现炮塔和按钮
        m_spriteRenderer.Bitmap = Resources.LoadBitmap("Assets/Resources/Sprites/Alice/Alice_seriousSpeak.png");
        m_textPrinter.Clear();
        m_textPrinter.PrintContent("长官，快控制导弹防御系统拦截敌机吧！");
    }

    public override void OnDestroy()
    {
        m_speakObj.Destroy();
    }
}
