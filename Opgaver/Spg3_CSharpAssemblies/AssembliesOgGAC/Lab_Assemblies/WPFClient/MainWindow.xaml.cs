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
using CprDLL;

namespace WPFClient
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

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            txtBlErrorMsg.Text = "";
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CprCheck.CprError cprErr;
            CprCheck.Check(txtBoxCpr.Text, out cprErr);

            switch (cprErr)
            {
                case CprCheck.CprError.NoError:
                    txtBlErrorMsg.Text = "Valid!!";
                    break;
                case CprCheck.CprError.FormatError:
                    txtBlErrorMsg.Text = "Wrong format :(";
                    break;
                case CprCheck.CprError.DateError:
                    txtBlErrorMsg.Text = "Date not valid?!";
                    break;
                case CprCheck.CprError.Check11Error:
                    txtBlErrorMsg.Text = "Not valid ..";
                    break;
                default:
                    txtBlErrorMsg.Text = "Unknown error occured";
                    break;
            }
        }
    }
}
