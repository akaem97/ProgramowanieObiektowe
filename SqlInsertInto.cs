using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGeneratorWF
{
    class SqlInsertInto : SqlConnectionManager
    {        
        public SqlInsertInto(string table , string name , string otherLikeWeaponTalentETC)
        {
            insertQuery = $"INSERT INTO {table} VALUES(NULL, '{name}', '{otherLikeWeaponTalentETC}')";
            base.ExecuteNonQuery(insertQuery);
        }

        public SqlInsertInto(string table , string chID , string  charaID, string charaValue)
        {
            insertQuery = $"INSERT INTO {table} VALUES (NULL, '{chID}', '{charaID}', '{charaValue}')";           
            base.ExecuteNonQuery(insertQuery);
        }

        public SqlInsertInto(string table , string name , string race, string profession, string age, string gender)
        {
            insertQuery = $"INSERT INTO {table} VALUES(NULL, '{name}', '{race}', '{profession}', '{age}', '{gender}')";
            base.ExecuteNonQuery(insertQuery);
        }

        public string insertQuery;      
       
    }
}
