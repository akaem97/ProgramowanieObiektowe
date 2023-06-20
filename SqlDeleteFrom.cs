using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace CharacterGeneratorWF
{
    class SqlDeleteFrom : SqlConnectionManager
    {
        public SqlDeleteFrom(string ID)
        {
            foreach (string t in tables)
            {
                deleteQuery = $"DELETE FROM {t} WHERE characterID ={ID}";
                //MessageBox.Show(deleteQuery);
                base.ExecuteNonQuery(deleteQuery);
            }
        }
        public string deleteQuery;

        private string[] tables = { "characterinfo", 
            "relationarmor",
            "relationcharecter", 
            "relationequipment", 
            "relationtalents", 
            "relationweapon" };


    }
}
