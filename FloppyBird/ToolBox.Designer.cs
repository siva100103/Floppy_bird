namespace FloppyBird
{
    partial class ToolBox
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
            this.BackPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SVGContainer = new System.Windows.Forms.Panel();
            this.OptionPanel = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.ColorButton = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.BackPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.OptionPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackPanel
            // 
            this.BackPanel.BackColor = System.Drawing.Color.White;
            this.BackPanel.Controls.Add(this.ContentPanel);
            this.BackPanel.Controls.Add(this.OptionPanel);
            this.BackPanel.Controls.Add(this.TopPanel);
            this.BackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackPanel.Location = new System.Drawing.Point(0, 0);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(800, 450);
            this.BackPanel.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.ContentPanel.Controls.Add(this.dataGridView1);
            this.ContentPanel.Controls.Add(this.SVGContainer);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 68);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(730, 382);
            this.ContentPanel.TabIndex = 2;
            this.ContentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ContentPanelPaint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.Size = new System.Drawing.Size(396, 281);
            this.dataGridView1.TabIndex = 1;
            // 
            // SVGContainer
            // 
            this.SVGContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.SVGContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.SVGContainer.Location = new System.Drawing.Point(520, 0);
            this.SVGContainer.Name = "SVGContainer";
            this.SVGContainer.Size = new System.Drawing.Size(210, 382);
            this.SVGContainer.TabIndex = 0;
            this.SVGContainer.Visible = false;
            // 
            // OptionPanel
            // 
            this.OptionPanel.Controls.Add(this.button8);
            this.OptionPanel.Controls.Add(this.button7);
            this.OptionPanel.Controls.Add(this.button6);
            this.OptionPanel.Controls.Add(this.button5);
            this.OptionPanel.Controls.Add(this.button4);
            this.OptionPanel.Controls.Add(this.button3);
            this.OptionPanel.Controls.Add(this.button2);
            this.OptionPanel.Controls.Add(this.button1);
            this.OptionPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.OptionPanel.Location = new System.Drawing.Point(730, 68);
            this.OptionPanel.Name = "OptionPanel";
            this.OptionPanel.Size = new System.Drawing.Size(70, 382);
            this.OptionPanel.TabIndex = 1;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button8.Image = global::FloppyBird.Properties.Resources.icons8_galery_48;
            this.button8.Location = new System.Drawing.Point(0, 0);
            this.button8.Margin = new System.Windows.Forms.Padding(0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(70, 48);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.SvgPanelShower);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button7.Location = new System.Drawing.Point(0, 48);
            this.button7.Margin = new System.Windows.Forms.Padding(0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 50);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button6.Image = global::FloppyBird.Properties.Resources.icons8_delete_48;
            this.button6.Location = new System.Drawing.Point(0, 98);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 48);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SVGDeleter);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button5.Image = global::FloppyBird.Properties.Resources.icons8_brush_47;
            this.button5.Location = new System.Drawing.Point(0, 146);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 47);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StateChanger);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button4.Image = global::FloppyBird.Properties.Resources.icons8_resize_47;
            this.button4.Location = new System.Drawing.Point(0, 193);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 47);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button4_MouseClick);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Image = global::FloppyBird.Properties.Resources.icons8_rotate_47__2_;
            this.button3.Location = new System.Drawing.Point(0, 240);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 47);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LeftFlipper);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Image = global::FloppyBird.Properties.Resources.icons8_rotate_47__1_;
            this.button2.Location = new System.Drawing.Point(0, 287);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 48);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightFlipper);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::FloppyBird.Properties.Resources.icons8_add_50__1_;
            this.button1.Location = new System.Drawing.Point(0, 335);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 47);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SVGUpLoader);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TopPanel.Controls.Add(this.ColorButton);
            this.TopPanel.Controls.Add(this.button11);
            this.TopPanel.Controls.Add(this.button10);
            this.TopPanel.Controls.Add(this.button9);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 68);
            this.TopPanel.TabIndex = 0;
            // 
            // ColorButton
            // 
            this.ColorButton.Location = new System.Drawing.Point(441, 12);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(75, 48);
            this.ColorButton.TabIndex = 3;
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // button11
            // 
            this.button11.Image = global::FloppyBird.Properties.Resources.icons8_save_47;
            this.button11.Location = new System.Drawing.Point(155, 12);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 48);
            this.button11.TabIndex = 2;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SavePanel);
            // 
            // button10
            // 
            this.button10.Image = global::FloppyBird.Properties.Resources.icons8_redo_47;
            this.button10.Location = new System.Drawing.Point(288, 12);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 48);
            this.button10.TabIndex = 1;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Redo);
            // 
            // button9
            // 
            this.button9.Image = global::FloppyBird.Properties.Resources.icons8_undo_47;
            this.button9.Location = new System.Drawing.Point(26, 12);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 48);
            this.button9.TabIndex = 0;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Undo);
            // 
            // ToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackPanel);
            this.Name = "ToolBox";
            this.Text = "ToolBox";
            this.BackPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.OptionPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BackPanel;
        private System.Windows.Forms.Panel OptionPanel;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Panel SVGContainer;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}