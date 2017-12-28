using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml;

namespace WPFProjectCheatham
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int k { get; set; }
        public MainWindow()
        {
            k = 0;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = sender as TextBox;
            if (int.TryParse(box.Text, out int i))
            {
                if (i < 1 || i > 5)
                {
                    MessageBoxResult result = MessageBox.Show("Enter A Number In The Specified Range", "Input Error", MessageBoxButton.OK, MessageBoxImage.Question);
                    //if (result == MessageBoxResult.Yes)
                    //{
                    //    Application.Current.Shutdown();
                    //}
                }
                else
                {
                    k = i;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Needs To Be A Number Between 1 to 5", "Input Error", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string address = "http://www.thomas-bayer.com/sqlrest/CUSTOMER/" + k.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            request.Method = "GET";
            request.Accept = "application/xml";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    //Object stuff = response.ToString();
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(response.GetResponseStream());

                    //XmlNode customer = xmlDoc.DocumentElement.SelectSingleNode("CUSTOMER");

                    string firstname = xmlDoc.DocumentElement.SelectSingleNode("//CUSTOMER/FIRSTNAME").InnerText;
                    string lastname = xmlDoc.DocumentElement.SelectSingleNode("LASTNAME").InnerText;
                    string street = xmlDoc.DocumentElement.SelectSingleNode("STREET").InnerText;
                    string city = xmlDoc.DocumentElement.SelectSingleNode("CITY").InnerText;

                    TBox1.Visibility = Visibility.Hidden;
                    Btn1.Visibility = Visibility.Hidden;
                    Lbl1.Content = "Here is the customer #" + k.ToString();

                    Label Lbl2 = new Label();
                    Lbl2.Content = $"{firstname} {lastname} {city}";

                    Grid1.Children.Add(Lbl2);
                }
            }
            catch (WebException ex)
            {
                string err = ex.ToString();
            }
        }
    }
}
