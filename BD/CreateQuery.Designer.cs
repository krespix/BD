
namespace BD
{
    partial class CreateQuery
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
            this.tablesComboBox = new System.Windows.Forms.ComboBox();
            this.allFieldsListBox = new System.Windows.Forms.ListBox();
            this.removeChosenFieldButton = new System.Windows.Forms.Button();
            this.chooseFiledButton = new System.Windows.Forms.Button();
            this.chosenFieldslistBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.showQueryButton = new System.Windows.Forms.Button();
            this.referenceFieldCheckBox = new System.Windows.Forms.CheckBox();
            this.chosenFieldComboBox = new System.Windows.Forms.ComboBox();
            this.conditionTextBox = new System.Windows.Forms.TextBox();
            this.operatorsComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.conditionsListBox = new System.Windows.Forms.ListBox();
            this.delteConditionButton = new System.Windows.Forms.Button();
            this.ANDradioButton = new System.Windows.Forms.RadioButton();
            this.ORradioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // tablesComboBox
            // 
            this.tablesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tablesComboBox.FormattingEnabled = true;
            this.tablesComboBox.Location = new System.Drawing.Point(23, 24);
            this.tablesComboBox.Name = "tablesComboBox";
            this.tablesComboBox.Size = new System.Drawing.Size(145, 21);
            this.tablesComboBox.TabIndex = 0;
            this.tablesComboBox.SelectedIndexChanged += new System.EventHandler(this.tablesComboBox_SelectedIndexChanged);
            // 
            // allFieldsListBox
            // 
            this.allFieldsListBox.Enabled = false;
            this.allFieldsListBox.FormattingEnabled = true;
            this.allFieldsListBox.Location = new System.Drawing.Point(23, 93);
            this.allFieldsListBox.Name = "allFieldsListBox";
            this.allFieldsListBox.Size = new System.Drawing.Size(145, 108);
            this.allFieldsListBox.TabIndex = 7;
            // 
            // removeChosenFieldButton
            // 
            this.removeChosenFieldButton.Enabled = false;
            this.removeChosenFieldButton.Location = new System.Drawing.Point(187, 153);
            this.removeChosenFieldButton.Name = "removeChosenFieldButton";
            this.removeChosenFieldButton.Size = new System.Drawing.Size(46, 48);
            this.removeChosenFieldButton.TabIndex = 10;
            this.removeChosenFieldButton.Text = "<<";
            this.removeChosenFieldButton.UseVisualStyleBackColor = true;
            this.removeChosenFieldButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // chooseFiledButton
            // 
            this.chooseFiledButton.Enabled = false;
            this.chooseFiledButton.Location = new System.Drawing.Point(187, 93);
            this.chooseFiledButton.Name = "chooseFiledButton";
            this.chooseFiledButton.Size = new System.Drawing.Size(46, 48);
            this.chooseFiledButton.TabIndex = 9;
            this.chooseFiledButton.Text = ">>";
            this.chooseFiledButton.UseVisualStyleBackColor = true;
            this.chooseFiledButton.Click += new System.EventHandler(this.chooseFiledButton_Click);
            // 
            // chosenFieldslistBox
            // 
            this.chosenFieldslistBox.Enabled = false;
            this.chosenFieldslistBox.FormattingEnabled = true;
            this.chosenFieldslistBox.Location = new System.Drawing.Point(255, 93);
            this.chosenFieldslistBox.Name = "chosenFieldslistBox";
            this.chosenFieldslistBox.Size = new System.Drawing.Size(145, 108);
            this.chosenFieldslistBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Выберите поля:";
            // 
            // showQueryButton
            // 
            this.showQueryButton.Enabled = false;
            this.showQueryButton.Location = new System.Drawing.Point(175, 451);
            this.showQueryButton.Name = "showQueryButton";
            this.showQueryButton.Size = new System.Drawing.Size(75, 23);
            this.showQueryButton.TabIndex = 12;
            this.showQueryButton.Text = "Далее";
            this.showQueryButton.UseVisualStyleBackColor = true;
            this.showQueryButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // referenceFieldCheckBox
            // 
            this.referenceFieldCheckBox.AutoSize = true;
            this.referenceFieldCheckBox.Enabled = false;
            this.referenceFieldCheckBox.Location = new System.Drawing.Point(23, 207);
            this.referenceFieldCheckBox.Name = "referenceFieldCheckBox";
            this.referenceFieldCheckBox.Size = new System.Drawing.Size(163, 17);
            this.referenceFieldCheckBox.TabIndex = 13;
            this.referenceFieldCheckBox.Text = "Поля из связанных таблиц\r\n";
            this.referenceFieldCheckBox.UseVisualStyleBackColor = true;
            // 
            // chosenFieldComboBox
            // 
            this.chosenFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chosenFieldComboBox.Enabled = false;
            this.chosenFieldComboBox.FormattingEnabled = true;
            this.chosenFieldComboBox.Location = new System.Drawing.Point(23, 271);
            this.chosenFieldComboBox.Name = "chosenFieldComboBox";
            this.chosenFieldComboBox.Size = new System.Drawing.Size(107, 21);
            this.chosenFieldComboBox.TabIndex = 14;
            // 
            // conditionTextBox
            // 
            this.conditionTextBox.Enabled = false;
            this.conditionTextBox.Location = new System.Drawing.Point(228, 272);
            this.conditionTextBox.Name = "conditionTextBox";
            this.conditionTextBox.Size = new System.Drawing.Size(172, 20);
            this.conditionTextBox.TabIndex = 15;
            // 
            // operatorsComboBox
            // 
            this.operatorsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorsComboBox.Enabled = false;
            this.operatorsComboBox.FormattingEnabled = true;
            this.operatorsComboBox.Location = new System.Drawing.Point(155, 271);
            this.operatorsComboBox.Name = "operatorsComboBox";
            this.operatorsComboBox.Size = new System.Drawing.Size(46, 21);
            this.operatorsComboBox.TabIndex = 16;
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(325, 308);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 17;
            this.addButton.Text = "Добавить условие";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Выберите условия:";
            // 
            // conditionsListBox
            // 
            this.conditionsListBox.Enabled = false;
            this.conditionsListBox.FormattingEnabled = true;
            this.conditionsListBox.Location = new System.Drawing.Point(23, 337);
            this.conditionsListBox.Name = "conditionsListBox";
            this.conditionsListBox.Size = new System.Drawing.Size(377, 108);
            this.conditionsListBox.TabIndex = 19;
            // 
            // delteConditionButton
            // 
            this.delteConditionButton.Enabled = false;
            this.delteConditionButton.Location = new System.Drawing.Point(244, 308);
            this.delteConditionButton.Name = "delteConditionButton";
            this.delteConditionButton.Size = new System.Drawing.Size(75, 23);
            this.delteConditionButton.TabIndex = 20;
            this.delteConditionButton.Text = "Удалить условие";
            this.delteConditionButton.UseVisualStyleBackColor = true;
            this.delteConditionButton.Click += new System.EventHandler(this.delteConditionButton_Click);
            // 
            // ANDradioButton
            // 
            this.ANDradioButton.AutoSize = true;
            this.ANDradioButton.Enabled = false;
            this.ANDradioButton.Location = new System.Drawing.Point(23, 308);
            this.ANDradioButton.Name = "ANDradioButton";
            this.ANDradioButton.Size = new System.Drawing.Size(48, 17);
            this.ANDradioButton.TabIndex = 21;
            this.ANDradioButton.TabStop = true;
            this.ANDradioButton.Text = "AND";
            this.ANDradioButton.UseVisualStyleBackColor = true;
            // 
            // ORradioButton
            // 
            this.ORradioButton.AutoSize = true;
            this.ORradioButton.Enabled = false;
            this.ORradioButton.Location = new System.Drawing.Point(77, 308);
            this.ORradioButton.Name = "ORradioButton";
            this.ORradioButton.Size = new System.Drawing.Size(41, 17);
            this.ORradioButton.TabIndex = 22;
            this.ORradioButton.TabStop = true;
            this.ORradioButton.Text = "OR";
            this.ORradioButton.UseVisualStyleBackColor = true;
            // 
            // CreateQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 486);
            this.Controls.Add(this.ORradioButton);
            this.Controls.Add(this.ANDradioButton);
            this.Controls.Add(this.delteConditionButton);
            this.Controls.Add(this.conditionsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.operatorsComboBox);
            this.Controls.Add(this.conditionTextBox);
            this.Controls.Add(this.chosenFieldComboBox);
            this.Controls.Add(this.referenceFieldCheckBox);
            this.Controls.Add(this.showQueryButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.removeChosenFieldButton);
            this.Controls.Add(this.chooseFiledButton);
            this.Controls.Add(this.chosenFieldslistBox);
            this.Controls.Add(this.allFieldsListBox);
            this.Controls.Add(this.tablesComboBox);
            this.Name = "CreateQuery";
            this.Text = "CreateQuery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tablesComboBox;
        private System.Windows.Forms.ListBox allFieldsListBox;
        private System.Windows.Forms.Button removeChosenFieldButton;
        private System.Windows.Forms.Button chooseFiledButton;
        private System.Windows.Forms.ListBox chosenFieldslistBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button showQueryButton;
        private System.Windows.Forms.CheckBox referenceFieldCheckBox;
        private System.Windows.Forms.ComboBox chosenFieldComboBox;
        private System.Windows.Forms.TextBox conditionTextBox;
        private System.Windows.Forms.ComboBox operatorsComboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox conditionsListBox;
        private System.Windows.Forms.Button delteConditionButton;
        private System.Windows.Forms.RadioButton ANDradioButton;
        private System.Windows.Forms.RadioButton ORradioButton;
    }
}