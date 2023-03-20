using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterGenerator
{
    public partial class CharacterGenerator : Form
    {
        int counter = 10;

        Label[] buttonMenu; 

        public CharacterGenerator()
        {
            InitializeComponent();
            MainMenuButton();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void MainMenuButton()
        {
            buttonMenu = new Label[counter];

            for (int i = 0; i <= counter-1; i++)
            {
                buttonMenu[i] = new Label();
                buttonMenu[i].AutoSize = true;
                buttonMenu[i].Font = new Font("Unispace", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                buttonMenu[i].ForeColor = Color.Gray;

                buttonMenu[i].Text = "TestTest";

                buttonMenu[i].Location = new System.Drawing.Point((this.ClientSize.Width * 10)/100, ((this.ClientSize.Height * (90 + (i * -6))) / 100));
                this.Controls.Add(buttonMenu[i]);
            }
        }
    }
}
