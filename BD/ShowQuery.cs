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
    public partial class ShowQuery : Form
    {
        List<List<string>> currentData;
        List<Field> fields;
        public ShowQuery(Table table, List<Field> fields, bool reference, string condition = "")
        {
            InitializeComponent();
            fillDataGridColumns(fields);
            fillDataInDataGrid(table, fields, reference, condition);
        }

        public void fillDataGridColumns(List<Field> Fields)
        {
            showQueryDataGrid.ColumnCount = Fields.Count;
            for (int i = 0; i < Fields.Count; i++)
            {
                if (Fields[i].PrimaryKey) showQueryDataGrid.Columns[i].Name = "$ ";
                showQueryDataGrid.Columns[i].Name += Fields[i].Name + " (" + Fields[i].Type + ")";
            }
        }

        public void fillDataInDataGrid(Table table, List<Field> Fields, bool reference, string condition = "")
        {
            showQueryDataGrid.Rows.Clear();
            List<List<String>> data;
            if (table.Fields.Count == Fields.Count && (condition == null || condition.Length == 0))
                data = Program.currentDB.Select(table, reference);
            if (table.Fields.Count == Fields.Count && !(condition == null || condition.Length == 0))
                data = Program.currentDB.Select(table, condition, reference);
            else if (condition == null || condition.Length == 0)
                data = Program.currentDB.Select(table, Fields, reference);
            else
                data = Program.currentDB.Select(table, Fields, condition, reference);

            if (reference) showQueryDataGrid.Columns.Add("Связанная таблица", "Связанная таблица");
            showQueryDataGrid.ColumnCount = data[0].Count;

            for (int i = 0; i < data.Count; i++)
            {
                AddRow();
                for (int j = 0; j < /*showQueryDataGrid.Columns.Count*/ data[i].Count; j++)
                {
                    showQueryDataGrid.Rows[i].Cells[j].Value = data[i][j].ToString();
                }
            }

            fields = Fields; 
            currentData = data;
            currentData.Insert(0, FieldHeaders(fields));
        }

        private List<string> FieldHeaders(List<Field> fields)
        {
            List<string> result = new List<string>();
            foreach (Field item in fields)
            {
                result.Add(item.Name);
            }
            return result;
        }

        private void ExportToWord()
        {
            saveFileDialog1.Filter = "MS Word(*.doc)|*.docx";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            
            Reports.WriteWord(filename, currentData);
        }

        private void ExportToExcel()
        {
            saveFileDialog1.Filter = "MS Excel(*.xls)|*.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            
            Reports.WriteExcel(filename, currentData);
        }

        public void AddRow()
        {
            showQueryDataGrid.Rows.Add();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exportToWordButton_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        private void exportToExcelButton_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}
