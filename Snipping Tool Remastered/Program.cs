/*Original repository credits: https://github.com/michaelmob/Hyperdesktop2 by michaelmob
Based on HyperDesktop 2 as a continuation of the project, with a number of modifications. 
Fixed bugs and features from the original version.
The project was continued by (qzxtu) Nova#1735
*/
using Snipping_Tool_Remastered.Class;
using System;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace Snipping_Tool_Remastered
{
    internal static class Program
    {
        static Mutex mutex;

        static Boolean Single_Instance()
        {
            try
            {
                Mutex.OpenExisting("Snipping Tool Remastered");
            }
            catch
            {
                mutex = new Mutex(true, "Snipping Tool Remastered");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            if (!Single_Instance())
            {
                MessageBox.Show("Snipping Tool Remastered is already running!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Internals.CRYPT_KEY_STATIC = ((char)('K' ^ Internals.VERSION_MAJOR)).ToString() + ((char)('E' ^ Internals.VERSION_MINOR)).ToString() + ((char)('Y' ^ Internals.VERSION_PATCH)).ToString() + "RdQZaXP5iqzKpLZFaxkN";
            Internals.CRYPT_KEY_DYNAMIC = WindowsIdentity.GetCurrent().Name;
            ProtectProcess.Protect();
            Application.Run(new Snipping_Tool_Remastered());
        }
    }
}
