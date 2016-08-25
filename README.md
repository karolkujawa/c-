# c.sharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MorseCode
{
    public partial class morsecode : Form
    {
        private Dictionary<char, String> morseCode = new Dictionary<char, String>() // dictionary
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
        public morsecode()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) 
        {
            string userText = richtextbox1.Text;
            userText = userText.ToLower();
            for (int index = 0; index < userText.Length; index++)
            {

                char t = userText[index];
                if (morseCode.ContainsKey(t))
                {
                    richtextbox2.Text += (morseCode[t]) + " ";
                }
                
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richtextbox2.Text = "" ;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string usermorse = richtextbox2.Text;
            string[] encodeCharacters = usermorse.Split();
            foreach (string s in encodeCharacters)
            {
                foreach (KeyValuePair<char, string> pair in morseCode)
                {
                    if (pair.Value == s)
                    {
                        richtextbox1.Text += pair.Key + " ";
                        break;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richtextbox2.Text += "."; 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richtextbox2.Text += "-";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richtextbox2.Text += " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richtextbox1.Text = "";
        }

        private void button8_Click(object sender, EventArgs e) // main loop compare write symbol in dictionary
        {
            string userText = richtextbox1.Text;
            userText = userText.ToLower();
            foreach (char c in userText.ToCharArray())
            {
                string rslt = morseCode[c];
                foreach (char c2 in rslt.ToCharArray())
                {
                    if (c2 == '.')
                        Console.Beep(1000, 250);
                    else if (c2 == '-')
                        Console.Beep(1000, 750);
                    else if (c2 == ' ')
                        Console.Beep(1, 750);
                }
            }
        }
    }
}
