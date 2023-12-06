using Com.WWZ.WinFormGameEngine;
using Com.WWZ.WinFormGameEngine.UI;
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GameSys.Instance.Enter(this);

            GameObject obj = new GameObject("GameIniter");
            obj.AddComponent<GameIniter>();
        }

    }
}