using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
using System.Drawing.Text;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace 炮打飞机
{
    public partial class MainForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            this.Font = new Font(Resources.LoadFontFamily("Assets/Resources/Font/IPix中文像素字体.ttf"), 20, FontStyle.Bold);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GameSys.Instance.Enter(this);

            DebuggerSys.Instance.IsShowCurFps = true;
            //DebuggerSys.Instance.IsShowGameObject = true;
            DebuggerSys.Instance.Enter();
            Time.FPS = 120;

            GameManager.Instance.EnterInit();
        }

    }
}