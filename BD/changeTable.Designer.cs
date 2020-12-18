
namespace BD
{
    partial class changeTable
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
            this.AddingTable = new System.Windows.Forms.DataGridView();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.DeleteRowButton = new System.Windows.Forms.Button();
            this.editRowButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.tableName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AddingTable)).BeginInit();
            this.SuspendLayout();
            // 
            // AddingTable
            // 
            this.AddingTable.AllowUserToAddRows = false;
            this.AddingTable.AllowUserToDeleteRows = false;
            this.AddingTable.AllowUserToResizeColumns = false;
            this.AddingTable.AllowUserToResizeRows = false;
            this.AddingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AddingTable.Location = new System.Drawing.Point(22, 34);
            this.AddingTable.Name = "AddingTable";
            this.AddingTable.RowHeadersVisible = false;
            this.AddingTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AddingTable.Size = new System.Drawing.Size(639, 236);
            this.AddingTable.TabIndex = 0;
            // 
            // AddRowButton
            // 
            this.AddRowButton.Location = new System.Drawing.Point(22, 302);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(105, 23);
            this.AddRowButton.TabIndex = 1;
            this.AddRowButton.Text = "Добавить строку";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // DeleteRowButton
            // 
            this.DeleteRowButton.Location = new System.Drawing.Point(146, 302);
            this.DeleteRowButton.Name = "DeleteRowButton";
            this.DeleteRowButton.Size = new System.Drawing.Size(115, 23);
            this.DeleteRowButton.TabIndex = 2;
            this.DeleteRowButton.Text = "Удалить строку";
            this.DeleteRowButton.UseVisualStyleBackColor = true;
            this.DeleteRowButton.Click += new System.EventHandler(this.DeleteRowButton_Click);
            // 
            // editRowButton
            // 
            this.editRowButton.Location = new System.Drawing.Point(278, 302);
            this.editRowButton.Name = "editRowButton";
            this.editRowButton.Size = new System.Drawing.Size(149, 23);
            this.editRowButton.TabIndex = 3;
            this.editRowButton.Text = "Редактировать строку";
            this.editRowButton.UseVisualStyleBackColor = true;
            this.editRowButton.Click += new System.EventHandler(this.editRowButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(583, 302);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(78, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // tableName
            // 
            this.tableName.AutoSize = true;
            this.tableName.Location = new System.Drawing.Point(19, 9);
            this.tableName.Name = "tableName";
            this.tableName.Size = new System.Drawing.Size(0, 13);
            this.tableName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // changeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 337);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableName);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.editRowButton);
            this.Controls.Add(this.DeleteRowButton);
            this.Controls.Add(this.AddRowButton);
            this.Controls.Add(this.AddingTable);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "changeTable";
            this.Text = "changeTable";
            this.Activated += new System.EventHandler(this.changeTable_Activated);

            ((System.ComponentModel.ISupportInitialize)(this.AddingTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AddingTable;
        private System.Windows.Forms.Button AddRowButton;
        private System.Windows.Forms.Button DeleteRowButton;
        private System.Windows.Forms.Button editRowButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label tableName;
        private System.Windows.Forms.Label label1;
    }
}