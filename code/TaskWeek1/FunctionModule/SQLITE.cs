using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace TaskWeek1.FunctionModule
{
    class SQLITE
    {
        private SQLiteConnectionStringBuilder str;
        private String tableName;

        public SQLITE(String DBName)
        {
            str = new SQLiteConnectionStringBuilder();//声明数据库连接字符串
            str.DataSource = System.String.Format(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "{0}.sqlite3"), DBName);
        }

        public String TableName
        {
            set
            {
                tableName = value;
            }
        }

        public void createTable()
        {
            using(var con = new SQLiteConnection(str.ConnectionString))
            {
                con.Open();//连接数据库
                using (var cmd = new SQLiteCommand(con))
                {
                    String cmdString = System.String.Format("create table if not exists {0} (id text primary key, password text);",tableName);
                    cmd.CommandText = cmdString;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void insertData(String[] data)
        {
            using (var con = new SQLiteConnection(str.ConnectionString))
            {
                con.Open();//连接数据库
                using (var cmd = new SQLiteCommand(con))
                {
                    String cmdString = System.String.Format("INSERT INTO {0} (id, password) VALUES ('{1}', '{2}');", tableName, data[0], data[1]);
                    cmd.CommandText = cmdString;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public String selectData(String[] data)
        {
            String password = "";
            using (var con = new SQLiteConnection(str.ConnectionString))
            {
                con.Open();//连接数据库
                using (var cmd = new SQLiteCommand(con))
                {
                    String cmdString = System.String.Format("SELECT password FROM {0} WHERE id = '{1}'", tableName, data[0]);
                    cmd.CommandText = cmdString;
                    SQLiteDataReader read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        password = read.GetString(0);
                    }
                }
                con.Close();
            }
            return password;
        }

        public void updateData(String[] data, string newPassword)
        {
            using (var con = new SQLiteConnection(str.ConnectionString))
            {
                con.Open();//连接数据库
                using (var cmd = new SQLiteCommand(con))
                {
                    String cmdString = String.Format("UPDATE {0} SET password = '{1}' WHERE id = '{2}'", tableName, newPassword, data[0]);
                    cmd.CommandText = cmdString;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

    }
    /*此API使用方法
         1、SQLITE x = new SQLITE(String DBName)
     * 2、x.TableName = ...
     * 3、createTable()...
         */
}
