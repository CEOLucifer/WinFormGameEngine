namespace 炮打飞机.Assets.Form
{
    partial class BattleUIControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.launchBtn = new System.Windows.Forms.Button();
            this.rightBtn = new System.Windows.Forms.Button();
            this.leftBtn = new System.Windows.Forms.Button();
            this.reloadBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // launchBtn
            // 
            this.launchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.launchBtn.Location = new System.Drawing.Point(138, 59);
            this.launchBtn.Name = "launchBtn";
            this.launchBtn.Size = new System.Drawing.Size(112, 34);
            this.launchBtn.TabIndex = 5;
            this.launchBtn.Text = "发射";
            this.launchBtn.UseVisualStyleBackColor = true;
            // 
            // rightBtn
            // 
            this.rightBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rightBtn.Location = new System.Drawing.Point(214, 115);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(112, 34);
            this.rightBtn.TabIndex = 4;
            this.rightBtn.Text = "右转";
            this.rightBtn.UseVisualStyleBackColor = true;
            // 
            // leftBtn
            // 
            this.leftBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.leftBtn.Location = new System.Drawing.Point(67, 115);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(112, 34);
            this.leftBtn.TabIndex = 3;
            this.leftBtn.Text = "左转";
            this.leftBtn.UseVisualStyleBackColor = true;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadBtn.Location = new System.Drawing.Point(138, 59);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(112, 34);
            this.reloadBtn.TabIndex = 6;
            this.reloadBtn.Text = "重新装填";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Visible = false;
            // 
            // BattleUIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.launchBtn);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.reloadBtn);
            this.DoubleBuffered = true;
            this.Name = "BattleUIControl";
            this.Size = new System.Drawing.Size(392, 209);
            this.ResumeLayout(false);

        }

        #endregion

        public Button launchBtn;
        public Button rightBtn;
        public Button leftBtn;
        public Button reloadBtn;
    }
}
