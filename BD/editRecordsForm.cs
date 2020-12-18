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
    public partial class editRecordsForm : Form
    {
        //todo combobox с допустимыми значениями для связанных полей

        Table currentTable;
        bool isNewRecord;
        List<string> data;
        int keyColumnIndex;
        string keyValue;
        public editRecordsForm(Table table)
        {
            InitializeComponent();
            isNewRecord = true;
            currentTable = table;
            fillDataGridColumns(table);
            AddRow();
        }

        public editRecordsForm(Table table, List<string> data, string value)
        {
            InitializeComponent();
            currentTable = table;
            fillDataGridColumns(table);
            AddRow();
            isNewRecord = false;
            this.data = data;
            fillDataInDataGrid();
            keyValue = value;
        }

        public void fillDataInDataGrid()
        {
            int columnIndex = 0;
            for (int j = 0; j < data.Count; j++)
            {
                if (j == keyColumnIndex) continue;
                tableData.Rows[0].Cells[columnIndex].Value = data[j].ToString();
                columnIndex++;
            }
        }
    
        public void fillDataGridColumns(Table table)
        {
            int counter = 0;
            /*tableData.ColumnCount = table.Fields.Count;*/
            for (int i = 0; i < table.Fields.Count; i++)
            {
                if (table.Fields[i].AutoInc)
                {
                    keyColumnIndex = i;
                    continue;
                }
                tableData.Columns.Add(i.ToString(), table.Fields[i].Name + " (" + table.Fields[i].Type + ")");       
                counter++;
            }
        }

        public void AddRow()
        {
            tableData.Rows.Add();
        }

        public void provideError(string text)
        {
            errorLabel.ForeColor = Color.Red;
            errorLabel.Visible = true;
            errorLabel.Text = text;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (isNewRecord)
                {
                    int columnIndex = 0;
                    DataGridViewRow row = tableData.Rows[0];
                    foreach (Field field in currentTable.Fields)
                    {
                        if (field.AutoInc) continue;

                        if (row.Cells[columnIndex].Value == null) field.Value = "";
                        else field.Value = row.Cells[columnIndex].Value.ToString();
                       
                        columnIndex++;
                    }

                    ViewTable.currentTable = this.currentTable;
                    Program.currentDB.Insert(currentTable);

                    this.Close();
                }
                else
                {
                    int columnIndex = 0;
                    DataGridViewRow row = tableData.Rows[0];
                    foreach (Field field in currentTable.Fields)
                    {
                        if (field.AutoInc) continue;

                        if (row.Cells[columnIndex].Value == null) field.Value = "";
                        else field.Value = row.Cells[columnIndex].Value.ToString();

                        columnIndex++;
                    }

                    currentTable.PrimaryField.Value = keyValue;
                    ViewTable.currentTable = this.currentTable;
                    Program.currentDB.Update(currentTable);

                    this.Close();
                }
            }
            catch (Exception)
            {
                provideError("Введенные данные не соответствуют типам данных полей");
            }
        }
    }
}
