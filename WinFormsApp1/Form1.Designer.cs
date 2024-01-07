namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            colorDialog1 = new ColorDialog();
            menuStrip1 = new MenuStrip();
            легкийToolStripMenuItem = new ToolStripMenuItem();
            легкийToolStripMenuItem1 = new ToolStripMenuItem();
            среднийToolStripMenuItem = new ToolStripMenuItem();
            сложныйToolStripMenuItem = new ToolStripMenuItem();
            новаяИграToolStripMenuItem = new ToolStripMenuItem();
            checkToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { легкийToolStripMenuItem, новаяИграToolStripMenuItem, checkToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(424, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // легкийToolStripMenuItem
            // 
            легкийToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { легкийToolStripMenuItem1, среднийToolStripMenuItem, сложныйToolStripMenuItem });
            легкийToolStripMenuItem.Name = "легкийToolStripMenuItem";
            легкийToolStripMenuItem.Size = new Size(60, 20);
            легкийToolStripMenuItem.Text = "Уровни";
            // 
            // легкийToolStripMenuItem1
            // 
            легкийToolStripMenuItem1.Checked = true;
            легкийToolStripMenuItem1.CheckState = CheckState.Checked;
            легкийToolStripMenuItem1.Name = "легкийToolStripMenuItem1";
            легкийToolStripMenuItem1.Size = new Size(128, 22);
            легкийToolStripMenuItem1.Text = "Легкий";
            легкийToolStripMenuItem1.Click += ЛегкийToolStripMenuItem1_Click;
            // 
            // среднийToolStripMenuItem
            // 
            среднийToolStripMenuItem.Name = "среднийToolStripMenuItem";
            среднийToolStripMenuItem.Size = new Size(128, 22);
            среднийToolStripMenuItem.Text = "Средний";
            среднийToolStripMenuItem.Click += СреднийToolStripMenuItem_Click;
            // 
            // сложныйToolStripMenuItem
            // 
            сложныйToolStripMenuItem.Name = "сложныйToolStripMenuItem";
            сложныйToolStripMenuItem.Size = new Size(128, 22);
            сложныйToolStripMenuItem.Text = "Сложный";
            сложныйToolStripMenuItem.Click += СложныйToolStripMenuItem_Click;
            // 
            // новаяИграToolStripMenuItem
            // 
            новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            новаяИграToolStripMenuItem.Size = new Size(81, 20);
            новаяИграToolStripMenuItem.Text = "Новая игра";
            новаяИграToolStripMenuItem.Click += НоваяИграToolStripMenuItem_Click;
            // 
            // checkToolStripMenuItem
            // 
            checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            checkToolStripMenuItem.Size = new Size(79, 20);
            checkToolStripMenuItem.Text = "Проверить";
            checkToolStripMenuItem.Click += CheckToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9 });
            dataGridView1.Location = new Point(12, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(400, 265);
            dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "";
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.HeaderText = "";
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.HeaderText = "";
            Column9.Name = "Column9";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(429, 32);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 3;
            label1.Text = "Всё верно!";
            label1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 301);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Sudoku";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ColorDialog colorDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem легкийToolStripMenuItem;
        private ToolStripMenuItem легкийToolStripMenuItem1;
        private ToolStripMenuItem среднийToolStripMenuItem;
        private ToolStripMenuItem сложныйToolStripMenuItem;
        private ToolStripMenuItem новаяИграToolStripMenuItem;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private Label label1;
        private ToolStripMenuItem checkToolStripMenuItem;
    }
}
