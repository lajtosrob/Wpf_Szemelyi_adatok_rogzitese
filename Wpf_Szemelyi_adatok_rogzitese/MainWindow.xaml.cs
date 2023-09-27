using Hardware.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace Wpf_Szemelyi_adatok_rogzitese
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string dataPath = @"C:\Users\Admin\source\repos\Wpf_Szemelyi_adatok_rogzitese\Wpf_Szemelyi_adatok_rogzitese\Datas\PersonalDetails.csv";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnWriteIntoFile_Click(object sender, RoutedEventArgs e)
        {
            char gender;
            string name;
            string dateOfBirth;

            if (txtName.Text != "")
            {
                name = txtName.Text.ToString();
            }
            else
            {
                MessageBox.Show("A név mező  nincs kitöltve!");
                txtName.Focus();
                return;
            }

            if (rdoMale.IsChecked == true)
            {
                gender = 'F';
            }
            else if (rdoFemale.IsChecked == true)
            {
                gender = 'N';
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva a nem!!!");
                return;
            }

            var today = DateTime.Now;
            var prevDate = Convert.ToDateTime(datDateOfBirth.Text);
            TimeSpan dateDifference = today - prevDate;

            var age = int.Parse((Convert.ToString(dateDifference).Split('.')[0]))/365;

            int personHeight = Convert.ToInt32(sliHeight.Value);
            if (datDateOfBirth.Text == "")
            {
                MessageBox.Show("A dátum mező nincs kitöltve!!!");
                datDateOfBirth.Focus();
                return;
            }
            else if (age < 18)
            {
                MessageBox.Show("Legalább 18 évesnek kell lennie!!!");
                datDateOfBirth.Focus();
                return;
            }
            else
            {
                dateOfBirth = datDateOfBirth.Text;
            }

            StreamWriter sw = new StreamWriter(dataPath, true);
            sw.WriteLine($"{name};{gender};{personHeight};{dateOfBirth}");

            sw.Close();

            txtName.Text = "";
            txtName.Focus();
            rdoFemale.IsChecked = false;
            rdoMale.IsChecked = false;
            sliHeight.Value = 0;
            datDateOfBirth.Text = "";

        }
    }

}


