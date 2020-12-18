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
    public partial class MainWindow : Form
    {
        public const string dbStatusConnected = "Статус: БД подключена";
        public const string dbStatusNotConnected = "Статус: БД не подключена";
        public const string noDBError = "Чтобы добавить таблицу откройте или создайте БД";
        public MainWindow()
        {
            InitializeComponent();
            InitializeDataGrid();
            provideInfo(dbStatusNotConnected);
        }

        public void InitializeDataGrid()
        {
            tableTable.ColumnCount = 2;
            tableTable.Columns[0].Name = "Имя";
            tableTable.Columns[0].Width = tableTable.Width / 2 - 2;
            tableTable.Columns[1].Name = "Количество полей";
            tableTable.Columns[1].Width = tableTable.Width / 2 - 2;
        }

        private void createDB()
        {
            saveFileDialog1.Filter = "Database files(*.db)|*.db";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            Program.currentDB = new Database(filename);
            provideInfo(dbStatusConnected);
        }

        private void openDB()
        {
            openFileDialog1.Filter = "Database files(*.db)|*.db";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            //read DB
            Program.currentDB = new Database(filename);
            Program.tables = Program.currentDB.tables;
            printTables();
            provideInfo(dbStatusConnected);
        }

        public void printTables()
        {
            tableTable.Rows.Clear();
            foreach (Table item in Program.tables)
            {
                tableTable.Rows.Add(item.Name, item.Fields.Count);
            }
        }

        public void provideInfo(string text)
        {
            label1.Visible = true;
            label1.ForeColor = Color.Black;
            label1.Text = text;
        }

        public void provideError(string text)
        {
            label1.Visible = true;
            label1.ForeColor = Color.Red;
            label1.Text = text;
        }

        private void deleteTable(Table table)
        {
            Program.currentDB.DropTable(table.Name);
            Program.tables.Remove(table);
            printTables();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            printTables();
        }

        private void createQueryButton_Click(object sender, EventArgs e)
        {
            if (Program.currentDB != null)
            {
                CreateQuery form = new CreateQuery();
                form.ShowDialog();
            }
            else
            {
                provideError(noDBError);
            }
        }
        private void addTableButton_Click(object sender, EventArgs e)
        {
            if (Program.currentDB != null)
            {
                label1.Visible = false;
                AddTable form = new AddTable();
                form.ShowDialog();
            }
            else
            {
                provideError(noDBError);
            }
        }

        private void tableTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewTable form = new ViewTable(Program.tables[tableTable.SelectedRows[0].Index]);
            form.ShowDialog();
            label1.Visible = false;
        }

        private void changeTableMenuItem_Click(object sender, EventArgs e)
        {
            changeTable form = new changeTable(Program.tables[tableTable.SelectedRows[0].Index]);
            label1.Text = tableTable.CurrentRow.Index.ToString();
            form.ShowDialog();
            label1.Visible = false;
        }

        private void открытьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            ViewTable form = new ViewTable(Program.tables[tableTable.SelectedRows[0].Index]);
            form.ShowDialog();
            label1.Visible = false;
        }

        private void удалитьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteTable(Program.tables[tableTable.SelectedRows[0].Index]);
        }

        private void новаяБазаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createDB();   
        }

        private void открытьБазуДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDB();
        }

        private void tableTable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = tableTable.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    tableTable.ClearSelection();
                    tableTable.Rows[hit.RowIndex].Selected = true;
                }
            }
        }
    }
}
