using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGeneratorWF
{
    class AddArmor
    {
        private Form MF { get; set; }

        private LabelStyle labelStyle = new LabelStyle();
        private TextboxStyle textboxStyle = new TextboxStyle();

        private TextBox armorProtectionBox;
        private TextBox armorNameBox;

        private int armorNameWidth;

        public AddArmor(Form mF)
        {
            MF = mF;
        }

        public void Button()
        {
            Label addArmor = new Label();
            addArmor.Text = "Dodaj pancerza do puli";
            labelStyle.StyleForButton(addArmor);
            MF.Controls.Add(addArmor);

            addArmor.Click += WriteArmor;

            addArmor.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addArmor.Width / 2), ((MF.ClientSize.Height * 75) / 100));
        }

        private void WriteArmor(object sender, EventArgs e)
        {
            MF.Controls.Clear();
            LabeLCreateArmorName();
            TextboxCreateArmorName();
            LabelCreateArmorProtection();
            TextboxCreateArmorProtection();
            CreateButtonToAddToTable();
            CreateBackButton();
        }
        private void LabeLCreateArmorName()
        {
            int X = 120;
            int Y = 150;
            Label armorName = new Label();
            armorName.Text = "Podaj nazwę pancerza: ";
            labelStyle.StyleForText(armorName);
            MF.Controls.Add(armorName);

            armorName.Location = new System.Drawing.Point(X, Y);

            armorNameWidth = armorName.Width + X;
        }
        private void TextboxCreateArmorName()
        {
            armorNameBox = new TextBox();
            textboxStyle.StyleForTextbox(armorNameBox);
            MF.Controls.Add(armorNameBox);

            armorNameBox.Location = new System.Drawing.Point(armorNameWidth, 150);
        }
        private void LabelCreateArmorProtection()
        {
            int X = 120;
            int Y = 200;

            Label armorProtection = new Label();
            armorProtection.Text = "Podaj ochrone pancerza: ";
            labelStyle.StyleForText(armorProtection);
            MF.Controls.Add(armorProtection);

            armorProtection.Location = new System.Drawing.Point(X, Y);
        }
        private void TextboxCreateArmorProtection()
        {
            armorProtectionBox = new TextBox();
            textboxStyle.StyleForTextbox(armorProtectionBox);
            MF.Controls.Add(armorProtectionBox);

            armorProtectionBox.Location = new System.Drawing.Point(armorNameWidth, 200);
        }
        private void CreateButtonToAddToTable()
        {
            Label addToTable = new Label();
            addToTable.Text = "Dodaj do puli";
            labelStyle.StyleForButton(addToTable);

            addToTable.Click += AddProtectionToTable;

            MF.Controls.Add(addToTable);
            addToTable.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addToTable.Width / 2), ((MF.ClientSize.Height * 80) / 100));
        }
        private void AddProtectionToTable(object sebder, EventArgs e)
        {
            SqlInsertInto connMeg = new SqlInsertInto("armor", armorNameBox.Text, armorProtectionBox.Text);
            WriteArmor(this, e);
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
