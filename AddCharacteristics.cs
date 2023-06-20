using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGeneratorWF
{
    public class AddCharacteristics 
    {
        public AddCharacteristics(Form mF) 
        {
            MF = mF;
            random = new Random();
        }
        private Form MF { get; set; }
        public IEnumerable<Control> Controls { get; private set; }

        private string characterID;
        private int labelWidth = 0;
        private Random random;
        
        string[] chchara = {
                "Walka wręcz",
                "Umięjętności strzeleckie",
                "Krzepa",
                "Odporność",
                "Zreczność",
                "Inteligencja",
                "Siła woli",
                "Ogłada",
                "Ataki",
                "Żywotność",
                "Siła",
                "Wytrzymałość",
                "Szybkość",
                "Magia",
                "Punkty obłędu",
                "Punkty przeznaczenia" };       
        
        int Xlabel = 120;
        int Ylabel = 50;

        private LabelStyle labelStyle = new LabelStyle();
        private TextboxStyle textboxStyle = new TextboxStyle();

        TextBox[] tableCharacteristics;        

        public void WriteCharacteristics(string ID)
        {
            characterID = ID;
            MF.Controls.Clear();
            
            LabelCreateChar();
            TextBoxCreateChar();

            CreateButtonToAddToTable();
            CreateBackButton();
            RollCharacteristic();
        }

        private void RollCharacteristic()
        {
            Label rollCharacteristic = new Label();
            rollCharacteristic.Text = "Wylosuj cechy";
            labelStyle.StyleForButton(rollCharacteristic);
            rollCharacteristic.Location = new System.Drawing.Point(1500, 60);

            rollCharacteristic.Click += RollCharacteristicClick;

            MF.Controls.Add(rollCharacteristic);
        }
        private void RollCharacteristicClick(object sender, EventArgs e)
        {
            foreach (Control control in MF.Controls)
            {
                if (control is TextBox tb)
                {
                    int randomNumber = random.Next(1, 11);
                    tb.Text = randomNumber.ToString();
                }
            }
        }
        private void LabelCreateChar()
        {            
            foreach (string chara in chchara)
            {
                Label label = new Label();
                label.Text = chara + ": ";
                labelStyle.StyleForText(label);

                MF.Controls.Add(label);

                label.Location = new System.Drawing.Point(Xlabel, Ylabel);

                Ylabel += 50;

                if (label.Width > labelWidth)
                {
                    labelWidth = label.Width;
                }
            }                  
        }
        
        private void TextBoxCreateChar()
        {
            Ylabel = 50;

            tableCharacteristics = new TextBox[chchara.Length];

            for (int i = 0; i<chchara.Length; i++)
            {
                TextBox tb = new TextBox();
                tb.Name = chchara[i];
                tb.Location = new System.Drawing.Point(Xlabel + labelWidth + 10, Ylabel + i* 50);
                textboxStyle.StyleForTextbox(tb);

                MF.Controls.Add(tb);
                tableCharacteristics[i] = tb;
            }
        }
        

        private void CreateButtonToAddToTable()
        {
            Label addToTable = new Label();
            addToTable.Text = "Dodaj postać";
            labelStyle.StyleForButton(addToTable);

            addToTable.Click += AddContentToTable;

            MF.Controls.Add(addToTable);
            addToTable.Location = new System.Drawing.Point((MF.ClientSize.Width / 2 - addToTable.Width / 2), ((MF.ClientSize.Height * 80) / 100));
        }
        private void AddContentToTable(object sebder, EventArgs e)
        {
            for (int i =0; i < chchara.Length; i++)
            {
                SqlInsertInto connMeg = new SqlInsertInto("relationcharecter", characterID, (i + 1).ToString(), tableCharacteristics[i].Text);
            }
            AddTalentToCharacter chhelper = new AddTalentToCharacter(MF);
            chhelper.WriteTalent(characterID);
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
