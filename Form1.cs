using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace CharacterGeneratorWF
{
    public partial class Form1 : Form
    {
        int globalRIndex;

        public Form1()
        {
            InitializeComponent();
        }    
              
        public void PobierzCharacterInfo(int idCharakter)
        {            
            int osY = 40;

            string[] chInfo = {"Imie", "Rase", "Aktuala profesja", "Poprzednia profesja", "Wiek", "Płeć" };

            string pol = "server=localhost;database=chg;uid=root;password=;";

            string sql = "select name, race, currentProfession, previousProfession, age, gender from characterinfo AS ci, relationcharecter AS rc, charactercharacteristics AS cc WHERE ci.idCharakter = " + idCharakter + " AND ci.idCharakter = rc.idCharacter AND rc.idCharacteristics = cc.idCharacteristics";
            //string sql = "select * from characterinfo Where idCharakter=1";

            MySqlConnection polaczenie = new MySqlConnection(pol);

            DataTable dt = new DataTable();            

            try
            {
                polaczenie.Open();
                using(MySqlCommand cmdSel = new MySqlCommand(sql,polaczenie))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);
                    //dataGridView1.DataSource = dt.DefaultView;      
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException sx)
            {
                MessageBox.Show("Włącz Xampp-a pajacu! a nie się dziwisz, że nie działa >:C");
            }
            polaczenie.Close();

            foreach (DataRow row in dt.Rows)
            {
                string chName = string.Empty;
                foreach (var item in row.ItemArray)
                {
                    chName = item.ToString();

                    Label label = new Label();
                    label.Text =  chName;
                    label.Location = new System.Drawing.Point(250, osY);
                    label.BackColor = System.Drawing.Color.Transparent;
                    label.AutoSize = true;
                    label.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    label.ForeColor = Color.Gray;

                    this.Controls.Add(label);

                    osY += 30;

                }
                
            }
            osY = 40;
            foreach(string info in chInfo)
            {
                Label label = new Label();
                label.Text = info;
                label.Location = new System.Drawing.Point(50, osY);
                label.BackColor = System.Drawing.Color.Transparent;
                label.AutoSize = true;
                label.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                label.ForeColor = Color.Gray;

                this.Controls.Add(label);

                osY += 30;
            }
            
        }
        public void PobierzCharacterCh(int idCharakter)
        {

            int osY = 300;

            string[] chchara = {"WW","US","Kr","Odp","Zr","Int","SW","O","A","Żyw","S","Wyt","Sz","M","PO","PP" };

            string pol = "server=localhost;database=chg;uid=root;password=;";

            string sql = "select weaponSkill, ballisticSkill, strength, toughness, agility, intelligence, willPower, fellowship, attacks, wounds, strengthBonus, toughnessBonus, movement, magic, insanityPoints, fatePoints from characterinfo AS ci, relationcharecter AS rc, charactercharacteristics AS cc WHERE ci.idCharakter = " + idCharakter + " AND ci.idCharakter = rc.idCharacter AND rc.idCharacteristics = cc.idCharacteristics";


            //string sql = "select * from  charactercharacteristics WHERE idCharacteristics = 1";
            //string sql = "select * from characterinfo Where idCharakter=1";

            MySqlConnection polaczenie = new MySqlConnection(pol);

            DataTable dt = new DataTable();

            try
            {
                polaczenie.Open();
                using (MySqlCommand cmdSel = new MySqlCommand(sql, polaczenie))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);
                    //dataGridView1.DataSource = dt.DefaultView;      
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException sx)
            {
                MessageBox.Show("Włącz Xampp-a pajacu! a nie się dziwisz, że nie działa >:C");
            }
            polaczenie.Close();

            foreach (DataRow row in dt.Rows)
            {
                string chName = string.Empty;
                foreach (var item in row.ItemArray)
                {
                    chName = item.ToString();

                    Label label = new Label();
                    label.Text = chName;
                    label.Location = new System.Drawing.Point(250, osY);
                    label.BackColor = System.Drawing.Color.Transparent;
                    label.AutoSize = true;
                    label.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    label.ForeColor = Color.Gray;

                    this.Controls.Add(label);

                    osY += 30;

                }

            }
            osY = 300;
            foreach (string chara in chchara)
            {
                Label label = new Label();
                label.Text = chara;
                label.Location = new System.Drawing.Point(50, osY);
                label.BackColor = System.Drawing.Color.Transparent;
                label.AutoSize = true;
                label.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                label.ForeColor = Color.Gray;

                this.Controls.Add(label);

                osY += 30;
            }

        }
        public void PobierzBiblioteke()
        {

            int osY = 40;

            string[] chInfo = { "ID", "Imie", "Rase", "Aktuala profesja", "Poprzednia profesja", "Wiek", "Płeć" };

            string pol = "server=localhost;database=chg;uid=root;password=;";

            string sql = "select ci.idCharakter, ci.name, ci.race, ci.currentProfession, ci.previousProfession, ci.age, ci.gender from characterinfo AS ci, relationcharecter AS rc, charactercharacteristics AS cc WHERE ci.idCharakter = rc.idCharacter AND rc.idCharacteristics = cc.idCharacteristics";
            //string sql = "select * from characterinfo Where idCharakter=1";

            MySqlConnection polaczenie = new MySqlConnection(pol);

            DataTable dt = new DataTable();

            try
            {
                polaczenie.Open();
                using (MySqlCommand cmdSel = new MySqlCommand(sql, polaczenie))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);
                    //dataGridView1.DataSource = dt.DefaultView;      
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException sx)
            {
                MessageBox.Show("Włącz Xampp-a pajacu! a nie się dziwisz, że nie działa >:C");
            }
            polaczenie.Close();

            int rowsCount = dt.Rows.Count;
            int colsCount = dt.Columns.Count;

            string[,] chLibrary = new string[rowsCount, colsCount];

            for(int i = 0; i < rowsCount; i++)
            {
                for(int j = 0; j < colsCount; j++)
                {
                    chLibrary[i, j] = dt.Rows[i][j].ToString();
                }
            }

            Label[,] Labels = new Label[rowsCount, colsCount];
            for (int r = 0; r < rowsCount; r++)
            {
                for(int c = 0; c < colsCount; c++)
                {
                    Label label = new Label();
                    label.Text = chLibrary[r,c];
                    label.Location = new System.Drawing.Point(20 + c * 200, 20 + r * 35);
                    label.BackColor = System.Drawing.Color.Transparent;
                    label.AutoSize = true;
                    label.Font = new Font("Unispace", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    label.ForeColor = Color.Gray;
                    label.Cursor = Cursors.Hand;

                    int rIndex = r;
                    label.Click += (sender, e) => LabelIndexRow_Click(sender, e, rIndex);

                    Labels[r, c] = label;

                    this.Controls.Add(label);
                }
            }           
        }
       
        public void ButtonBack()
        {
            Label label = new Label();
            label.Text = "Odśwież baze";
            label.AutoSize = true;
            label.Location = new System.Drawing.Point((this.ClientSize.Width / 2 - label.Width / 2), ((this.ClientSize.Height * 90) / 100));
            label.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));

            label.Click += ButtonBack_Click;            
            label.MouseEnter += Button_MouseEnter;

            this.Controls.Add(label);
        }

        public void LabelIndexRow_Click(object sender, EventArgs e, int rIndex)
        {
            MessageBox.Show("Wybrano postać o indexie: " + (rIndex + 1));

            globalRIndex = rIndex;

            this.Controls.Clear();

            PobierzCharacterCh(rIndex + 1);
            PobierzCharacterInfo(rIndex + 1);
            ButtonBack();
        }

        public void ButtonCreate()
        {
            Label label = new Label();
            label.Text = "Dodaj postać";
            label.AutoSize = true;
            label.Location = new System.Drawing.Point((this.ClientSize.Width / 2 - label.Width / 2), ((this.ClientSize.Height * 30) / 100));
            label.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));

            label.Click += ButtonCreate_Click;
            label.MouseEnter += Button_MouseEnter;

            this.Controls.Add(label);
        }

        public void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            ButtonLibrary();
            PobierzBiblioteke();
            ButtonCreate();
        }        
        public void Button_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Cursor = Cursors.Hand;
        }
        public void ButtonLibrary()
        {
            Label label = new Label();
            label.Text = "Biblioteka";
            label.AutoSize = true;
            label.Location = new System.Drawing.Point((this.ClientSize.Width / 2 - label.Width / 2), ((this.ClientSize.Height * 40) / 100));
            label.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));

            label.Click += ButtonLibrary_Click;
            label.MouseEnter += Button_MouseEnter;

            this.Controls.Add(label);
        }
        public void ButtonLibrary_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            PobierzBiblioteke();
           
            ButtonBack();
        }

        public void CreateCharakter()
        {
            this.Controls.Clear();

            string[] chInfo = { "Imie", "Rase", "Aktuala profesja", "Poprzednia profesja", "Wiek", "Płeć" };
            string[] chchara = { "WW", "US", "Kr", "Odp", "Zr", "Int", "SW", "O", "A", "Żyw", "S", "Wyt", "Sz", "M", "PO", "PP" };

            int osY = 40;

            foreach (string info in chInfo)
            {
                Label labelTx = new Label();
                labelTx.Text = info;
                labelTx.Location = new System.Drawing.Point(50, osY);
                labelTx.BackColor = System.Drawing.Color.Transparent;
                labelTx.AutoSize = true;
                labelTx.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                labelTx.ForeColor = Color.Gray;

                this.Controls.Add(labelTx);

                osY += 30;
            }
            osY += 30;

            foreach (string chara in chchara)
            {
                Label labelTx = new Label();
                labelTx.Text = chara;
                labelTx.Location = new System.Drawing.Point(50, osY);
                labelTx.BackColor = System.Drawing.Color.Transparent;
                labelTx.AutoSize = true;
                labelTx.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                labelTx.ForeColor = Color.Gray;

                this.Controls.Add(labelTx);

                osY += 30;
            }

            TextBox[] textBoxes1 = new TextBox[chInfo.Length];

            for (int i = 0; i < chInfo.Length; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Name = chInfo[i];
                textBox.Location = new System.Drawing.Point(380, 40 + i * 30);
                textBox.Size = new System.Drawing.Size(300, 40);

                this.Controls.Add(textBox);
                textBoxes1[i] = textBox;
            }

            TextBox[] textBoxes2 = new TextBox[chchara.Length];

            for (int i = 0; i < chchara.Length; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Name = chchara[i];
                textBox.Location = new System.Drawing.Point(380, 250 + i * 30);
                textBox.Size = new System.Drawing.Size(300, 40);

                this.Controls.Add(textBox);
                textBoxes2[i] = textBox;
            }                      

            Button saveButton = new Button();
            saveButton.Text = "Zapisz";
            saveButton.Location = new System.Drawing.Point(700, 30);

            // Dodawanie obsługi zdarzenia Click dla przycisku zapisu danych
            saveButton.Click += (sender, e) =>
            {
                string connectionString = "server=localhost;user=root;password=;database=chg;";

                string[] data1 = new string[chInfo.Length];
                for (int i = 0; i < chInfo.Length; i++)
                {
                    data1[i] = textBoxes1[i].Text;
                }

                string[] data2 = new string[chchara.Length];
                for (int i = 0; i < chchara.Length; i++)
                {
                    data2[i] = textBoxes2[i].Text;
                }

                string query1 = "INSERT INTO characterinfo (name, race, currentProfession, previousProfession, age, gender) " +
                               "VALUES (@imie, @rasa, @aktualnaProfesja, @poprzedniaProfesja, @wiek, @plec)";

                string query2 = "INSERT INTO charactercharacteristics (weaponSkill, ballisticSkill, strength, toughness, agility, intelligence, willPower, fellowship, attacks, wounds, strengthBonus, toughnessBonus, movement, magic, insanityPoints, fatePoints) " +
                                   "VALUES (@WW, @US, @Kr, @Odp, @Zr, @Int, @SW, @O, @A, @Żyw, @S, @Wyt, @Sz, @M, @PO, @PP)";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query1, connection))
                    {

                        command.Parameters.AddWithValue("@imie", data1[0]);
                        command.Parameters.AddWithValue("@rasa", data1[1]);
                        command.Parameters.AddWithValue("@aktualnaProfesja", data1[2]);
                        command.Parameters.AddWithValue("@poprzedniaProfesja", data1[3]);
                        command.Parameters.AddWithValue("@wiek", data1[4]);
                        command.Parameters.AddWithValue("@plec", data1[5]);

                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Dane zostały zapisane do bazy danych.");
                            }
                            else
                            {
                                MessageBox.Show("Nie udało się zapisać danych do bazy danych.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Wystąpił błąd: " + ex.Message);
                        }
                    }
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@WW",  data2[0]);
                        command.Parameters.AddWithValue("@US",  data2[1]);
                        command.Parameters.AddWithValue("@Kr",  data2[2]);
                        command.Parameters.AddWithValue("@Odp", data2[3]);
                        command.Parameters.AddWithValue("@Zr",  data2[4]);
                        command.Parameters.AddWithValue("@Int", data2[5]);
                        command.Parameters.AddWithValue("@SW",  data2[6]);
                        command.Parameters.AddWithValue("@O",   data2[7]);
                        command.Parameters.AddWithValue("@A",   data2[8]);
                        command.Parameters.AddWithValue("@Żyw", data2[9]);
                        command.Parameters.AddWithValue("@S",   data2[10]);
                        command.Parameters.AddWithValue("@Wyt", data2[11]);
                        command.Parameters.AddWithValue("@Sz",  data2[12]);
                        command.Parameters.AddWithValue("@M",   data2[13]);
                        command.Parameters.AddWithValue("@PO",  data2[14]);
                        command.Parameters.AddWithValue("@PP",  data2[15]);


                        try
                        {

                            connection.Open();


                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Dane zostały zapisane do bazy danych.");
                            }
                            else
                            {
                                MessageBox.Show("Nie udało się zapisać danych do bazy danych.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Wystąpił błąd: " + ex.Message);
                        }
                    }



                }
            };

            this.Controls.Add(saveButton);

            ButtonBack();

        }

        public void ButtonCreate_Click(object sender, EventArgs e)
        {
            CreateCharakter();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            //ButtonBack();
            ButtonLibrary();
            ButtonCreate();
        }
    }
}
