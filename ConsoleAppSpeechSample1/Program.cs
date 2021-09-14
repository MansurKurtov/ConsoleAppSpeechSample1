using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSpeechSample1
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (RecognizerInfo ri in SpeechRecognitionEngine.InstalledRecognizers())
            {
                Console.WriteLine(ri.Culture.Name);
            }
            //Console.ReadLine();
            Console.WriteLine("Gapiring");

            using (
      SpeechRecognitionEngine recognizer =
        new SpeechRecognitionEngine(
          new System.Globalization.CultureInfo("en-US")))
            {

                recognizer.LoadGrammar(new DictationGrammar());

                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Aniqlangan text: " + e.Result.Text);
        }
    }
}
