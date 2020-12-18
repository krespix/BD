using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class editForm : Form
    {
        Table curerntTable;
        Field currentField;
        bool isNewField;
        private const String invalidFieldNameText = "Название поля может содержать только буквы, цифры или нижнее подчеркивание";
        private const String fieldsNameErrorText = "У поля должно быть название";
        private const String fieldNameUnicErrorText = "Название поля совпадает с названием существующого поля";
        private const String primaryKeyAddRowError = "Невозможно добавить еще одно ключевое поле";

        public editForm(Table table)
        {
            InitializeComponent();
            InitializeDataGrid();
            AddRow();
            isNewField = true;
            curerntTable = table;
            editDataGridView.Rows[0].Cells[1].Value = "INTEGER";
        }

        public editForm(Field field, Table table)
        {
            InitializeComponent();
            curerntTable = table;
            currentField = field;
            InitializeDataGrid();
            ReadOnlyGrid();
            AddRow();
            FillRow(editDataGridView.Rows[0], field);
        }

        private void ReadOnlyGrid()
        {
            editDataGridView.Columns[1].ReadOnly = true;
            editDataGridView.Columns[2].ReadOnly = true;
            editDataGridView.Columns[3].ReadOnly = true;
            editDataGridView.Columns[4].ReadOnly = true;
            editDataGridView.Columns[5].ReadOnly = true;
        }

        private void Replace()
        {
            int index = curerntTable.Fields.FindIndex(e => e.Name == currentField.Name);
            currentField.Name = editDataGridView.Rows[0].Cells[0].Value.ToString();
            curerntTable.Fields[index] = currentField;
        }

        private bool checkFieldsNames()
        {
            return editDataGridView.Rows[0].Cells[0].Value != null 
                && editDataGridView.Rows[0].Cells[0].Value.ToString().Length > 0;
        }

        private bool checkFieldsUnicName()
        {
            if (!isNewField && currentField.Name == editDataGridView.Rows[0].Cells[0].Value.ToString()) this.Close(); 
            for (int i = 0; i < curerntTable.Fields.Count; i++)
            {
                Field item = curerntTable.Fields[i];

                if (item.Name == editDataGridView.Rows[0].Cells[0].Value.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        private bool isFieldNamesValid()
        {

            foreach (Char symbol in editDataGridView.Rows[0].Cells[0].Value.ToString())
            {
                if (!Char.IsLetterOrDigit(symbol) && symbol != '_') return false;
            }
             
            return true;
        }

        public bool isRowPrimaryKey()
        {
            DataGridViewRow row = editDataGridView.Rows[0];
            if (row.Cells[3].Value == null
                || (bool)row.Cells[3].Value == false)
            {
                return false;
            }
            return true;
        }

        public void InitializeDataGrid()
        {
            editDataGridView.ColumnCount = 1;
            editDataGridView.Columns[0].Name = "Имя";
            DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
            temp.Items.Add("TEXT");
            temp.Items.Add("INTEGER");
            temp.Items.Add("REAL");
            temp.Name = "Тип";
            editDataGridView.Columns.Add(temp);
            editDataGridView.Columns.Add(new DataGridViewCheckBoxColumn());
            editDataGridView.Columns[2].Name = "Не пустое";
            editDataGridView.Columns.Add(new DataGridViewCheckBoxColumn());
            editDataGridView.Columns[3].Name = "Ключ";
            editDataGridView.Columns.Add(new DataGridViewCheckBoxColumn());
            editDataGridView.Columns[4].Name = "Счетчик";
            temp = new DataGridViewComboBoxColumn();
            //todo добавить связи
            temp.Name = "Связи";
            temp.Items.Add("");
            temp.Items.Add("table.field"); //can be null
            editDataGridView.Columns.Add(temp);
        }

        private void AddRow()
        {
            editDataGridView.Rows.Add();
        }

        public void provideError(string text)
        {
            errorLabel.ForeColor = Color.Red;
            errorLabel.Visible = true;
            errorLabel.Text = text;
        }

        public void FillRow(DataGridViewRow row, Field field)
        {
            row.Cells[0].Value = field.Name;
            row.Cells[1].Value = field.Type;
            row.Cells[2].Value = field.NotNull;
            row.Cells[3].Value = field.PrimaryKey;
            row.Cells[4].Value = field.AutoInc;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (checkFieldsNames() && checkFieldsUnicName() && isFieldNamesValid() && !isRowPrimaryKey())
            {
                if (!isNewField)
                {
                    Program.currentDB.RenameColumn(curerntTable.Name, currentField.Name,
                        editDataGridView.Rows[0].Cells[0].Value.ToString());
                    Replace();
                    changeTable.table = curerntTable;
                    this.Close();
                }
                else
                {
                    Field field;
                    DataGridViewRow item = editDataGridView.Rows[0];
                    if (item.Cells[3].Value == null)
                    {
                        field = new Field(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(),
                            item.Cells[2].Value != null, item.Cells[3].Value != null,
                            item.Cells[4].Value != null, item.Cells[3].Value != null);
                    }
                    else
                    {
                        field = new Field(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(),
                            item.Cells[2].Value != null, (bool)item.Cells[3].Value == true,
                            item.Cells[4].Value != null, item.Cells[3].Value != null);
                    }

                    curerntTable.Fields.Add(field);
                    Program.currentDB.AddColumn(curerntTable.Name, field);
                    changeTable.table = curerntTable;
                    this.Close();
                }
            }
            else if (!checkFieldsNames()) provideError(fieldsNameErrorText);
            else if (!isFieldNamesValid()) provideError(invalidFieldNameText);
            else if (!checkFieldsUnicName()) provideError(fieldNameUnicErrorText);
            else if (isRowPrimaryKey()) provideError(primaryKeyAddRowError);
        }
    }
}
