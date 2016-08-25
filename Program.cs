using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kod_Morse
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //funkcja główna
        static void Main()
        {
            // wiadomość przy uruchamianiu aplikacji
            MessageBox.Show("Witam w programie do konwersji Kodu Morse'a","by Karol Kujawa");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KodMorse());
        }
    }
}
