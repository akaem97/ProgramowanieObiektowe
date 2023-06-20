using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace CharacterGeneratorWF
{
    class MiniatureCard
    {
        public MiniatureCard(Form mF, string characterID, int posX, int posY)
        {
            MF = mF;
            ID = characterID;
        }
        private Form MF { get; set; }

        int cardWidth = 200;
        int cardHeight = 200;
        string ID;

        private readonly PictureBox pictureBox = new PictureBox();
        
        public void GenerateOneCard()
        {       
            pictureBox.Size = new System.Drawing.Size(cardHeight, cardWidth);
            pictureBox.BackColor = System.Drawing.Color.Lavender;



        }
    }
}
