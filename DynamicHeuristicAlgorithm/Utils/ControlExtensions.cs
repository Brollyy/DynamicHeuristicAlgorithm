using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicHeuristicAlgorithm.Utils
{
    public static class ControlExtensions
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        private delegate void SuspendCallback(Control control);
        private delegate void ResumeCallback(Control control);

        public static void Suspend(Control control)
        {
            if (!control.IsDisposed)
            {

                if (control.InvokeRequired)
                {
                    SuspendCallback call = new SuspendCallback(Suspend);
                    control.FindForm().Invoke(call, new object[] { control });
                }
                else
                {
                    LockWindowUpdate(control.Handle);
                }
            }
        }

        public static void Resume(Control control)
        {
            if (!control.IsDisposed)
            {
                if (control.InvokeRequired)
                {

                    ResumeCallback call = new ResumeCallback(Resume);
                    control.FindForm().Invoke(call, new object[] { control });
                }
                else
                {
                    LockWindowUpdate(IntPtr.Zero);
                }
            }
        }

    }
}
