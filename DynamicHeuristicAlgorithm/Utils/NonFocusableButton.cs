using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicHeuristicAlgorithm.Utils
{
    public partial class NonFocusableButton : Button
    {
        public NonFocusableButton() : base()
        {
            this.TabStop = false;
        }

        protected override void WndProc(ref Message m)
        {
            // Ignore all messages that try to set the focus.
            if (m.Msg != 0x7)
            {
                base.WndProc(ref m);
            }
        }
    }
}
