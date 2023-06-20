using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CharacterGeneratorWF
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new MainForm());           

        }
    }
    public class MainForm : Form
    {
        public MainForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            Size = new System.Drawing.Size(1920, 1080);            
            //WindowState = FormWindowState.Maximized;
            
            /*SqlConnectionManager CM = new SqlConnectionManager("localhost", "chg", "root", "");
            string selectQ = "SELECT * From characterinfo";

            var dt = CM.ExecuteQuery(selectQ);

            String mess = "";
            foreach(DataRow row in dt.Rows)
            {
                mess += $"ID:   {row["characterID"]}, " +
                    $"Name:     {row["name"]}, " +
                    $"Race:     {row["race"]}, " +
                    $"CP:       {row["currentProfession"]}, " +
                    $"PP:       {row["previousProfession"]}, " +
                    $"Age:      {row["age"]}," +
                    $"Gender:   {row["gender"]}\n";
            }
            //MessageBox.Show(mess, "Wyniki SELECT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
            AddTalent Talent = new AddTalent(this);
            Talent.Button();
            AddWeapon Weapon = new AddWeapon(this);
            Weapon.Button();
            AddEquipment Equipment = new AddEquipment(this);
            Equipment.Button();
            AddArmor Armor = new AddArmor(this);
            Armor.Button();
            AddCharacter Character = new AddCharacter(this);
            Character.Button();
            LookAtTheBeautifulLibrary Library = new LookAtTheBeautifulLibrary(this);
            Library.Button();
    
        }
    }

}
