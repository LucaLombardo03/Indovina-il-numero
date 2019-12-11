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

namespace Indovina_il_numero
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
        Random random = new Random();
        int numero_casuale;
        int livello_difficoltà;
        int tentativi;
        private void Genera_Click(object sender, RoutedEventArgs e)
        {
            livello_difficoltà = int.Parse(txtDifficoltà.Text);
            if (livello_difficoltà < 0 || livello_difficoltà >= 101)
                MessageBox.Show("IL NUMERO E' FUORI DAI LIMITI");
            else
            {
                numero_casuale = random.Next(1, livello_difficoltà);
                lblRisultato.Content = "Sto pensando.....";
                txtNumero.IsEnabled = true;
                btnIndovina.IsEnabled = true;
            }
        }

        private void Indovina_Click(object sender, RoutedEventArgs e)
        {
            int numero = int.Parse(txtNumero.Text);
            tentativi = int.Parse(txtTentativi.Text);
            if (numero > livello_difficoltà)
            {
                MessageBox.Show("IL NUMERO E' FUORI DAI LIMITI");
            }
            else
            if (numero_casuale == numero)
            {
                lblRisultato.Content = "Hai indovinato, Complimenti!!";
                txtTentativi.Text = $"Hai indovinato in {tentativi}";
            }
            else if (numero_casuale < numero)
            {
                lblRisultato.Content = "Hai perso, il numero è più piccolo!!";
                tentativi--;
                txtTentativi.Text = $"{tentativi}";
            }
            else if (numero_casuale > numero)
            {
                lblRisultato.Content = "Hai perso, il numero è più grande!!";
                tentativi--;
                txtTentativi.Text = $"{tentativi}";
            }
            else if (tentativi <= 0)
                txtTentativi.Text = "Hai esaurito i tentitivi!";
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            txtNumero.Clear();
            txtDifficoltà.Clear();
            lblRisultato.Content = "";
            txtTentativi.Clear();
            txtNumero.IsEnabled = false;
            btnIndovina.IsEnabled = false;
        }
    }
}
