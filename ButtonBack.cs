using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

//Do poprawy, zrobic po utworzeniu class odczytu informacji, albo zaproponować inny sposób odświeżania okna.

namespace CharacterGeneratorWF
{
    class ButtonBack
    {
        public Label CreateButtonBack(int x , int y)
        {
            Label buttonBack = new Label();
            buttonBack.Text = "Odśwież baze";
            buttonBack.AutoSize = true;
            buttonBack.Location = new System.Drawing.Point((x / 2 - buttonBack.Width / 2), ((y * 90) / 100));
            buttonBack.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));

            buttonBack.Click += ButtonBack_Click;
            buttonBack.MouseEnter += ButtonBack_MouseEnter;

            return buttonBack;
        }

        
        public void ButtonBack_Click(object sender, EventArgs e)
        {
            //this.Controls.Clear();

            

            //PobierzCharacterInfo();
            //PobierzCharacterCh();
            //ButtonBack();
        }

        public void ButtonBack_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Cursor = Cursors.Hand;
        }
    }
}
