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
    class LookAtTheBeautifulLibrary
    {
        public LookAtTheBeautifulLibrary(Form mf)
        {
            MF = mf;
        }

        private Form MF { get; set; }
        private LabelStyle labelStyle = new LabelStyle();
        private TextboxStyle textboxStyle = new TextboxStyle();

        public void Button()
        {
            Label addEquipment = new Label();
            addEquipment.Text = "Biblioteka";
            labelStyle.StyleForButton(addEquipment);
            MF.Controls.Add(addEquipment);

            addEquipment.Click += WriteLibrary;

            addEquipment.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addEquipment.Width / 2), ((MF.ClientSize.Height * 45) / 100));
        }

        private void WriteLibrary(object sender, EventArgs e)
        {
            MF.Controls.Clear();
            ShowLibrary();

            CreateBackButton();
        }
        private void ShowLibrary()
        {
            DataTable dt = new DataTable();
            SqlSelect connSel = new SqlSelect("characterinfo", "characterID", "name", "currentProfession");
            dt = connSel.DownloadTable();

            int rowsCount = dt.Rows.Count;
            int colsCount = dt.Columns.Count;

            string[,] chLibrary = new string[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    chLibrary[i, j] = dt.Rows[i][j].ToString();  
                }
            }

            Label[,] Labels = new Label[rowsCount, colsCount];
            for (int r = 0; r < rowsCount; r++)
            {
                for (int c = 0; c < colsCount; c++)
                {
                    Label label = new Label();
                    label.Text = chLibrary[r, c];
                    labelStyle.StyleForLibraryElement(label , c , r);                    

                    int rIndex = Int32.Parse(chLibrary[r, 0]);
                    label.Click += (sender, e) => LabelIndexRow_Click(sender, e, rIndex);

                    //Labels[r, c].Text = chLibrary[r,0].ToString();
                    

                    MF.Controls.Add(label);
                }
            }

        }
        private void LabelIndexRow_Click(object sender, EventArgs e, int rIndex)
        {
            DialogResult result = MessageBox.Show("Co chcesz zrobić? \n\nTak oznacza Pokaż postać.\nNie oznacza Usuń postać. ", "Potwierdzenie", MessageBoxButtons.YesNo);


            if (result == DialogResult.Yes)
            {                
                ShowThisBeautifulCharacter CharacterCard = new ShowThisBeautifulCharacter(MF, rIndex);
            }
            else if (result == DialogResult.No)
            {                
                SqlDeleteFrom connDele = new SqlDeleteFrom(rIndex.ToString());
                WriteLibrary(sender , e);
            }
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
