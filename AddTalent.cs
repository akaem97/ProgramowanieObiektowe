using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGeneratorWF
{
    public class AddTalent
    {
        private Form MF { get; set; }

        private LabelStyle labelStyle = new LabelStyle();
        private TextboxStyle textboxStyle = new TextboxStyle();        

        private TextBox talentContentBox;
        private TextBox talentNameBox;

        private int talentNameWidth;

        public AddTalent(Form mF)
        {
            MF = mF;
        }

        public void Button()
        {
            Label addTalent = new Label();
            addTalent.Text = "Dodaj umiejętność do puli";
            labelStyle.StyleForButton(addTalent);
            MF.Controls.Add(addTalent);

            addTalent.Click += WriteTalent;

            addTalent.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addTalent.Width / 2), ((MF.ClientSize.Height * 90) / 100));             
        }

        private void WriteTalent(object sender, EventArgs e)
        {
            MF.Controls.Clear();
            LabeLCreateTalentName();
            TextboxCreateTalentName();
            LabelCreateTalentContent();
            TextboxCreateTalentContent();
            CreateButtonToAddToTable();
            CreateBackButton();
        }
        private void LabeLCreateTalentName()
        {
            int X = 120;
            int Y = 150;
            Label talentName = new Label();
            talentName.Text = "Podaj nazwę umiejętności: ";
            labelStyle.StyleForText(talentName);
            MF.Controls.Add(talentName);

            talentName.Location = new System.Drawing.Point(X, Y);

            talentNameWidth = talentName.Width+ X;            
        }
        private void TextboxCreateTalentName()
        {          
            talentNameBox = new TextBox();
            textboxStyle.StyleForTextbox(talentNameBox);
            MF.Controls.Add(talentNameBox);

            talentNameBox.Location = new System.Drawing.Point(talentNameWidth, 150);
        }
        private void LabelCreateTalentContent() 
        {
            int X = 120;
            int Y = 200;

            Label talentContent = new Label();
            talentContent.Text = "Podaj opis umiejętności: ";
            labelStyle.StyleForText(talentContent);
            MF.Controls.Add(talentContent);

            talentContent.Location = new System.Drawing.Point(X, Y);
        }
        private void TextboxCreateTalentContent() 
        {          
            talentContentBox = new TextBox();            
            textboxStyle.StyleForTextbox(talentContentBox);           
            MF.Controls.Add(talentContentBox);

            talentContentBox.Location = new System.Drawing.Point(talentNameWidth, 200);            
        }        
        private void CreateButtonToAddToTable() 
        {
            Label addToTable = new Label();
            addToTable.Text = "Dodaj do puli";
            labelStyle.StyleForButton(addToTable);

            addToTable.Click += AddContentToTable;
            
            MF.Controls.Add(addToTable);
            addToTable.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addToTable.Width / 2), ((MF.ClientSize.Height * 80) / 100));                 
        }
        private void AddContentToTable(object sebder, EventArgs e)
        {
            SqlInsertInto connMeg = new SqlInsertInto("talents", talentNameBox.Text, talentContentBox.Text);            
            WriteTalent(this, e);            
        }
        private void CreateBackButton() 
        {
            Label backButton = new Label();
            backButton.Text = "Powrót";
            labelStyle.StyleForButton(backButton);

            MF.Controls.Add(backButton);
            backButton.Location= new System.Drawing.Point((MF.ClientSize.Width / 2 - backButton.Width / 2), ((MF.ClientSize.Height * 90) / 100));

            backButton.Click += BackToMenu;
        }
        private void BackToMenu(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
    