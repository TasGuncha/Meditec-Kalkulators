using System;
using System.Collections.Generic;
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

namespace Calculator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double Number1; // "double" datu tips priekš "peldošā komata" cipariem
        double Number2; // "double" datu tips priekš "peldošā komata" cipariem
        string Operation = ""; //"string" datu tips priekš matemātiskājām operācijām (+ - * / %), kas tiks izmantots tālāk izmantojot "ResultBtn" funkciju
        public MainWindow()
        {
            InitializeComponent();
        }
        /* ===== [ Paši skaitļi ( 0-9 ) ] ===== */
        private void NumberBtn(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender; //Tiek definēta poga, kuru spiežot mainīsies redzamā vērtība
            if (ResultTextbox.Text == "0") //Ja "Textbox" ir 0,
            {
                ResultTextbox.Text = btn.Content.ToString(); //tad
            }
            else //Ja "Textbox" nav 0,
            {
                ResultTextbox.Text += btn.Content.ToString();//tad
            }
        }
        /* ===== [ Matemātiskās darbības ( + - * / = ) ] ===== */
        private void OperationBtn(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Number1 = double.Parse(ResultTextbox.Text);
            Operation = btn.Content.ToString();
            ResultTextbox.Text = "";
            /*
             * Tiek definēta poga, kuru spiežot mainīsies matemātiskās operācijas
             * Pirmais cipars, ar kuru tiks veiktas matemātiskās operācijas
             * Operācija, kas saturs matemātisko operāciju
             * Izvēloties attiecīgo matemātisko operāciju, tas tiks aizstāts ar tukšumu:
             *      piemēram: ja izvēlēsies reizināt 1. ciparu ar 2. ciparu, tad rezultāts būs: 2 "operācija( + - * / % )" 
             */
        }
        private void ResultBtn(object sender, RoutedEventArgs e)
        {
            Number2 = double.Parse(ResultTextbox.Text);
            switch (Operation) //Var izmantot arī "IF-ELSE" principu, taču "Switch", manuprāt, ir parocīgāks
            {
                case "+": //Ja matemātiskās operācijas poga tika izvēlēta "+",
                    ResultTextbox.Text = (Number1 + Number2).ToString(); //tad tiks izpildīta saskaitīšana
                    break;
                case "-": //Ja matemātiskās operācijas poga tika izvēlēta "-",
                    ResultTextbox.Text = (Number1 - Number2).ToString(); //tad tiks izpildīta atņemšana
                    break;
                case "*": //Ja matemātiskās operācijas poga tika izvēlēta "*",
                    ResultTextbox.Text = (Number1 * Number2).ToString(); //tad tiks izpildīta reizināšana
                    break;
                case "/": //Ja matemātiskās operācijas poga tika izvēlēta "/",
                    /* 
                     * Taču pirmstam, tiek veikta dalīšanas pārbaude ar 0
                     */
                    if (Number2 != 0) //Ja ievadītais skaitlis nav 0,
                    {
                        ResultTextbox.Text = (Number1 / Number2).ToString(); //tad tiks izpildīta dalīšana
                    }
                    else //Ja būs 0,
                    {
                        //tad uzrādīsies attiecīgas paziņojums "MessageBox" formātā, un tiks attiestatītas visas vērtības un matemātiskās operācijas
                        MessageBox.Show("Ar nulli dalīt nedrīkst!", "Meditec Kalkulators");
                        Number1 = 0;
                        Number2 = 0;
                        Operation = "";
                    }
                    break;
                case "%": //Ja matemātiskās operācijas poga tika izvēlēta "%",
                    ResultTextbox.Text = (Number1 % Number2).ToString(); //tad tiks izpildīta (angliski - "mod")
                    break;
                default:
                    break;
            }
        }
        private void OtherBtn(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Priekš citām operācijām!", "Meditec Kalkulators");
            /*
             * Šo var definēt kā jaunu funkciju, vai arī atstāt kādam citam nolūkam
             */
        }
        /* ===== [ Negatīvo skaitļu izmantošana ] ===== */
        private void NegativeBtn(object sender, RoutedEventArgs e)
        {
            /*
             * Šo nemācēju izveidot
             */
        }
        /* ===== [ Dzēšamās operācijas ] ===== */
        private void CEBtn(object sender, RoutedEventArgs e)
        {
            /*
             * Piemēram: rezultāts vai skaitlis ir 587125, un tika konstatēts, ka tika pieļauta kļūda, tad funkcija CEBtn ļauj nodzēst vērtības, cik vajag.
             * 587125 -> 58712 -> 5871 -> 587 -> 58 -> 5
             */
            if (ResultTextbox.Text.Length > 0)
            {
                ResultTextbox.Text = ResultTextbox.Text.Remove(ResultTextbox.Text.Length - 1, 1);
            }
            /*
             * Ja "TextBox" ir tukšs, tad uzrāda vienkārši skaitlisko vērtību 0
             */
            if (ResultTextbox.Text == "")
            {
                ResultTextbox.Text = "0";
            }
        }
        private void CBtn(object sender, RoutedEventArgs e)
        {
            ResultTextbox.Text = "0";
            Number1 = 0;
            Number2 = 0;
            Operation = "";
            /*
             * Nodzēš visas vērtības un attiestata sākotnējā stadijā (tā, it kā lietojumprogramma "Kalkulators" tiktu atvērts no jauna)
             */
        }
        /* ===== [ Citas darbības ( "," ) ] ===== */
        private void DotBtn(object sender, RoutedEventArgs e)
        {
            if (ResultTextbox.Text.IndexOf(',') < 0) //Ja skaitliskajā vērtībā nav neviena komata,
            {
                ResultTextbox.Text += ","; //tad vērtībai tas tiek pielikts
            }
            /*
             * Lai nesanāk, ka tiek ievadīts n daudzuma komati
             */
        }
    }
}
