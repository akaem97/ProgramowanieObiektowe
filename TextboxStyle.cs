using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGeneratorWF
{
    public class TextboxStyle
    {        
        
        public TextboxStyle()
        {
         
        }
        public void StyleForTextbox(TextBox tb)
        {
            tb.Font = new Font("Unispace", 20, FontStyle.Bold);
            //tb.BackColor = Color.Gray;
            tb.Padding = new Padding(5);
            tb.TextAlign = HorizontalAlignment.Center;
            tb.Size = new Size(800, 45);

            //tb.Multiline = true;
            //tb.ScrollBars = ScrollBars.Vertical;
            //tb.WordWrap = true;
            //tb.TextChanged += DynamicTextBox;
        }
        /*private void DynamicTextBox(object sender, EventArgs e)
        {
            TextBox dtb = new TextBox();
            dtb.Height = ClientSize.He
        }
        */
    }
}
