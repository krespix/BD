using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace BD
{
    public partial class AddTable : Form
    {
        static Table table;
        static List<Field> fields;
        private static int rows;

        private const String rowsErrorText = "Количество полей в таблице должно быть не меньше 1";
        private const String primaryKeysErrorText = "В таблице может быть только одно ключевое поле";
        private const String fieldsNameErrorText = "У каждого поля должно быть название";
        private const String tableNameErrorText = "У таблицы должно быть название";
        private const String tableNameUnicErrorText = "Название таблицы совпадает с названием существующей таблицей";
        private const String fieldNameUnicText = "Названия полей должны быть уникальны";
        private const String invalidTableNameText = "Название таблицы может начинаться только с буквы и содержать только буквы, цифры или нижнее подчеркивание";
        private const String invalidFieldNameText = "Название поля может начинаться только с буквы исодержать только буквы, цифры или нижнее подчеркивание";

        public AddTable()
        {
            InitializeComponent();
            rows = 0;        
            table = new Table(tableName.Text, new List<Field>(), null);
            fields = new List<Field>();
            InitializeDataGrid();
        }

        public AddTable(Table loadedTable)
        {
            InitializeComponent();
            rows = 0;
            table = loadedTable;
            fields = loadedTable.Fields;
            InitializeDataGrid();
            FillDataGrid(loadedTable);
            FillColumnConnections();
        }

        public void FillDataGrid(Table table)
        {
            tableName.Text = table.Name;
            AddRow(table.Fields.Count);
            DataGridViewRow currentRow;
            for (int i = 0; i < table.Fields.Count; i++)
            {
                currentRow = AddingTable.Rows[i];
                FillRow(currentRow, table.Fields[i]);
            }
        }

        public void FillRow(DataGridViewRow row, Field field)
        {
            row.Cells[0].Value = field.Name;
            row.Cells[1].Value = field.Type;
            row.Cells[2].Value = field.NotNull;
            row.Cells[3].Value = field.PrimaryKey;
            row.Cells[4].Value = field.AutoInc;
        }

        public void AddRow(int number)
        {
            for (int i = 0; i < number; i++)
            {
                AddRow();
            }
        }

        private void AddRow()
        {
            string name = "field" + rows;
            AddingTable.Rows.Add(name, "INTEGER");
            rows++;
        }

        private List<string> GetAllFitFields(string type)
        {
            List<string> result = new List<string>();

            foreach (Table item in Program.tables)
            {
                foreach (Field field in item.Fields)
                {
                    if (/*field != item.PrimaryField &&*/ field.Type == type)
                    {
                        result.Add(item.Name + "." + field.Name);
                    }
                }
            }

            return result;
        }

        private void FillColumnConnections(List<string> items, int rowIndex)
        {
            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(AddingTable.Rows[rowIndex].Cells["Связи"]); 
            if (items == null)
            {
                cell.DataSource = new List<string> { " " };
            }
            else
            {
                cell.DataSource = items;
            }         
        }

        private void FillColumnConnections()
        {
            string type;
            List<string> items = new List<string>();
            foreach (DataGridViewRow row in AddingTable.Rows)
            {
                type = row.Cells[1].Value.ToString();
                items = GetAllFitFields(type);
                FillColumnConnections(items, row.Index);
            }
        }

        private string GetTableName(DataGridViewRow row)
        {
            return row.Cells[5].Value.ToString().Split('.')[0];
        }

        private string GetFieldName(DataGridViewRow row)
        {
            return row.Cells[5].Value.ToString().Split('.')[1];
        }
        public void InitializeDataGrid()
        {           
            AddingTable.ColumnCount = 1;
            AddingTable.Columns[0].Name = "Имя";
            DataGridViewComboBoxColumn temp = new DataGridViewComboBoxColumn();
            temp.Items.Add("TEXT");
            temp.Items.Add("INTEGER");
            temp.Items.Add("REAL");
            temp.Name = "Тип";
            AddingTable.Columns.Add(temp);
            AddingTable.Columns.Add(new DataGridViewCheckBoxColumn());
            AddingTable.Columns[2].Name = "Не пустое";
            AddingTable.Columns.Add(new DataGridViewCheckBoxColumn());
            AddingTable.Columns[3].Name = "Ключ";
            AddingTable.Columns.Add(new DataGridViewCheckBoxColumn());
            AddingTable.Columns[4].Name = "Счетчик";
            temp = new DataGridViewComboBoxColumn();
            //todo добавить связи
            temp.Name = "Связи";
            temp.Items.Add("");
            temp.Items.Add("table.field"); //can be null
            AddingTable.Columns.Add(temp);
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRow();
            string type = "INTEGER";
            List<string> items = GetAllFitFields(type);
            FillColumnConnections(items, AddingTable.Rows.Count - 1);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AddingTable.Rows.Count >= 1)
                AddingTable.Rows.RemoveAt(AddingTable.Rows.Count - 1);
        }

        public void provideError(string text)
        {
            errorLabel.Visible = true;
            errorLabel.Text = text;
        }

        private bool checkTableUnicName()
        {
            foreach (var item in Program.tables)
            {
                if (item.Name.Equals(tableName.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkFieldsUnicName()
        {
            for (int i = 0; i < AddingTable.Rows.Count; i++)
            {
                DataGridViewRow item = AddingTable.Rows[i];
                for (int j = i + 1; j < AddingTable.Rows.Count; j++)
                {
                    if (item.Cells[0].Value.ToString() == AddingTable.Rows[j].Cells[0].Value.ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isFieldsNamesValid()
        {
            for (int i = 0; i < AddingTable.Rows.Count; i++)
            {
                DataGridViewRow item = AddingTable.Rows[i];

                foreach (Char symbol in item.Cells[0].Value.ToString())
                {
                    if (!Char.IsLetterOrDigit(symbol) && symbol != '_') return false;
                }

            }
            return true;
        }

        private bool isTableNameValid()
        {
            if (!Char.IsLetter(tableName.Text[0])) return false;
            foreach (Char symbol in tableName.Text)
            {
                if (!Char.IsLetterOrDigit(symbol) && symbol != '_') return false;
            }
            return true;
        }

        private bool checkFieldsNames()
        {
            bool hasFieldsNames = true;
            for (int i = 0; i < AddingTable.Rows.Count; i++)
            {
                DataGridViewRow item = AddingTable.Rows[i];
                if (item.Cells[0].Value == null)
                {
                    hasFieldsNames = false;
                }
            }
            return hasFieldsNames;
        }

        private bool checkTableName()
        {
            return !tableName.Text.Equals("");
        }

        private bool checkPrimaryKey()
        {
            int countPrimaryKeys = 0;
            for (int i = 0; i < AddingTable.Rows.Count; i++)
            {
                DataGridViewRow item = AddingTable.Rows[i];
                if (item.Cells[3].Value != null && (bool)item.Cells[3].Value != false) countPrimaryKeys++;
            }
            return countPrimaryKeys == 1;
        }

        private bool checkRowCount()
        {
           return AddingTable.Rows.Count >= 1;
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            if (checkFieldsNames() && checkPrimaryKey() && checkRowCount()
                && checkTableName() && checkTableUnicName()
                && checkFieldsUnicName() && isTableNameValid())
            {
                for (int i = 0; i < AddingTable.Rows.Count; i++)
                {

                    DataGridViewRow item = AddingTable.Rows[i];
                    /*label1.Text = (item.Cells[2].Value != null).ToString();*/

                    Field field = new Field(item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString(),
                        item.Cells[2].Value != null, item.Cells[3].Value != null,
                        item.Cells[4].Value != null, item.Cells[3].Value != null);
                    if (item.Cells[3].Value != null) table.PrimaryField = field;

                    if (item.Cells[5].Value != null)
                    {
                        string tableName = GetTableName(item);
                        string fieldName = GetFieldName(item);
                        Table depTable = Program.tables.Find(p => p.Name == tableName);
                        Field tempField = depTable.Fields.Find(p => p.Name == fieldName);

                        field.Foreign = new Foreign(depTable, tempField);
                    }
                    fields.Add(field);
                }
                table.Name = tableName.Text;
                table.Fields = fields;

                Program.tables.Add(table);
                Program.currentDB.Create(table);
                this.Close();

                /*table.Name = "test";
                fields.Add(new Field("name", "Integer", true, true, true, true));
                table.Fields = fields;*/
            }
            else
            {
                if (!checkTableName()) provideError(tableNameErrorText);
                else if (!checkTableUnicName()) provideError(tableNameUnicErrorText);
                else if (!isTableNameValid()) provideError(invalidTableNameText);
                else if (!checkRowCount()) provideError(rowsErrorText);
                else if (!checkFieldsNames()) provideError(fieldsNameErrorText);
                else if (!isFieldsNamesValid()) provideError(invalidFieldNameText);
                else if (!checkFieldsUnicName()) provideError(fieldNameUnicText);
                else if (!checkPrimaryKey()) provideError(primaryKeysErrorText);
            }
        }

        private void AddingTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (AddingTable.CurrentCell.ColumnIndex == 1)
            {
                string type = AddingTable.CurrentCell.Value.ToString();
                List<string> fields = GetAllFitFields(type);
                FillColumnConnections(fields, AddingTable.CurrentCell.RowIndex);
            }
        }
    }
}
