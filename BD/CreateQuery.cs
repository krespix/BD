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
    public partial class CreateQuery : Form
    {
        Table currentTable;
        static List<Field> chosenFields = new List<Field>();
        static string conditions = "";
        public CreateQuery()
        {
            InitializeComponent();
            FillTableCombobox();
            FillOperators();
            ANDradioButton.Checked = true;
        } 

        private Field GetFieldByName(string Name)
        {
            return chosenFields.Find(p => p.Name == Name);
        }

        private void FillChosenFields()
        {
            chosenFieldComboBox.Items.Clear();
            foreach (Field item in chosenFields)
            {
                chosenFieldComboBox.Items.Add(item.Name);
            }
            if (chosenFields.Count > 0)
                chosenFieldComboBox.Text = chosenFields[0].Name;
        }

        private void FillOperators()
        {
            string[] boolOperators = new  string[] { "=", "!=", "<", ">", "<=", ">=" };
            operatorsComboBox.Items.AddRange(boolOperators);
            operatorsComboBox.Text = "=";
        }

        private void FillTableCombobox()
        {
            foreach (Table table in Program.tables)
            {
                tablesComboBox.Items.Add(table.Name);
            }
        }

        private void FillAllFields()
        {
            allFieldsListBox.Items.Clear();
            foreach (Field field in currentTable.Fields)
            {
                allFieldsListBox.Items.Add(field.Name);
            }
        }

        private string CreateFullQuery()
        {
            string query = "";

            for (int i = 0; i < conditionsListBox.Items.Count; i++)
            {
                query += " " + conditionsListBox.Items[i];
            }

            return query;
        }

        private void DrawNewCondition()
        {
            Field currentField = GetFieldByName(chosenFieldComboBox.Text);
            string item = "";
            if (conditionsListBox.Items.Count > 0)
            {
                if (ANDradioButton.Checked) item += " AND ";
                else item += " OR ";        
            }
            item += currentTable.Name + "." + currentField.Name + operatorsComboBox.Text;
            string condition;
            if (conditionTextBox.Text == null || conditionTextBox.Text.Length == 0) condition = "NULL";
            else condition = conditionTextBox.Text;

            if (currentField.Type == "TEXT") item += " '" + condition + "' ";
            else item += condition;

            conditionsListBox.Items.Add(item);
        }

        private void EnableIfChooseTable()
        {
            chooseFiledButton.Enabled = true;
            removeChosenFieldButton.Enabled = true;
            referenceFieldCheckBox.Enabled = true;
            allFieldsListBox.Enabled = true;
            chosenFieldslistBox.Enabled = true;
            
        }

        private void EnableIfHaveChosenField()
        {
            chosenFieldComboBox.Enabled = true;
            operatorsComboBox.Enabled = true;
            conditionsListBox.Enabled = true;
            conditionTextBox.Enabled = true;
            addButton.Enabled = true;
            removeChosenFieldButton.Enabled = true;
            ANDradioButton.Enabled = true;
            ORradioButton.Enabled = true;
            delteConditionButton.Enabled = true;
            showQueryButton.Enabled = true ;
        }

        private void DisableIfNoChosenFields()
        {
            chosenFieldComboBox.Enabled = false;
            operatorsComboBox.Enabled = false;
            conditionsListBox.Enabled = false;
            conditionTextBox.Enabled = false;
            addButton.Enabled = false;
            removeChosenFieldButton.Enabled = false;
            ANDradioButton.Enabled = false;
            ORradioButton.Enabled = false;
            delteConditionButton.Enabled = false;
            showQueryButton.Enabled = false;
        }

        private void ClearAll()
        {
            chosenFields = new List<Field>();
            conditions = "";
            allFieldsListBox.Items.Clear();
            chosenFieldslistBox.Items.Clear();
            conditionsListBox.Items.Clear();
            chosenFieldComboBox.Items.Clear();
        }

        private void AddChosenField(string fieldName)
        {
            chosenFields.Add(currentTable.Fields.Find(p => p.Name == fieldName));
        }
        private void DeleteChosenField(string fieldName)
        {
            chosenFields.Remove(currentTable.Fields.Find(p => p.Name == fieldName));
        }

        private void ReplaceField()
        {
            if (allFieldsListBox.SelectedItem != null)
            {
                chosenFieldslistBox.Items.Add(allFieldsListBox.SelectedItem);
                AddChosenField(allFieldsListBox.SelectedItem.ToString());
                allFieldsListBox.Items.Remove(allFieldsListBox.SelectedItem);
                if (allFieldsListBox.Items.Count > 0)
                {
                    allFieldsListBox.SelectedItem = allFieldsListBox.Items[0];
                }
            }
        }

        private void RemoveChosenField()
        {
            if (chosenFieldslistBox.SelectedItem != null) 
            {
                allFieldsListBox.Items.Add(chosenFieldslistBox.SelectedItem);
                DeleteChosenField(chosenFieldslistBox.SelectedItem.ToString());
                chosenFieldslistBox.Items.Remove(chosenFieldslistBox.SelectedItem);
   
            } 
        }

        private void tablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll();
            DisableIfNoChosenFields();
            EnableIfChooseTable();
            currentTable = Program.tables.Find(p => p.Name == tablesComboBox.Text);
            FillAllFields();
        }

        private void chooseFiledButton_Click(object sender, EventArgs e)
        {
            ReplaceField();
            if (chosenFieldslistBox.Items.Count > 0)
            {
                EnableIfHaveChosenField();
            }
            FillChosenFields();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (conditionsListBox.Items.Count > 0) conditions = CreateFullQuery();
            ShowQuery form = new ShowQuery(currentTable, chosenFields, referenceFieldCheckBox.Checked, conditions);
            form.ShowDialog();          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveChosenField();
           
            if (chosenFieldslistBox.Items.Count > 0)
            {
                EnableIfHaveChosenField();
            }
            else
            {
                DisableIfNoChosenFields();
            }
            FillChosenFields();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (chosenFieldComboBox.Text != null && operatorsComboBox.Text != null)
            {
                DrawNewCondition();
            }
        }

        private void delteConditionButton_Click(object sender, EventArgs e)
        {
            if (chosenFieldComboBox.Text != null && operatorsComboBox.Text != null && conditionsListBox.Items.Count > 0)
            {
                conditionsListBox.Items.RemoveAt(conditionsListBox.Items.Count - 1);
            }
        }
    }
}
