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
    class SqlSelect : SqlConnectionManager
    {        
        public SqlSelect(string table, string whatYouWant, string whatToSort)
        {
            selectQuery = $"SELECT {whatYouWant} FROM {table} ORDER BY `{whatToSort}` DESC LIMIT 1";
        } 
        
        public SqlSelect(string table, string whatYouWant1, string whatYouWant2, string whatYouWant3)
        {
            selectQuery = $"SELECT {whatYouWant1} ,{whatYouWant2}, {whatYouWant3}  FROM {table}";
        }
       
        public SqlSelect(string table, string whatYouWant1, int ID)
        {
            selectQuery = $"SELECT {whatYouWant1}  FROM {table} WHERE characterID = {ID}";
        }
        
        public SqlSelect(string table, string ID)
        {
            selectQuery = $"SELECT * FROM {table} WHERE characterID = {ID}";
        }  
        
        public SqlSelect(string table, string ID, string a, string b, string c)
        {
            selectQuery = $"SELECT talentName FROM {table} WHERE talentID = {ID}";
           
        }      
        
        
        public SqlSelect(string table)
        {
            selectQuery = $"SELECT * FROM {table} ";
        }

        public string selectQuery;


        /*public SqlSelect(string table, string name, string otherLikeWeaponTalentETC)
        {
            selectQuery = $"INSERT INTO {table} VALUES(NULL, \"{name}\", \"{otherLikeWeaponTalentETC}\")";
            base.ExecuteSelectQuery(selectQuery);
        }
        public SqlSelect(string table, string name, string race, string profession, string age, string gender)
        {
            selectQuery = $"SELECT* FROM `characterinfo` ORDER BY `characterID` DESC LIMIT 1";
            base.ExecuteSelectQuery(selectQuery);
        }
        */

        public string Mess()
        {
            var dt = ExecuteSelectQuery(selectQuery);
            string mess = "";

            foreach (DataRow row in dt.Rows)
            {
                mess = (string)row["characterID"].ToString();
            }
            return mess;
        }
        public DataTable DownloadTable()
        {
            DataTable dt = new DataTable();
            dt = ExecuteSelectQuery(selectQuery);
            return dt;
        }
    }
}
