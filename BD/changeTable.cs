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
    public partial class changeTable : Form
    {

        public static Table table;
        private static int rows;


        private const string primaryKeyDeleteRowError = "Невозможно удалить поле с первичным ключем";
        private const string primaryKeyEditRowError = "Невозможно редактировать поле с первичным ключем";

        public changeTable(Table loadedTable)
        {
            InitializeComponent();
            AddingTable.ReadOnly = true;
            rows = 0;
            table = loadedTable;
            InitializeDataGrid();
            FillDataGrid(loadedTable);
    
        }

        #region boolChekers
        public bool isRowPrimaryKey()
        {
            int row = AddingTable.SelectedRows[0].Index;
            if (AddingTable.Rows[row].Cells[3].Value != null 
                && (bool)AddingTable.Rows[row].Cells[3].Value != false)
            {
                return true;
            }

            return false;
        }
        #endregion

        public void provideError(string text)
        {
            label1.Visible = true;
            label1.ForeColor = Color.Red;
            label1.Text = text;
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

        public void FillRow(DataGridViewRow row, Field field)
        {
            row.Cells[0].Value = field.Name;
            row.Cells[1].Value = field.Type;
            row.Cells[2].Value = field.NotNull;
            row.Cells[3].Value = field.PrimaryKey;
            row.Cells[4].Value = field.AutoInc;
            if (field.Foreign != null)
            {
                row.Cells[5].Value = field.Foreign.toTable.Name + "." +field.Foreign.toField.Name;
            }
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
            AddingTable.Columns.Add("Связи", "Связи");
            
        }

        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            if (!isRowPrimaryKey())
            {
                Program.currentDB.DropColumn(table, table.Fields[AddingTable.SelectedRows[0].Index]);
                AddingTable.Rows.RemoveAt(AddingTable.SelectedRows[0].Index);
                label1.Visible = false;
            }
            else provideError(primaryKeyDeleteRowError);

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editRowButton_Click(object sender, EventArgs e)
        {
            if (!isRowPrimaryKey())
            {
                editForm form = new editForm(table.Fields[AddingTable.SelectedRows[0].Index], table);
                form.ShowDialog();
            }
            else provideError(primaryKeyEditRowError);
        }

        private void changeTable_Activated(object sender, EventArgs e)
        {
            AddingTable.Rows.Clear();
            FillDataGrid(table);
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            editForm form = new editForm(table);
            form.ShowDialog();
        }
    }
}
