using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGeneratorWF
{
    class AddEquipment
    {
        private Form MF { get; set; }

        private LabelStyle labelStyle = new LabelStyle();
        private TextboxStyle textboxStyle = new TextboxStyle();

        private TextBox equipmentContentBox;
        private TextBox equipmentNameBox;

        private int equipmentNameWidth;

        public AddEquipment(Form mF)
        {
            MF = mF;
        }

        public void Button()
        {
            Label addEquipment = new Label();
            addEquipment.Text = "Dodaj przedmiot do puli";
            labelStyle.StyleForButton(addEquipment);
            MF.Controls.Add(addEquipment);

            addEquipment.Click += WriteEquipment;

            addEquipment.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addEquipment.Width / 2), ((MF.ClientSize.Height * 80) / 100));
        }

        private void WriteEquipment(object sender, EventArgs e)
        {
            MF.Controls.Clear();
            LabeLCreateEquipmentName();
            TextboxCreateEquipmentName();
            LabelCreateEquipmentContent();
            TextboxCreateEquipmentContent();
            CreateButtonToAddToTable();
            CreateBackButton();
        }
        private void LabeLCreateEquipmentName()
        {
            int X = 120;
            int Y = 150;
            Label equipmentName = new Label();
            equipmentName.Text = "Podaj nazwę przedmiotu: ";
            labelStyle.StyleForText(equipmentName);
            MF.Controls.Add(equipmentName);

            equipmentName.Location = new System.Drawing.Point(X, Y);

            equipmentNameWidth = equipmentName.Width + X;
        }
        private void TextboxCreateEquipmentName()
        {
            equipmentNameBox = new TextBox();
            textboxStyle.StyleForTextbox(equipmentNameBox);
            MF.Controls.Add(equipmentNameBox);

            equipmentNameBox.Location = new System.Drawing.Point(equipmentNameWidth, 150);
        }
        private void LabelCreateEquipmentContent()
        {
            int X = 120;
            int Y = 200;

            Label equipmentContent = new Label();
            equipmentContent.Text = "Podaj opis przedmiotu: ";
            labelStyle.StyleForText(equipmentContent);
            MF.Controls.Add(equipmentContent);

            equipmentContent.Location = new System.Drawing.Point(X, Y);
        }
        private void TextboxCreateEquipmentContent()
        {
            equipmentContentBox = new TextBox();
            textboxStyle.StyleForTextbox(equipmentContentBox);
            MF.Controls.Add(equipmentContentBox);

            equipmentContentBox.Location = new System.Drawing.Point(equipmentNameWidth, 200);
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
            SqlInsertInto connMeg = new SqlInsertInto("equipment", equipmentNameBox.Text, equipmentContentBox.Text);
            WriteEquipment(this, e);
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
