using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicHeuristicAlgorithm.Utils
{
    public class ControlWriter : TextWriter
    {
        private Control textbox;
        private delegate void WriteCharCallback(char value);
        private delegate void WriteStringCallback(string value);

        public ControlWriter(Control textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            if (!textbox.IsDisposed)
            {
                if (textbox.InvokeRequired)
                {
                    WriteCharCallback call = new WriteCharCallback(Write);
                    textbox.FindForm().Invoke(call, new object[] { value });
                }
                else
                {
                    textbox.Text += value;
                }
            }
        }

        public override void WriteLine(string value)
        {
            if (!textbox.IsDisposed)
            {
                if (textbox.InvokeRequired)
                {
                    WriteStringCallback call = new WriteStringCallback(WriteLine);
                    textbox.FindForm().Invoke(call, new object[] { value });
                }
                else
                {
                    textbox.Text += value + Environment.NewLine;
                }
            }
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
