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
    class ShowThisBeautifulCharacter
    {
        public ShowThisBeautifulCharacter(Form mf, int rIndex)
        {
            MF = mf;
            IDCard = rIndex.ToString();
            WriteCard();
        }

        private Form MF { get; set; }
        private LabelStyle labelStyle = new LabelStyle();
                
        private string IDCard;

        //DataTable dt;
        //SqlSelect connSel;

        private void WriteCard()
        {
            MF.Controls.Clear();
            //MessageBox.Show("Mess z showCard: " + IDCard);
            InformationSection();
            CharacteristicsSection();
            TalentsSection();
            EqSection();
            CreateBackButton();

        }

        private void InformationSection()
        {
            DataTable dt = new DataTable();
            SqlSelect connSel = new SqlSelect("characterinfo", IDCard);

            dt = connSel.DownloadTable();

            int rowsCount = dt.Rows.Count;
            int colsCount = dt.Columns.Count;

            string[,] chLibrary = new string[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    chLibrary[i,j] = dt.Rows[i][j].ToString();
                    //MessageBox.Show(chLibrary[i,j]+ " "+ rowsCount+" "+colsCount);
                }
            }
            Label[,] Labels = new Label[rowsCount, colsCount];
            for (int r = 0; r < rowsCount; r++)
            {
                for (int c = 0; c < colsCount; c++)
                {
                    Label label = new Label();
                    label.Text = chLibrary[r, c];
                    labelStyle.StyleForInfoElement(label, c+2, r+1);

                    int rIndex = r;
                    //label.Click += (sender, e) => LabelIndexRow_Click(sender, e, rIndex);

                    Labels[r, c] = label;

                    MF.Controls.Add(label);
                }
            }
        }
        private void CharacteristicsSection()
        {
            DataTable dt = new DataTable();
            DataTable deafult_dt = new DataTable();
            SqlSelect connSel;

            connSel = new SqlSelect("relationcharecter", "characteristicsValue", Int32.Parse(IDCard));
            dt = connSel.DownloadTable(); 
            
            connSel = new SqlSelect("charactercharacteristics");
            deafult_dt = connSel.DownloadTable();



            int rowsCount = dt.Rows.Count;
            int colsCount = dt.Columns.Count;

            string[,] chLibrary = new string[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    chLibrary[i, j] = dt.Rows[i][j].ToString();
                    //MessageBox.Show(chLibrary[i, j] + " " + rowsCount + " " + colsCount);
                }
            }

            int deafult_rowsCount = deafult_dt.Rows.Count;
            int deafult_colsCount = deafult_dt.Columns.Count;

            string[,] charValue = new string[deafult_rowsCount, deafult_colsCount];

            for (int i = 0; i < deafult_rowsCount; i++)
            {
                for (int j = 0; j < deafult_colsCount; j++)
                {
                    charValue[i, j] = deafult_dt.Rows[i][j].ToString();
                    //MessageBox.Show(charValue[i,j]);
                }
            }
            Label[,] Labels = new Label[rowsCount, colsCount];
            for (int r = 0; r < rowsCount; r++)
            {
                for (int c = 0; c < colsCount; c++)
                {
                    
                    Label label = new Label();
                    label.Text = charValue[r , 1] + ": "+chLibrary[r, c];
                    labelStyle.StyleForInfoElement(label, r+9, c+1);

                    int rIndex = r;
                    //label.Click += (sender, e) => LabelIndexRow_Click(sender, e, rIndex);

                    Labels[r, c] = label;

                    MF.Controls.Add(label);
                }
            }
        }
        private void TalentsSection()
        {
            DataTable dt = new DataTable();
            DataTable deafult_dt = new DataTable();
            SqlSelect connSel;

            connSel = new SqlSelect("relationtalents", "talentID", Int32.Parse(IDCard));
            dt = connSel.DownloadTable();

            //connSel = new SqlSelect("talents");
            deafult_dt = connSel.DownloadTable();



            int rowsCount = dt.Rows.Count;
            int colsCount = dt.Columns.Count;

            string[,] chLibrary = new string[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    connSel = new SqlSelect("talents", dt.Rows[i][j].ToString(), "a","b","c");
                    deafult_dt = connSel.DownloadTable();
                    chLibrary[i,j] = deafult_dt.Rows[0][j].ToString();
                    
                }
            }
                        
            Label[,] Labels = new Label[rowsCount, colsCount];
            for (int r = 0; r < rowsCount; r++)
            {
                for (int c = 0; c < colsCount; c++)
                {

                    Label label = new Label();
                    label.Text = chLibrary[r, c];
                    labelStyle.StyleForInfoElement(label, r + 2, c + 7);                    

                    Labels[r, c] = label;

                    MF.Controls.Add(label);
                }
            }
        }
        private void EqSection()
        {

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
