
namespace BD
{
    partial class ViewTable
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
            this.tableData = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RemoveLineButton = new System.Windows.Forms.Button();
            this.AddDataButton = new System.Windows.Forms.Button();
            this.UpdateDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableData)).BeginInit();
            this.SuspendLayout();
            // 
            // tableData
            // 
            this.tableData.AllowUserToAddRows = false;
            this.tableData.AllowUserToDeleteRows = false;
            this.tableData.AllowUserToResizeColumns = false;
            this.tableData.AllowUserToResizeRows = false;
            this.tableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableData.Location = new System.Drawing.Point(12, 12);
            this.tableData.Name = "tableData";
            this.tableData.ReadOnly = true;
            this.tableData.RowHeadersVisible = false;
            this.tableData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableData.Size = new System.Drawing.Size(751, 269);
            this.tableData.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(654, 305);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(109, 27);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Закрыть";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RemoveLineButton
            // 
            this.RemoveLineButton.Location = new System.Drawing.Point(127, 305);
            this.RemoveLineButton.Name = "RemoveLineButton";
            this.RemoveLineButton.Size = new System.Drawing.Size(109, 27);
            this.RemoveLineButton.TabIndex = 2;
            this.RemoveLineButton.Text = "Удалить строку";
            this.RemoveLineButton.UseVisualStyleBackColor = true;
            this.RemoveLineButton.Click += new System.EventHandler(this.RemoveLineButton_Click);
            // 
            // AddDataButton
            // 
            this.AddDataButton.Location = new System.Drawing.Point(12, 305);
            this.AddDataButton.Name = "AddDataButton";
            this.AddDataButton.Size = new System.Drawing.Size(109, 27);
            this.AddDataButton.TabIndex = 3;
            this.AddDataButton.Text = "Добавить запись";
            this.AddDataButton.UseVisualStyleBackColor = true;
            this.AddDataButton.Click += new System.EventHandler(this.AddDataButton_Click);
            // 
            // UpdateDataButton
            // 
            this.UpdateDataButton.Location = new System.Drawing.Point(242, 305);
            this.UpdateDataButton.Name = "UpdateDataButton";
            this.UpdateDataButton.Size = new System.Drawing.Size(176, 27);
            this.UpdateDataButton.TabIndex = 4;
            this.UpdateDataButton.Text = "Обновить значения записи";
            this.UpdateDataButton.UseVisualStyleBackColor = true;
            this.UpdateDataButton.Click += new System.EventHandler(this.UpdateDataButton_Click);
            // 
            // ViewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 344);
            this.Controls.Add(this.UpdateDataButton);
            this.Controls.Add(this.AddDataButton);
            this.Controls.Add(this.RemoveLineButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tableData);
            this.Name = "ViewTable";
            this.Text = "ViewTable";
            this.Activated += new System.EventHandler(this.ViewTable_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.tableData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tableData;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button RemoveLineButton;
        private System.Windows.Forms.Button AddDataButton;
        private System.Windows.Forms.Button UpdateDataButton;
    }
}