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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var email = new MyPlaceHolder("Enter your Email here...", ref myTxtbx);
            var password = new MyPlaceHolder("Enter your Password here...", ref myTxtbx1);
        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
    class MyPlaceHolder {

        string placholderText { get; set; }

        public MyPlaceHolder(string PlacheholderText, ref TextBox myTxtbx)
        {
            this.placholderText = PlacheholderText;
            myTxtbx.Text = PlacheholderText;
            myTxtbx.GotFocus += RemoveText;
            myTxtbx.LostFocus += AddText;
        }

        public void RemoveText(object sender, EventArgs e) {
            var obj = sender as TextBox;
            if (obj.Text == this.placholderText)
            {
                obj.Text = "";
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            var obj = sender as TextBox;
            if (string.IsNullOrWhiteSpace(obj.Text))
                obj.Text = placholderText;
        }
    }
}
