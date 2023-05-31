using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Piredda.Riccardo._3i.WPFTabs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //Evento bottone di avvio di Isogramma
        private void StartIsogrammaButtonPressEvent(object sender, RoutedEventArgs e)
        {
            StartIsogramma();
        }

        //Funzione per l'avvio di isogramma
        private void StartIsogramma()
        {
            string IsogrammaResult = Isogramma();
            if (IsogrammaResult == "true")
                OutputIsogramma.Text = "La parola è un isogramma";
            else if (IsogrammaResult == "null")
                OutputIsogramma.Text = "ERROR: please, insert a word!";
            else
                OutputIsogramma.Text = "La parola NON è un isogramma";
        }

        //Gestione dell'evento di pressione invio nella textbox InputIsogramma
        private void InputIsogramma_EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                StartIsogramma();
            }
        }

        //Evento bottone di Reset Isogramma
        private void ResetIsogramma(object sender, RoutedEventArgs e)
        {
            InputIsogramma.Text = "";
            OutputIsogramma.Text = "";
        }

        //Funzione di Isogramma
        private string Isogramma()
        {
            string word = InputIsogramma.Text;
            if (word.Length == 0)
                return("null");
            word = word.ToLower();
            int i = 1;
            char tmp = ' '; //variabile di appoggio
            int lenght1 = 0;

            //creazione di una funzione che ricostruisce la parola rimuovendo i simboli e usando lo strongbuilder
            static void rebuilder(ref string word, ref char tmp)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string item in word.Split('.', '-', ' ', '"', tmp))
                    sb.Append(item);
                word = sb.ToString();
            }

            // parametri passati per referenza
            rebuilder(ref word, ref tmp);
            lenght1 = word.Length;
            // Il foreach scorre la parola per ogni char presente, poi passa il char alla funzione rebuilder che
            // splitta nuovamente la parola ma questa volta con un parametro diverso: il char assegnato a tmp.
            // se la lunghezza dopo l'esecuzione di rebuilder è diversa dalla lunghezza - i (i viene incrementata a ogni
            // ciclo per tenere traccia dei char rimossi man mano) ritorna falso
            foreach (char item in word)
            {
                tmp = item;
                rebuilder(ref word, ref tmp);
                if (word.Length != lenght1 - i)
                {
                    return("false");
                }
                i++;
            }

            return ("true");
        }

        //Evento bottone di avvio CollaTZ
        private void StartCollaTZButtonPressEvent(object sender, RoutedEventArgs e)
        {
            StartCollaTZ();
        }

        //Funzione per l'avvio di CollaTZ
        private void StartCollaTZ()
        {
            int CollaTZResult  = CollaTZ();
            if (CollaTZResult == 0010)
                OutputCollaTZ.Text = "ERROR: please insert a valid number!";
            else
                OutputCollaTZ.Text = CollaTZResult.ToString();
        }

        //Evento bottone di Reset CollaTZ
        private void ResetCollaTZ(object sender, RoutedEventArgs e)
        {
            InputCollaTZ.Text = "";
            OutputCollaTZ.Text = "";
        }

        //Funzione di CollaTZ
        public int CollaTZ()
        {
            int n = 0;
            try
            {
                n = Convert.ToInt32(InputCollaTZ.Text);
            }
            catch(Exception)
            {
                return(0010);
            }
            int i;
            int nc = n;  //numero calcolato
            for (i = 0; nc != 1; i++)
            {
                if (nc <= 0)
                {
                    throw new ArgumentException("Number refused!");
                }
                else if (nc % 2 == 0)
                {
                    nc = nc / 2;
                }
                else
                {
                    nc = (nc * 3) + 1;
                }
            }
            return i;
        }

        //Gestione dell'evento di pressione invio nella textbox InputCollaTZ
        private void InputCollaTZ_EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                StartCollaTZ();
            }
        }

        //Evento bottone di avvio NAMP
        private void StartNAMPButtonPressEvent(object sender, RoutedEventArgs e)
        {
            StartNAMP();
        }

        //Funzione per l'avvio di NAMP
        private void StartNAMP()
        {
            string NAMPResult = NAMP();
            if (NAMPResult == "Fail")
                OutputNAMP.Text = "Only number that start with 1, and 11 digit.";
            else
                OutputNAMP.Text = NAMPResult;

        }

        //Evento bottone di Reset NAMP
        private void ResetNAMP(object sender, RoutedEventArgs e)
        {
            InputNAMP.Text = "";
            OutputNAMP.Text = "";
        }

        //Funzione di NAMP
        public string NAMP()
        {
            string phoneNumber = InputNAMP.Text;
            string[] str = phoneNumber.Split(' ', '(', ')', '-', '.', '+');
            string nrc = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != "") { nrc = nrc + str[i]; }
            }
            if (nrc[0] == '1') { nrc = nrc.Substring(1); }
            if (nrc.Length != 10) { return ("Fail"); }

            for (int i = 0; i < nrc.Length; i++)
            {
                char nrchar = nrc[i];
                if (!char.IsDigit(nrchar))
                { return ("Fail"); }
            }

            if (nrc[0] == '0' || nrc[0] == '1' || nrc[3] == '0' || nrc[3] == '1')
            { return ("Fail"); }
            return nrc;
        }

        //Gestione dell'evento di pressione invio nella textbox InputCollaTZ
        private void InputNAMP_EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                StartNAMP();
            }
        }
        //Evento bottone di avvio Gocce
        private void StartGocceButtonPressEvent(object sender, RoutedEventArgs e)
        {
            StartGocce();
        }

        //Funzione per l'avvio di Gocce
        private void StartGocce()
        {
            string GocceResult = Gocce();
            if (GocceResult == "Fail")
                OutputGocce.Text = "ERROR: please insert a number";
            else
                OutputGocce.Text = GocceResult;
        }

        //Evento bottone di Reset Gocce
        private void ResetGocce(object sender, RoutedEventArgs e)
        {
            InputGocce.Text = "";
            OutputGocce.Text = "";
        }

        //Funzione di Gocce
        public string Gocce()
        {
            int number = 0;
            try
            {
                number = Convert.ToInt32(InputGocce.Text);
            }
            catch(Exception)
            {
                return ("Fail");
            }   
            if (number % 3 == 0 && number % 5 == 0 && number % 7 == 0) { return ("tictactoc"); }
            else if (number % 3 == 0 && number % 7 == 0) { return ("tictoc"); }
            else if (number % 5 == 0 && number % 7 == 0) { return ("tactoc"); }
            else if (number % 3 == 0 && number % 5 == 0) { return ("tictac"); }
            else if (number % 3 == 0) { return ("tic"); }
            else if (number % 5 == 0) { return ("tac"); }
            else if (number % 7 == 0) { return ("toc"); }
            else { return ("Number not usable: " + number.ToString()); }
        }

        //Gestione dell'evento di pressione invio nella textbox InputGocce
        private void InputGocce_EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                StartGocce();
            }
        }

        //Evento bottone di avvio Acronimo
        private void StartAcronimoButtonPressEvent(object sender, RoutedEventArgs e)
        {
            StartAcronimo();
        }

        //Funzione per l'avvio di Acronimo
        private void StartAcronimo()
        {
            string AcronimoResult = Acronimo();
            if (AcronimoResult == "Fail")
                OutputAcronimo.Text = "ERROR: please insert a word!";
            OutputAcronimo.Text = AcronimoResult;
        }

        //Evento bottone di Reset Acronimo
        private void ResetAcronimo(object sender, RoutedEventArgs e)
        {
            InputAcronimo.Text = "";
            OutputAcronimo.Text = "";
        }

        //Funzione di Acronimo
        public string Acronimo()
        {
            string phrase = InputAcronimo.Text;
            if (phrase.Length == 0)
                return ("Fail");
            string[] words = phrase.Split('_', ' ', '-');
            string stringa = "";
            string x = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "") //evita l'errore index out of range
                {
                    stringa = words[i][0].ToString();
                    x = x + stringa.ToUpper();
                }
                else { }
            }
            return x;
        }

        //Gestione dell'evento di pressione invio nella textbox InputAcronimo
        private void InputAcronimo_EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                StartAcronimo();
            }
        }

    }
}
