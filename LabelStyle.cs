using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGeneratorWF
{
    public class LabelStyle
    {
        public void StyleForText(Label label)
        {            
            label.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));            
            label.Padding = new Padding(5);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = true;
        }

        public void StyleForButton(Label label)
        {
            label.Font = new Font("Unispace", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label.BackColor = Color.LightGray;
            label.Padding = new Padding(5);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = true;

            label.MouseEnter += ButtonMouseEnter;
        }
        public void StyleForLibraryElement(Label label, int col, int row)
        {
            label.Location = new System.Drawing.Point(20 + col * 200, 20 + row * 35);
            label.BackColor = System.Drawing.Color.Transparent;
            label.AutoSize = true;
            label.Font = new Font("Unispace", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label.ForeColor = Color.Gray;
            label.Cursor = Cursors.Hand;
        }
        public void StyleForInfoElement(Label label, int row, int col)
        {
            label.Location = new System.Drawing.Point(20 + col * 200, 20 + row * 35);
            label.BackColor = System.Drawing.Color.Transparent;
            label.AutoSize = true;
            label.Font = new Font("Unispace", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label.ForeColor = Color.Gray;            
        }
        private void ButtonMouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Cursor = Cursors.Hand;
        }
    }
}
