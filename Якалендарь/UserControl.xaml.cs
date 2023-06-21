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

namespace Якалендарь
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class UserControl 
    {
        public int o;
        public DateTime l;
        public UserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            o = Convert.ToInt32(Num.Text);
           // mainWindow.Show();
            PageMainxaml pageMainxaml = new PageMainxaml();
            foreach (var i in pageMainxaml.year)
            {
                if (i.Key == o)
                {
                    l = i.Value;
                }
            }
            (Application.Current.MainWindow as MainWindow).SetContent(new INFO(o, l));
            //mainWindow.SetContent(new INFO(o,l));
            
           
        }
    }
}
