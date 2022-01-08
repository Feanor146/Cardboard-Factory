using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Speech.Synthesis;
namespace Картонная_фабрика.Classes
{
    internal class Message
    {
        public static void SendMessage(string str)
        {
            MessageBox.Show(str);
            //SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //speechSynthesizer.Volume = 100;
            //speechSynthesizer.Speak(str);
        }
    }
}
