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
using CprSharedDLL;

namespace CprSharedClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CprSharedCheck cprCheck = new CprSharedCheck();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            txtBlErrorMsg.Text = "";
        }

        private void ButtonCheckCPR_OnClick(object sender, RoutedEventArgs e)
        {
            CprSharedCheck.CprError cprErr;
            cprCheck.Check(txtBoxCpr.Text, out cprErr);

            switch (cprErr)
            {
                case CprSharedCheck.CprError.NoError:
                    txtBlErrorMsg.Text = "Valid!!";
                    break;
                case CprSharedCheck.CprError.FormatError:
                    txtBlErrorMsg.Text = "Wrong format :(";
                    break;
                case CprSharedCheck.CprError.DateError:
                    txtBlErrorMsg.Text = "Date not valid?!";
                    break;
                case CprSharedCheck.CprError.Check11Error:
                    txtBlErrorMsg.Text = "Not valid ..";
                    break;
                default:
                    txtBlErrorMsg.Text = "Unknown error occured";
                    break;
            }
        }

        private void ButtonGetInfo_OnClick(object sender, RoutedEventArgs e)
        {
            var type = cprCheck.GetType();
            var assemName = type.Assembly.GetName();


            txbName.Text = type.Assembly.FullName;
            txbVersion.Text = assemName.Version.ToString();
            txbLocation.Text = type.Assembly.Location;
            txbLocatedFromGAC.Text = type.Assembly.GlobalAssemblyCache.ToString();

        }
    }
}
