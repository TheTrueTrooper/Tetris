namespace AngeloSanches_CMPE2300_Lab2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Ticker = new System.Windows.Forms.Timer(this.components);
            this.Bu_NewGame = new System.Windows.Forms.Button();
            this.NUD_Scale = new System.Windows.Forms.NumericUpDown();
            this.La_NextShape = new System.Windows.Forms.Label();
            this.La_ShapesToGo = new System.Windows.Forms.Label();
            this.La_Lvl = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.La_Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Scale)).BeginInit();
            this.SuspendLayout();
            // 
            // Ticker
            // 
            this.Ticker.Enabled = true;
            this.Ticker.Interval = 1000;
            this.Ticker.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // Bu_NewGame
            // 
            this.Bu_NewGame.Location = new System.Drawing.Point(12, 12);
            this.Bu_NewGame.Name = "Bu_NewGame";
            this.Bu_NewGame.Size = new System.Drawing.Size(258, 97);
            this.Bu_NewGame.TabIndex = 0;
            this.Bu_NewGame.Text = "New Game";
            this.Bu_NewGame.UseVisualStyleBackColor = true;
            this.Bu_NewGame.Click += new System.EventHandler(this.Bu_NewGame_Click);
            // 
            // NUD_Scale
            // 
            this.NUD_Scale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_Scale.Location = new System.Drawing.Point(216, 115);
            this.NUD_Scale.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NUD_Scale.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_Scale.Name = "NUD_Scale";
            this.NUD_Scale.Size = new System.Drawing.Size(54, 22);
            this.NUD_Scale.TabIndex = 1;
            this.NUD_Scale.TabStop = false;
            this.NUD_Scale.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_Scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NUD_Scale_KeyDown);
            this.NUD_Scale.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NUD_Scale_KeyUp);
            // 
            // La_NextShape
            // 
            this.La_NextShape.AutoSize = true;
            this.La_NextShape.Location = new System.Drawing.Point(12, 129);
            this.La_NextShape.Name = "La_NextShape";
            this.La_NextShape.Size = new System.Drawing.Size(89, 17);
            this.La_NextShape.TabIndex = 2;
            this.La_NextShape.Text = "Next Shape :";
            // 
            // La_ShapesToGo
            // 
            this.La_ShapesToGo.AutoSize = true;
            this.La_ShapesToGo.Location = new System.Drawing.Point(12, 146);
            this.La_ShapesToGo.Name = "La_ShapesToGo";
            this.La_ShapesToGo.Size = new System.Drawing.Size(103, 17);
            this.La_ShapesToGo.TabIndex = 3;
            this.La_ShapesToGo.Text = "Shapes to Go :";
            // 
            // La_Lvl
            // 
            this.La_Lvl.AutoSize = true;
            this.La_Lvl.Location = new System.Drawing.Point(12, 112);
            this.La_Lvl.Name = "La_Lvl";
            this.La_Lvl.Size = new System.Drawing.Size(34, 17);
            this.La_Lvl.TabIndex = 4;
            this.La_Lvl.Text = "Lvl :";
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(150, 143);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 132);
            this.listBox1.TabIndex = 5;
            // 
            // La_Score
            // 
            this.La_Score.AutoSize = true;
            this.La_Score.Location = new System.Drawing.Point(12, 163);
            this.La_Score.Name = "La_Score";
            this.La_Score.Size = new System.Drawing.Size(53, 17);
            this.La_Score.TabIndex = 6;
            this.La_Score.Text = "Score :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 290);
            this.Controls.Add(this.La_Score);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.La_Lvl);
            this.Controls.Add(this.La_ShapesToGo);
            this.Controls.Add(this.La_NextShape);
            this.Controls.Add(this.NUD_Scale);
            this.Controls.Add(this.Bu_NewGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Scale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Ticker;
        private System.Windows.Forms.Button Bu_NewGame;
        private System.Windows.Forms.NumericUpDown NUD_Scale;
        private System.Windows.Forms.Label La_NextShape;
        private System.Windows.Forms.Label La_ShapesToGo;
        private System.Windows.Forms.Label La_Lvl;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label La_Score;
    }
}

