using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Kod_Morse
{
    public partial class KodMorse : Form
    {
        // Deklaracja słownika
        private Dictionary<char, String> morseCode = new Dictionary<char, String>()
            {
                //Litery
                {'a' , ".-"},{'ą' , ".-.-"},{'b' , "-..."},{'c' , "-.-."},{'ć' , "-.-.."}, 
                {'d' , "-.."},{'e' , "."},{'ę' , "..-.."},{'f' , "..-."},
                {'g' , "--."},{'h' , "...."},{'i' , ".."}, // {'ch' , "----"},  wycięte z kodu
                {'j' , ".---"},{'k' , "-.-"},{'l' , ".-.."},{'ł', ".-..-"},
                {'m' , "--"},{'n' , "-."},{'ń' , "--.--"},{'o' , "---"},{'ó' , "---."},
                {'p' , ".--."},{'q' , "--.-"},{'r' , ".-."},
                {'s' , "..."},{'ś', "...-..."},{'t' , "-"},{'u' , "..-"},
                {'v' , "...-"},{'w' , ".--"},{'x' , "-..-"},
                {'y' , "-.--"},{'z' , "--.."},{'ź' , "--..-"},{'ż' , "--..-."},{' ' , " "},
                //Numery 
                {'0' , "-----"},{'1' , ".----"},{'2' , "..----"},{'3' , "...--"},
                {'4' , "....-"},{'5' , "....."},{'6' , "-...."},{'7' , "--..."},
                {'8' , "---.."},{'9' , "----."},
                //Znaki interpunkcyjne
                {'.' , ".-.-.-"},{',' , "--..--"}, //{' ' ' , ".----."}, wycięte z kodu
                {'_' , "..--.-"},{':' , "---..."},{';' , "-.-.-."},{'"' , ".-..-."},
                {'?' , "..--.."},{'!' , "-.-.--"},{'-' , "-....-"},{'+' , ".-.-."},
                {'/' , "-..-."},{'(' , "-.--."},{')' , "-.--.-"},{'=' , "-...-"},
                {'@' , ".--.-."},
            };
        // inicjacja komponentu
        public KodMorse()
        {
            InitializeComponent();
        }
        // zdarzenie dla przycisku "Na Morse'a"
        private void button1_Click(object sender, EventArgs e)
        {
            // deklaracja elementu z tekstem 
            string userText = richTextBox1.Text;
            // zamiana liter na małe
            userText = userText.ToLower();
            // wartość elementów
            for (int index = 0; index < userText.Length; index++)
            {
                // przypisanie wartości do elementu
                char t = userText[index];
                // jeśli element znajduje się w słowniku
                if (morseCode.ContainsKey(t))
                {
                    // wyświetla zawartość elementu z słownika
                    richTextBox2.Text += (morseCode[t]) + " ";
                }

            }
        }
        // zdarzenie dla przycisku "wyczyść tekst"
        private void button2_Click(object sender, EventArgs e)
        {
            // usunięcie elementów
            richTextBox1.Clear();
        }
        // zdarzenie dla przycisku "wyczyść kod"
        private void button8_Click(object sender, EventArgs e)
        {
            // usunięcie elementów
            richTextBox2.Clear();
        }
        // zdarzenie dla przycisku "na morsa
        private void button7_Click(object sender, EventArgs e)
        {
            // deklaracja elementu z tekstem
            string usermorse = richTextBox2.Text;
            // przypisanie ciągu znaków do tablicy
            string[] encodeCharacters = usermorse.Split();
            foreach (string s in encodeCharacters)
            {
                // dopasowanie par znaków do słownika
                foreach (KeyValuePair<char, string> pair in morseCode)
                {
                    // jeśli wartość pary z słownika jest równa ciągowi
                    if (pair.Value == s)
                    {
                        //wyświetla klucz pary z słownika
                        richTextBox1.Text += pair.Key + " ";
                        // zatrzymuje dopasowywanie
                        break;
                    }
                }
            }
        }
        // zdarzenie dla przycisku "na dźwięk"
        private void button6_Click(object sender, EventArgs e)
        {
            // wczytanie kodu
            string userText = richTextBox2.Text;
            // przypisanie ciągu
            foreach (char c in userText.ToCharArray())
            {
                // deklaracja słownika
                string rslt = morseCode[c];
                // przypisanie ciągu do słownika
                foreach (char c2 in rslt.ToCharArray())
                {
                    // jeżeli w ciagu wystapi "kropka"
                    if (c2 == '.')
                        Console.Beep(1000, 300);
                        // jeżeli w ciągu wystąpi "kreska"
                    else if (c2 == '-')
                        Console.Beep(1000, 900);
                    /*zatrzymuje przypisywanie do znaków
                     * dodaje przerwe między ciągami
                     */
                    break;
                }
            }
        }
        //zdarzenie dla przycisku "kropka"
        private void button3_Click(object sender, EventArgs e)
        {
            // wypisanie "kropki"
            richTextBox2.Text += "."; 
        }
        //zdarzenie dla przycisku "kreska"
        private void button5_Click(object sender, EventArgs e)
        {
            // wypisanie "kreski"
            richTextBox2.Text += "-";
        }
        //zdarzenie dla przycisku "przerwa"
        private void button4_Click(object sender, EventArgs e)
        {
            // wypisanie spacji
            richTextBox2.Text += " ";
        }
        // zdarzenie dla opcji menu tekstu "zamknij aplikacje
        private void zakończAplikacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zamyka aplikacje
            this.Close();
        }
        // zdarzenie dla opcji z menu kodu "zamknij aplikacje"
        private void zakończAplikacjeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // zamyka aplikacje
            this.Close();
        }
        // zdarzenie dla opcji menu tekstu 'wczytanie'
        private void wczytajTeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // moduł wczytania tekstu
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader f = new StreamReader(dialog.FileName);
                richTextBox1.Text = f.ReadToEnd();
                f.Close();
            }
        }
        // zdsarzenie dla opcji menu tekstu 'zapis'
        private void zapiszDoPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //moduł zapisu tekstu
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter f = new StreamWriter(dialog.FileName);
                f.Write(richTextBox1.Text);
                f.Close();
            }
        }
        // zdarzenie dla przycisku menu kodu 'wczytanie'
        private void wczytajZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //moduł wczytania pliku
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader f = new StreamReader(dialog.FileName);
                richTextBox2.Text = f.ReadToEnd();
                f.Close();
            }
        }
        // zdarzenie dla opcji menu kodu 'zapis'
        private void zapiszDoPlikuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //moduł zapisu pliku
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter f = new StreamWriter(dialog.FileName);
                f.Write(richTextBox2.Text);
                f.Close();
            }
        }

        private void oProgramieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab1 = new AboutBox1();
            ab1.Show();
        }
    }
}
