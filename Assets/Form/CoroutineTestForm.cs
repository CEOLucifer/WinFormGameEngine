using Com.WWZ.WinFormGameEngine;

namespace 炮打飞机
{
    public partial class CoroutineTestForm : Form
    {
        static Test test = null;

        public CoroutineTestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TestForm_Load_1(object sender, EventArgs e)
        {
            GameSys.Instance.Enter(this);

            GameObject obj = new GameObject("Test");
            test = obj.AddComponent<Test>();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            test.ct1.IsAllowContinue = true;
        }
    }
}
