using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace CharacterGeneratorWF
{
    class AddTalentToCharacter
    {
        public AddTalentToCharacter(Form mF)
        {
            MF = mF;
        }
        private Form MF { get; set; }

        private LabelStyle labelStyle = new LabelStyle();
        private TextboxStyle textboxStyle = new TextboxStyle();

        Label talentContent;
        TextBox tbHowManyObject;

        int X = 120;
        int Y = 150;
        int talentNameWidth;

        string IDItem;

        string[,] chTalent;
        string[] chTalent_helper;

        string IDCard;

        private ComboBox comboBox1;

        public void WriteTalent(string ID)
        {
            IDCard = ID;
            MF.Controls.Clear();
            DownloadTalents();
            LabeLAddTalentName();
            LabeLAddTalentContent();
            //TextboxHowManyObjects();
            CreateButtonToAddToTable();
                
              
            CreateComboBox();
            CreateBackButton();
             
        }
        private void DownloadTalents()
        {
            DataTable dt = new DataTable();
            SqlSelect connSel = new SqlSelect("talents");

            dt = connSel.DownloadTable();

            int rowsCount = dt.Rows.Count;
            int colsCount = dt.Columns.Count;

            chTalent_helper = new string[rowsCount];
            chTalent = new string[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    chTalent[i,j] = dt.Rows[i][j].ToString();                    
                }
                chTalent_helper[i] = chTalent[i, 1];
                
            }
        }
        private void LabeLAddTalentName()
        {
            
            Label talentName = new Label();
            talentName.Text = "Posiadana umiejętność: ";
            labelStyle.StyleForText(talentName);
            MF.Controls.Add(talentName);

            talentName.Location = new System.Drawing.Point(X, Y);

            talentNameWidth = talentName.Width + X;
        }
        private void LabeLAddTalentContent()
        {
            
            talentContent = new Label();
            talentContent.Text = "";
            labelStyle.StyleForText(talentContent);
            MF.Controls.Add(talentContent);

            talentContent.Location = new System.Drawing.Point(X, Y+40);            
        }
        private void CreateComboBox()
        {
            comboBox1 = new ComboBox();
            comboBox1.Font = new Font("Unispace", 20, FontStyle.Bold);
            //tb.BackColor = Color.Gray;
            comboBox1.Padding = new Padding(5);
            //comboBox1.TextAlign = HorizontalAlignment.Center;
            comboBox1.Size = new Size(400, 45);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Opcjonalnie, aby uniemożliwić wprowadzanie wartości
            comboBox1.Location = new System.Drawing.Point(X + talentNameWidth, Y);

            comboBox1.Items.AddRange(chTalent_helper);

            comboBox1.SelectedIndexChanged += CMSelectedIndexChanged;

            // Dodaj ComboBox do formularza
            MF.Controls.Add(comboBox1);
        }
        private void CMSelectedIndexChanged(object sendet, EventArgs e)
        {
            string chosenText = chTalent[comboBox1.SelectedIndex , 2];
            IDItem = chTalent[comboBox1.SelectedIndex , 0];
           //MessageBox.Show(IDItem);
            talentContent.Text = chosenText;
        }
        /*private void TextboxHowManyObjects()
        {
            tbHowManyObject = new TextBox();
            textboxStyle.StyleForTextbox(tbHowManyObject);
            MF.Controls.Add(tbHowManyObject);

            tbHowManyObject.Location = new System.Drawing.Point(1100, Y);
        }*/
        private void CreateButtonToAddToTable()
        {
            Label addToTable = new Label();
            addToTable.Text = "Dodaj";
            labelStyle.StyleForButton(addToTable);

            addToTable.Click += AddContentToTable;

            MF.Controls.Add(addToTable);
            addToTable.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addToTable.Width / 2), ((MF.ClientSize.Height * 80) / 100));
        }
        private void AddContentToTable(object sebder, EventArgs e)
        {
            SqlInsertInto connMeg = new SqlInsertInto("relationtalents", IDCard, IDItem);
            //SqlSelect connSel = new SqlSelect("characterinfo", "characterID", "characterID");

            //AddCharacteristics characteristics = new AddCharacteristics(MF);
            //characteristics.WriteCharacteristics(connSel.Mess());
            WriteTalent(IDCard);


            //WriteCharacter(this, e);
        }

        private void CreateBackButton()
        {
            Label backButton = new Label();
            backButton.Text = "Powrót";
            labelStyle.StyleForButton(backButton);

            MF.Controls.Add(backButton);
            backButton.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - backButton.Width / 2), ((MF.ClientSize.Height * 90) / 100));

            backButton.Click += BackToMenu;
        }        
        private void BackToMenu(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
