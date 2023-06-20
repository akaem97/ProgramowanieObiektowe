using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGeneratorWF
{
    public class AddCharacter
    {
        private Form MF { get; set; }              

        private LabelStyle labelStyle = new LabelStyle();
        private TextboxStyle textboxStyle = new TextboxStyle();

        private TextBox chNameBox;
        private TextBox chRaceBox;
        private TextBox chProfessionBox;
        private TextBox chAgeBox;
        private TextBox chGenderBox;

        private int chProfessionWidth;

        public AddCharacter(Form mF)
        {
            MF = mF;
        }

        public void Button()
        {
            Label addCharacter = new Label();
            addCharacter.Text = "Stwórz postać";
            labelStyle.StyleForButton(addCharacter);
            MF.Controls.Add(addCharacter);

            addCharacter.Click += WriteCharacter;

            addCharacter.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addCharacter.Width / 2), ((MF.ClientSize.Height * 40) / 100));
        }

        public void WriteCharacter(object sender, EventArgs e)
        {
            MF.Controls.Clear();

            LabeLCreateName();
            LabelCreateRace();
            LabelCreateCurrentProfession();
            LabelCreateAge();
            LabelCreateGender();

            TextboxName();
            TextboxRace();
            TextboxProfession();
            TextboxAge();
            TextboxGender();
            
            CreateButtonToAddToTable();
            CreateBackButton();
        }
        private void LabeLCreateName()
        {
            int X = 120;
            int Y = 150;
            Label chName = new Label();
            chName.Text = "Podaj Imię: ";
            labelStyle.StyleForText(chName);
            MF.Controls.Add(chName);

            chName.Location = new System.Drawing.Point(X, Y);
            
        }
        private void LabelCreateRace()
        {
            int X = 120;
            int Y = 200;

            Label chRace = new Label();
            chRace.Text = "Podaj rase: ";
            labelStyle.StyleForText(chRace);
            MF.Controls.Add(chRace);

            chRace.Location = new System.Drawing.Point(X, Y);
        }
        private void LabelCreateCurrentProfession()
        {
            int X = 120;
            int Y = 250;

            Label chProfession = new Label();
            chProfession.Text = "Podaj profesję: ";
            labelStyle.StyleForText(chProfession);
            MF.Controls.Add(chProfession);

            chProfession.Location = new System.Drawing.Point(X, Y);

            chProfessionWidth = chProfession.Width + X;
        }
        private void LabelCreateAge()
        {
            int X = 120;
            int Y = 300;

            Label chAge = new Label();
            chAge.Text = "Podaj wiek: ";
            labelStyle.StyleForText(chAge);
            MF.Controls.Add(chAge);

            chAge.Location = new System.Drawing.Point(X, Y);
        }
        private void LabelCreateGender()
        {
            int X = 120;
            int Y = 350;

            Label chGender = new Label();
            chGender.Text = "Podaj płeć: ";
            labelStyle.StyleForText(chGender);
            MF.Controls.Add(chGender);

            chGender.Location = new System.Drawing.Point(X, Y);
        }

        private void TextboxName()
        {
            chNameBox = new TextBox();
            textboxStyle.StyleForTextbox(chNameBox);
            MF.Controls.Add(chNameBox);

            chNameBox.Location = new System.Drawing.Point(chProfessionWidth, 150);
        }     
        private void TextboxRace()
        {
            chRaceBox = new TextBox();
            textboxStyle.StyleForTextbox(chRaceBox);
            MF.Controls.Add(chRaceBox);

            chRaceBox.Location = new System.Drawing.Point(chProfessionWidth, 200);
        }
        private void TextboxProfession()
        {
            chProfessionBox = new TextBox();
            textboxStyle.StyleForTextbox(chProfessionBox);
            MF.Controls.Add(chProfessionBox);

            chProfessionBox.Location = new System.Drawing.Point(chProfessionWidth, 250);
        }
        private void TextboxAge()
        {
            chAgeBox = new TextBox();
            textboxStyle.StyleForTextbox(chAgeBox);
            MF.Controls.Add(chAgeBox);

            chAgeBox.Location = new System.Drawing.Point(chProfessionWidth, 300);
        }
        private void TextboxGender()
        {
            chGenderBox = new TextBox();
            textboxStyle.StyleForTextbox(chGenderBox);
            MF.Controls.Add(chGenderBox);

            chGenderBox.Location = new System.Drawing.Point(chProfessionWidth, 350);
        }

        private void CreateButtonToAddToTable()
        {
            Label addToTable = new Label();
            addToTable.Text = "Dalej";
            labelStyle.StyleForButton(addToTable);

            addToTable.Click += AddContentToTable;

            MF.Controls.Add(addToTable);
            addToTable.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addToTable.Width / 2), ((MF.ClientSize.Height * 80) / 100));
        }
        private void AddContentToTable(object sebder, EventArgs e)
        {
            SqlInsertInto connMeg = new SqlInsertInto("characterinfo", chNameBox.Text, chRaceBox.Text, chProfessionBox.Text, chAgeBox.Text, chGenderBox.Text);
            SqlSelect connSel = new SqlSelect("characterinfo", "characterID", "characterID");           

            AddCharacteristics characteristics = new AddCharacteristics(MF);
            characteristics.WriteCharacteristics(connSel.Mess());


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
