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
    public partial class ViewTable : Form
    {
        public static Table currentTable;
        public static List<List<string>> data;
        public ViewTable(Table currentTable)
        {
            InitializeComponent();
            ViewTable.currentTable = currentTable;
            fillDataGridColumns(currentTable);
            fillDataInDataGrid(currentTable);
        }

        public void fillDataGridColumns(Table table)
        {
            tableData.ColumnCount = table.Fields.Count;
            for (int i = 0; i < table.Fields.Count; i++)
            {
                if (table.Fields[i].PrimaryKey) tableData.Columns[i].Name = "$ ";
                tableData.Columns[i].Name += table.Fields[i].Name + " (" + table.Fields[i].Type + ")";           
            }
        }
        public void AddRow()
        {
            tableData.Rows.Add();
        }
        public void fillDataInDataGrid(Table table)
        {
            List<List<String>> data = Program.currentDB.Select(table);
            ViewTable.data = data;
            for (int i = 0; i < data.Count; i++)
            {
                AddRow();
                for (int j = 0; j < tableData.Columns.Count; j++)
                {
                    tableData.Rows[i].Cells[j].Value = data[i][j].ToString();
                }
            }
        }

        private int GetPrimaryFieldIndex()
        {
            Field pk = currentTable.PrimaryField;
            int index = currentTable.Fields.FindIndex(e => e.Name == pk.Name);
            return index;
        }

        private void RemoveLineButton_Click(object sender, EventArgs e)
        {
            if (tableData.Rows.Count > 0)
            {
                /*DataGridViewRow row = tableData.SelectedRows[0];
                string value = row.Cells[GetPrimaryFieldIndex()].Value.ToString();
                currentTable.PrimaryField.Value = value;
                tableData.Rows.Remove(row);
                Program.currentDB.Delete(currentTable);*/

                foreach (DataGridViewRow row in tableData.SelectedRows)
                {
                    string value = row.Cells[GetPrimaryFieldIndex()].Value.ToString();
                    currentTable.PrimaryField.Value = value;
                    tableData.Rows.Remove(row);
                    Program.currentDB.Delete(currentTable);
                }
            }
            else
            {
                //error
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDataButton_Click(object sender, EventArgs e)
        {
            editRecordsForm form = new editRecordsForm(currentTable);
            form.ShowDialog();
        }

        private void ViewTable_Activated(object sender, EventArgs e)
        {
            tableData.Rows.Clear();
            fillDataInDataGrid(ViewTable.currentTable);
        }

        private void UpdateDataButton_Click(object sender, EventArgs e)
        {
            if (tableData.Rows.Count > 0)
            {
                editRecordsForm form = new editRecordsForm(currentTable, ViewTable.data[tableData.SelectedRows[0].Index],
                    tableData.SelectedRows[0].Cells[GetPrimaryFieldIndex()].Value.ToString());
                form.ShowDialog();
            }
        }

        /*private void SaveButton_Click(object sender, EventArgs e)
        {

        }*/
    }
}
