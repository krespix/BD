using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace BD
{
    public class Database
    {
        private string path;
        private SqliteConnection connection;

        public List<Table> tables;
        public Database(string Source)
        {
            this.path = Source;
            this.connection = new SqliteConnection($"Data Source={this.path}");
            this.tables = new List<Table>();
            this.fillTables();
        }
        private void fillTables()
        {
            this.connection.Open();
            string sql = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY name;";

            SqliteCommand command = new SqliteCommand();

            command.Connection = this.connection;
            command.CommandText = sql;

            List<string> tables = new List<string>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var name = reader.GetString(i);
                        if (name != "sqlite_sequence") tables.Add(name);
                    }
                }
            }

            foreach (string tableName in tables)
            {
                command = new SqliteCommand();

                command.Connection = this.connection;
                command.CommandText = $"PRAGMA table_info('{tableName}');";

                Table table = new Table(tableName, new List<Field>());
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Name = reader.GetString(reader.GetOrdinal("name"));
                        string Type = reader.GetString(reader.GetOrdinal("type"));

                        bool PrimaryKey = reader.GetString(reader.GetOrdinal("pk")) == "1";
                        bool NotNull = reader.GetString(reader.GetOrdinal("notnull")) == "1";

                        bool AutoIncrement = false;
                        bool Unic = PrimaryKey;

                        Field field = new Field(Name, Type, NotNull, PrimaryKey, AutoIncrement, Unic);
                        table.Fields.Add(field);

                        if (PrimaryKey) table.PrimaryField = field;
                    }
                }
                this.tables.Add(table);
            }

            foreach (Table table in this.tables)
            {

                command = new SqliteCommand();

                command.Connection = this.connection;
                command.CommandText = $"PRAGMA foreign_key_list('{table.Name}');";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string fromTableName = reader.GetString(reader.GetOrdinal("table"));
                        string fromFieldName = reader.GetString(reader.GetOrdinal("from"));
                        string toFieldName = reader.GetString(reader.GetOrdinal("to"));

                        foreach (Field field in table.Fields)
                        {
                            if (field.Name == fromFieldName)
                            {
                                foreach (Table tbl1 in this.tables)
                                {
                                    if (tbl1.Name == fromTableName)
                                    {
                                        foreach (Field fld1 in tbl1.Fields)
                                        {
                                            if (fld1.Name == toFieldName)
                                            {
                                                field.Foreign = new Foreign(tbl1, fld1);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }

                    }
                }
            }
            try
            {
                command = new SqliteCommand();

                command.Connection = this.connection;
                command.CommandText = $"select name from sqlite_sequence;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        foreach (Table table in this.tables)
                        {
                            if (table.Name == name)
                            {
                                table.PrimaryField.AutoInc = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            this.connection.Close();
        }
        private void InsertSequence(Table table)
        {
            this.connection.Open();

            var command = new SqliteCommand();

            command.Connection = this.connection;
            command.CommandText = $"INSERT INTO sqlite_sequence (name, seq) VALUES ('{table.Name}', 0);";

            command.ExecuteReader();

            this.connection.Close();
        }
        private string BaseSelectCommandText(string tableName, List<Field> fields)
        {
            string fieldsString = String.Join(", ", fields.Select(field => tableName + '.' + field.Name).ToArray());
            return string.Format(@"
                        SELECT {0}
                        FROM '{1}'
                    ", fieldsString, tableName);
        }
        private string BaseInnerJoinText(string tableName, List<Field> fields)
        {
            string result = "";
            foreach (Field field in fields)
            {
                if (field.Foreign == null) continue;
                result += $" INNER JOIN {field.Foreign.toTable.Name} ON {field.Foreign.toTable.Name}.{field.Foreign.toField.Name} = {tableName}.{field.Name}";
            }
            return result;
        }
        public List<List<string>> Select(Table table, List<Field> fields, bool addInner = false)
        {
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            string baseSelect = this.BaseSelectCommandText(table.Name, fields);

            if (addInner) baseSelect += this.BaseInnerJoinText(table.Name, table.Fields);

            command.CommandText = baseSelect;

            List<List<string>> result = new List<List<string>>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    List<string> tmp = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string name = "";
                        try
                        {
                            name = reader.GetString(i);
                        }
                        catch (Exception)
                        {
                            name = "NULL";
                        }
                        tmp.Add(name);
                    }
                    result.Add(tmp);
                }
            }

            this.connection.Close();
            return result;
        }
        public List<List<string>> Select(Table table, bool addInner = false)
        {
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            string baseSelect = $"SELECT * FROM '{table.Name}'";

            if (addInner) baseSelect += this.BaseInnerJoinText(table.Name, table.Fields);

            command.CommandText = baseSelect;

            List<List<string>> result = new List<List<string>>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    List<string> tmp = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string name = "";
                        try
                        {
                            name = reader.GetString(i);
                        }
                        catch (Exception)
                        {
                            name = "NULL";
                        }
                        tmp.Add(name);
                    }
                    result.Add(tmp);
                }
            }

            this.connection.Close();
            return result;
        }

        public List<List<string>> Select(Table table, string whereParams, bool addInner = false)
        {
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            string baseSelect = $"SELECT * FROM '{table.Name}'";

            if (addInner) baseSelect += this.BaseInnerJoinText(table.Name, table.Fields);

            baseSelect += $" WHERE {whereParams}";

            command.CommandText = baseSelect;

            List<List<string>> result = new List<List<string>>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    List<string> tmp = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string name = "";
                        try
                        {
                            name = reader.GetString(i);
                        }
                        catch (Exception)
                        {
                            name = "NULL";
                        }
                        tmp.Add(name);
                    }
                    result.Add(tmp);
                }
            }

            this.connection.Close();
            return result;
        }

        public List<List<string>> Select(Table table, List<Field> fields, string whereParams, bool addInner = false)
        {
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            string baseSelect = this.BaseSelectCommandText(table.Name, fields);

            if (addInner) baseSelect += this.BaseInnerJoinText(table.Name, table.Fields);

            baseSelect += $" WHERE {whereParams}";

            command.CommandText = baseSelect;

            List<List<string>> result = new List<List<string>>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    List<string> tmp = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string name = "";
                        try
                        {
                            name = reader.GetString(i);
                        }
                        catch (Exception)
                        {
                            name = "NULL";
                        }
                        tmp.Add(name);
                    }
                    result.Add(tmp);
                }
            }

            this.connection.Close();
            return result;
        }
        public void Insert(Table table)
        {
            string baseInsert = "INSERT INTO '" + table.Name + "' ";
            string cols = "(";
            string values = "VALUES (";

            foreach (Field field in table.Fields)
            {
                if (field.AutoInc) continue;

                cols += "'" + field.Name + "', ";
                values += field.getValue() + ", ";
            }

            cols = cols.Remove(cols.Length - 2);
            values = values.Remove(values.Length - 2);

            cols += ") ";
            values += ")";
            baseInsert += cols + values + ";";

            this.connection.Open();

            SqliteCommand command = new SqliteCommand();

            command.Connection = this.connection;
            command.CommandText = baseInsert;

            command.ExecuteReader();

            this.connection.Close();
        }
        public void Create(Table table)
        {
            string baseCreate = $"CREATE TABLE IF NOT EXISTS '{table.Name}' (";

            foreach (Field field in table.Fields)
            {
                baseCreate += field.getParams() + ",";
            }

            baseCreate += $" PRIMARY KEY(\"{table.PrimaryField.Name}\"";

            if (table.PrimaryField.AutoInc) baseCreate += " AUTOINCREMENT";

            baseCreate += "));";

            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            command.CommandText = baseCreate;

            command.ExecuteReader();
            this.connection.Close();

            if (table.PrimaryField.AutoInc)
            {
                // foreach (Field fld in table.Fields)
                // {
                //     fld.Value = "1";
                // }
                // table.PrimaryField.Value = "1";
                // this.Insert(table);
                // this.Delete(table);
                this.InsertSequence(table);
            }
        }
        public void Update(Table table)
        {
            string baseUpdate = "UPDATE '" + table.Name + "' SET ";
            foreach (Field field in table.Fields)
            {
                if (field.AutoInc) continue;
                baseUpdate += $"{field.Name}={field.getValue()}, ";
            }

            baseUpdate = baseUpdate.Remove(baseUpdate.Length - 2);

            baseUpdate += $" WHERE {table.PrimaryField.Name}={table.PrimaryField.getValue()};";

            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            command.CommandText = baseUpdate;

            command.ExecuteReader();
            this.connection.Close();
        }
        public void Delete(Table table)
        {
            string baseDelete = "DELETE FROM '" + table.Name + "' ";
            baseDelete += $"WHERE {table.PrimaryField.Name}={table.PrimaryField.getValue()};";
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            command.CommandText = baseDelete;

            command.ExecuteReader();
            this.connection.Close();
        }

        public void RenameTable(string oldName, string newName)
        {
            string baseRename = $"ALTER TABLE '{oldName}' RENAME TO '{newName}';";
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            command.CommandText = baseRename;

            command.ExecuteReader();
            this.connection.Close();
        }

        public void RenameColumn(string tableName, string oldName, string newName)
        {
            string baseRename = $"ALTER TABLE '{tableName}' RENAME COLUMN '{oldName}' TO '{newName}';";
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            command.CommandText = baseRename;

            command.ExecuteReader();
            this.connection.Close();
        }

        public void DropTable(string tableName)
        {
            string baseDrop = $"DROP TABLE '{tableName}';";
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            command.CommandText = baseDrop;

            command.ExecuteReader();
            this.connection.Close();
        }

        public void AddColumn(string tableName, Field field)
        {
            string baseAdd = $"ALTER TABLE '{tableName}' ADD COLUMN {field.Name} {field.Type}";
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            command.CommandText = baseAdd;

            command.ExecuteReader();
            this.connection.Close();
        }

        public void DropColumn(Table table, Field dropColumn)
        {
            if (table.PrimaryField == dropColumn) return;

            string oldName = table.Name;
            table.Name += "__tmp";
            table.Fields.Remove(dropColumn);

            string fields = "";
            foreach (Field field in table.Fields)
            {
                fields += field.Name + ", ";
            }
            fields = fields.Remove(fields.Length - 2);

            string baseDrop = $"CREATE TABLE '{table.Name}' AS SELECT {fields} FROM '{oldName}'; DROP TABLE '{oldName}'; ALTER TABLE '{table.Name}' RENAME TO '{oldName}';";
            this.connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = this.connection;

            command.CommandText = baseDrop;

            command.ExecuteReader();

            table.Name = oldName;
            this.connection.Close();
        }
    }

    public class Foreign
    {
        public Table toTable;
        public Field toField;

        public Foreign(Table toTable, Field toName)
        {
            this.toTable = toTable;
            this.toField = toName;
        }
    }

    public class Field
    {
        public string Name;
        public string Type;
        public bool NotNull;
        public bool PrimaryKey;
        public bool AutoInc;
        public bool Unic;
        public string Value;
        public Foreign Foreign;

        public Field(string name, string type, bool notNull, bool primaryKey, bool autoInc, bool unic)
        {
            Name = name;
            Type = type;
            NotNull = notNull;
            PrimaryKey = primaryKey;
            AutoInc = autoInc;
            Unic = unic;
        }

        public string getParams()
        {
            string result = "\"" + Name + "\" ";
            result += Type + " ";
            if (NotNull) result += "NOT NULL ";
            if (Unic) result += "UNIQUE ";
            if (Foreign != null) result += $"references {Foreign.toTable.Name}({Foreign.toField.Name})  ON DELETE CASCADE ON UPDATE CASCADE";
            return result;
        }

        public string getValue()
        {
            if (Type == "TEXT") return "\"" + Value + "\"";
            return Value;
        }
    }

    public class Table
    {
        public string Name;
        public Field PrimaryField;
        public List<Field> Fields;
        public Table()
        {
            Fields = new List<Field>();
        }
        public Table(string name, List<Field> fields, Field primaryField)
        {
            Name = name;
            Fields = fields;
            PrimaryField = primaryField;
        }

        public Table(string name, List<Field> fields)
        {
            Name = name;
            Fields = fields;
        }
    }
}
