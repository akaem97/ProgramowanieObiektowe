using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGeneratorWF
{
    class AddWeapon
    {
        private Form MF { get; set; }

        private LabelStyle labelStyle = new LabelStyle();
        private TextboxStyle textboxStyle = new TextboxStyle();

        private TextBox weaponDamageBox;
        private TextBox weaponNameBox;

        private int weaponNameWidth;

        public AddWeapon(Form mF)
        {
            MF = mF;
        }

        public void Button()
        {
            Label addWeapon = new Label();
            addWeapon.Text = "Dodaj broń do puli";
            labelStyle.StyleForButton(addWeapon);
            MF.Controls.Add(addWeapon);

            addWeapon.Click += WriteWeapon;

            addWeapon.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addWeapon.Width / 2), ((MF.ClientSize.Height * 85) / 100));
        }

        private void WriteWeapon(object sender, EventArgs e)
        {
            MF.Controls.Clear();
            LabeLCreateWeaponName();
            TextboxCreateWeaponName();
            LabelCreateWeaponDamage();
            TextboxCreateWeaponDamage();
            CreateButtonToAddToTable();
            CreateBackButton();
        }
        private void LabeLCreateWeaponName()
        {
            int X = 120;
            int Y = 150;
            Label weaponName = new Label();
            weaponName.Text = "Podaj nazwę broni: ";
            labelStyle.StyleForText(weaponName);
            MF.Controls.Add(weaponName);

            weaponName.Location = new System.Drawing.Point(X, Y);

            weaponNameWidth = weaponName.Width + X;
        }
        private void TextboxCreateWeaponName()
        {
            weaponNameBox = new TextBox();
            textboxStyle.StyleForTextbox(weaponNameBox);
            MF.Controls.Add(weaponNameBox);

            weaponNameBox.Location = new System.Drawing.Point(weaponNameWidth, 150);
        }
        private void LabelCreateWeaponDamage()
        {
            int X = 120;
            int Y = 200;

            Label weaponDamage = new Label();
            weaponDamage.Text = "Podaj obrażenia broni: ";
            labelStyle.StyleForText(weaponDamage);
            MF.Controls.Add(weaponDamage);

            weaponDamage.Location = new System.Drawing.Point(X, Y);
        }
        private void TextboxCreateWeaponDamage()
        {
            weaponDamageBox = new TextBox();
            textboxStyle.StyleForTextbox(weaponDamageBox);
            MF.Controls.Add(weaponDamageBox);

            weaponDamageBox.Location = new System.Drawing.Point(weaponNameWidth, 200);
        }
        private void CreateButtonToAddToTable()
        {
            Label addToTable = new Label();
            addToTable.Text = "Dodaj do puli";
            labelStyle.StyleForButton(addToTable);

            addToTable.Click += AddDamageToTable;

            MF.Controls.Add(addToTable);
            addToTable.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addToTable.Width / 2), ((MF.ClientSize.Height * 80) / 100));
        }
        private void AddDamageToTable(object sebder, EventArgs e)
        {
            SqlInsertInto connMeg = new SqlInsertInto("weapon", weaponNameBox.Text, weaponDamageBox.Text);
            WriteWeapon(this, e);
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
