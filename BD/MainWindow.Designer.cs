
namespace BD
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.новаяБазаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьБазуДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableTable = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTableButton = new System.Windows.Forms.Button();
            this.createQueryButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTable)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяБазаДанныхToolStripMenuItem,
            this.открытьБазуДанныхToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(372, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // новаяБазаДанныхToolStripMenuItem
            // 
            this.новаяБазаДанныхToolStripMenuItem.Name = "новаяБазаДанныхToolStripMenuItem";
            this.новаяБазаДанныхToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.новаяБазаДанныхToolStripMenuItem.Text = "Новая база данных";
            this.новаяБазаДанныхToolStripMenuItem.Click += new System.EventHandler(this.новаяБазаДанныхToolStripMenuItem_Click);
            // 
            // открытьБазуДанныхToolStripMenuItem
            // 
            this.открытьБазуДанныхToolStripMenuItem.Name = "открытьБазуДанныхToolStripMenuItem";
            this.открытьБазуДанныхToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.открытьБазуДанныхToolStripMenuItem.Text = "Открыть базу данных";
            this.открытьБазуДанныхToolStripMenuItem.Click += new System.EventHandler(this.открытьБазуДанныхToolStripMenuItem_Click);
            // 
            // tableTable
            // 
            this.tableTable.AllowUserToAddRows = false;
            this.tableTable.AllowUserToDeleteRows = false;
            this.tableTable.AllowUserToResizeColumns = false;
            this.tableTable.AllowUserToResizeRows = false;
            this.tableTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableTable.Location = new System.Drawing.Point(12, 66);
            this.tableTable.Name = "tableTable";
            this.tableTable.ReadOnly = true;
            this.tableTable.RowHeadersVisible = false;
            this.tableTable.RowTemplate.ContextMenuStrip = this.contextMenuStrip1;
            this.tableTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableTable.Size = new System.Drawing.Size(348, 208);
            this.tableTable.TabIndex = 1;
            this.tableTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableTable_CellDoubleClick);
            this.tableTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableTable_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьТаблицуToolStripMenuItem,
            this.changeTableMenuItem,
            this.удалитьТаблицуToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 70);
            // 
            // открытьТаблицуToolStripMenuItem
            // 
            this.открытьТаблицуToolStripMenuItem.Name = "открытьТаблицуToolStripMenuItem";
            this.открытьТаблицуToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.открытьТаблицуToolStripMenuItem.Text = "Открыть таблицу";
            this.открытьТаблицуToolStripMenuItem.Click += new System.EventHandler(this.открытьТаблицуToolStripMenuItem_Click);
            // 
            // changeTableMenuItem
            // 
            this.changeTableMenuItem.Name = "changeTableMenuItem";
            this.changeTableMenuItem.Size = new System.Drawing.Size(202, 22);
            this.changeTableMenuItem.Text = "Редактировать таблицу";
            this.changeTableMenuItem.Click += new System.EventHandler(this.changeTableMenuItem_Click);
            // 
            // удалитьТаблицуToolStripMenuItem
            // 
            this.удалитьТаблицуToolStripMenuItem.Name = "удалитьТаблицуToolStripMenuItem";
            this.удалитьТаблицуToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.удалитьТаблицуToolStripMenuItem.Text = "Удалить таблицу";
            this.удалитьТаблицуToolStripMenuItem.Click += new System.EventHandler(this.удалитьТаблицуToolStripMenuItem_Click);
            // 
            // addTableButton
            // 
            this.addTableButton.Location = new System.Drawing.Point(12, 37);
            this.addTableButton.Name = "addTableButton";
            this.addTableButton.Size = new System.Drawing.Size(124, 23);
            this.addTableButton.TabIndex = 2;
            this.addTableButton.Text = "Добавить таблицу";
            this.addTableButton.UseVisualStyleBackColor = true;
            this.addTableButton.Click += new System.EventHandler(this.addTableButton_Click);
            // 
            // createQueryButton
            // 
            this.createQueryButton.Location = new System.Drawing.Point(235, 37);
            this.createQueryButton.Name = "createQueryButton";
            this.createQueryButton.Size = new System.Drawing.Size(125, 23);
            this.createQueryButton.TabIndex = 3;
            this.createQueryButton.Text = "Создать запрос";
            this.createQueryButton.UseVisualStyleBackColor = true;
            this.createQueryButton.Click += new System.EventHandler(this.createQueryButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(12, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 329);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createQueryButton);
            this.Controls.Add(this.addTableButton);
            this.Controls.Add(this.tableTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTable)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem новаяБазаДанныхToolStripMenuItem;
        private System.Windows.Forms.Button addTableButton;
        private System.Windows.Forms.Button createQueryButton;
        private System.Windows.Forms.ToolStripMenuItem открытьБазуДанныхToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьТаблицуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeTableMenuItem;
        public System.Windows.Forms.DataGridView tableTable;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem удалитьТаблицуToolStripMenuItem;
    }
}