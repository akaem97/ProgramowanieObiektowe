using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CharacterGeneratorWF
{
    abstract public class SqlConnectionManager
    {
        private readonly string connectionString;

        public SqlConnectionManager(string server = "localhost", string db = "chg" , string ur = "root", string pw = "")
        {
            this.connectionString = $"server   = {server};" +
                $"               database = {db};" +
                $"               uid      = {ur};" +
                $"               password = {pw}";
        }     
        public DataTable ExecuteSelectQuery(string query) //metoda dla zapytań typu SELECT
        {
            using(var conn = new MySqlConnection(connectionString))
            {
                var dataTable = new DataTable();
                try
                {
                    conn.Open();

                    using (var command = new MySqlCommand(query , conn))
                    {
                        var adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
                catch(Exception ex)
                {
                    GenericErrorMessege(ex);
                }

                return dataTable;
            }         
        }        
        public void ExecuteNonQuery(string query) //metoda dla zapytań typu UPDATE, INSERT, DELETE
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    GenericErrorMessege(ex);
                }
            }
        }
        public void InfoBox()
        {
            MessageBox.Show(connectionString);
        }
        private void GenericErrorMessege(Exception ex)
        {
            MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }      
    }
}
