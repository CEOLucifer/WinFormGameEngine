using Com.WWZ.WinFormGameEngine;

namespace 炮打飞机
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            GameSys.Instance.Enter(this);



            //GameObject obj = new GameObject("sensei1");
            //SpriteRenderer sp = obj.AddComponent<SpriteRenderer>();
            //sp.Bitmap = new Bitmap("Assets/Resources/Sprites/sensei.gif");
            //CircleCollider cc = obj.AddComponent<CircleCollider>();
            //cc.Radius = 100;
            //cc.OnCollisionEnter += (ano) =>
            //{
            //    Console.WriteLine("碰撞" + ano);
            //};
            //obj.AddComponent<SimpleMove>();


            //GameObject obj2 = new GameObject("sensei2");
            //SpriteRenderer sp2 = obj2.AddComponent<SpriteRenderer>();
            //sp2.Bitmap = new Bitmap("Assets/Resources/Sprites/sensei.gif");
            //CircleCollider cc2 = obj2.AddComponent<CircleCollider>();
            //obj2.Transform.Position = new Vector2(400, 0);
            //cc2.Radius = 100;
            ////cc2.OnCollisionEnter += (ano) =>
            ////{
            ////    Console.WriteLine("碰撞" + ano);
            ////};

            //GameObject obj3 = new GameObject("background");
            //SpriteRenderer sp3 = obj3.AddComponent<SpriteRenderer>();
            //sp3.Bitmap = new Bitmap("Assets/Resources/Sprites/background.png");
            //sp3.SortingOrder = -1;
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void TestForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TestForm_Load_1(object sender, EventArgs e)
        {
            GameObject parentObj = new GameObject("Parent");
            SpriteRenderer sp1 = parentObj.AddComponent<SpriteRenderer>();
            sp1.Bitmap = new Bitmap("Assets/Resources/Sprites/sensei.gif");
            parentObj.Transform.Position = new(300, 300);

            GameObject childrenObj = new GameObject("Children");
            childrenObj.Transform.Parent = parentObj.Transform;
            SpriteRenderer sp2 = childrenObj.AddComponent<SpriteRenderer>();
            sp2.Bitmap = new Bitmap("Assets/Resources/Sprites/sensei.gif");
            childrenObj.Transform.Position = new(400, 400);
            childrenObj.Transform.Rotation = 30.0f;


            //parentObj.AddComponent<SimpleMove>();
            parentObj.AddComponent<SimpleRotate>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GameObject obj = GameObject.Find("sensei");
            //SpriteRenderer sp = obj.GetComponent<SpriteRenderer>();
            //sp.Destroy();
        }
    }
}
