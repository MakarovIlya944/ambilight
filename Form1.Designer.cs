namespace ambilightsharp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comlist = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.testbutton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.color = new System.Windows.Forms.CheckBox();
            this.colour = new System.Windows.Forms.CheckBox();
            this.heightled = new System.Windows.Forms.NumericUpDown();
            this.refresh = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.traymenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.onOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.heightled)).BeginInit();
            this.traymenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // comlist
            // 
            this.comlist.FormattingEnabled = true;
            this.comlist.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11"});
            this.comlist.Location = new System.Drawing.Point(12, 38);
            this.comlist.Name = "comlist";
            this.comlist.Size = new System.Drawing.Size(121, 21);
            this.comlist.TabIndex = 0;
            this.comlist.Text = "COM4";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "On/Off";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "92";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "кол-во диодов";
            // 
            // testbutton
            // 
            this.testbutton.Location = new System.Drawing.Point(141, 38);
            this.testbutton.Name = "testbutton";
            this.testbutton.Size = new System.Drawing.Size(95, 23);
            this.testbutton.TabIndex = 4;
            this.testbutton.Text = "Предпросмотр";
            this.testbutton.UseVisualStyleBackColor = true;
            this.testbutton.Click += new System.EventHandler(this.testbutton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 600);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // color
            // 
            this.color.AutoSize = true;
            this.color.Checked = true;
            this.color.CheckState = System.Windows.Forms.CheckState.Checked;
            this.color.Location = new System.Drawing.Point(242, 40);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(62, 17);
            this.color.TabIndex = 7;
            this.color.Text = "Цифры";
            this.color.UseVisualStyleBackColor = true;
            this.color.CheckedChanged += new System.EventHandler(this.color_CheckedChanged);
            // 
            // colour
            // 
            this.colour.AutoSize = true;
            this.colour.Checked = true;
            this.colour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.colour.Location = new System.Drawing.Point(310, 40);
            this.colour.Name = "colour";
            this.colour.Size = new System.Drawing.Size(51, 17);
            this.colour.TabIndex = 8;
            this.colour.Text = "Цвет";
            this.colour.UseVisualStyleBackColor = true;
            this.colour.CheckedChanged += new System.EventHandler(this.colour_CheckedChanged);
            // 
            // heightled
            // 
            this.heightled.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightled.Location = new System.Drawing.Point(454, 37);
            this.heightled.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.heightled.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightled.Name = "heightled";
            this.heightled.Size = new System.Drawing.Size(73, 20);
            this.heightled.TabIndex = 9;
            this.heightled.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.heightled.ValueChanged += new System.EventHandler(this.heightled_ValueChanged);
            // 
            // refresh
            // 
            this.refresh.AutoSize = true;
            this.refresh.Location = new System.Drawing.Point(367, 40);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(81, 17);
            this.refresh.TabIndex = 10;
            this.refresh.Text = "Обновлять";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.CheckedChanged += new System.EventHandler(this.refresh_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.traymenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Ambilight";
            this.notifyIcon1.Visible = true;
            // 
            // traymenu
            // 
            this.traymenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onOffToolStripMenuItem});
            this.traymenu.Name = "traymenu";
            this.traymenu.Size = new System.Drawing.Size(181, 48);
            // 
            // onOffToolStripMenuItem
            // 
            this.onOffToolStripMenuItem.Name = "onOffToolStripMenuItem";
            this.onOffToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.onOffToolStripMenuItem.Text = "On\\Off";
            this.onOffToolStripMenuItem.Click += new System.EventHandler(this.onOffToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 690);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.heightled);
            this.Controls.Add(this.colour);
            this.Controls.Add(this.color);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.testbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comlist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Ambilight";
            ((System.ComponentModel.ISupportInitialize)(this.heightled)).EndInit();
            this.traymenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comlist;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button testbutton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox color;
        private System.Windows.Forms.CheckBox colour;
        private System.Windows.Forms.NumericUpDown heightled;
        private System.Windows.Forms.CheckBox refresh;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip traymenu;
        private System.Windows.Forms.ToolStripMenuItem onOffToolStripMenuItem;
    }
}

