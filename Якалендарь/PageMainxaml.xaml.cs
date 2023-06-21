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
    /// Логика взаимодействия для PageMainxaml.xaml
    /// </summary>
    public partial class PageMainxaml : Page
    {
        static DateTime dateTime = DateTime.Now;
        static int u = dateTime.Month;
        static int f = 0;
        public  Dictionary<int, DateTime> year = new Dictionary<int, DateTime>();
        public PageMainxaml()
        {
            InitializeComponent();
            Info.Text = dateTime.ToString("Y");
            V();
        }
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            year.Clear();
            wrap.Children.Clear();
            Info.Text = dateTime.AddMonths(f += 1).ToString("Y");
            if (u == 13)
            {
                u = 1;
                dateTime.AddYears(1);

            }
            u++;
            V();


        }
        private void V()
        {
            year.Clear();
            wrap.Children.Clear();
            List<Note> note = Ser.Mydeserial<List<Note>>("Note.json");

            var startDay = new DateTime(dateTime.Year, u, 1);
            var endDay = startDay.AddMonths(1);
            for (var date = startDay; date != endDay; date = date.AddDays(1))
            {
                UserControl user = new UserControl();
                user.Num.Text = date.Day.ToString();
                wrap.Children.Add(user);
                year.Add(date.Day, date.Date);
                foreach (var i in year)
                {
                    foreach (var not in note)
                    {
                        if (i.Value == not.zam)
                        {
                            user.Ic.ImageSource = not.image;
                            break;
                        }
                        else user.Ic.ImageSource = new BitmapImage(new Uri("C:\\Users\\kudaj\\source\\repos\\CAlendar\\Якалендарь\\op.jpg"));
                    }
                }
            }


        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            year.Clear();
            wrap.Children.Clear();
            u--;
            Info.Text = dateTime.AddMonths(f -= 1).ToString("Y");

            if (u == 0)
            {
                u = 12;
                dateTime.AddYears(-1);
            }
            V();

        }

        private void pickerText(object sender, SelectionChangedEventArgs e)
        {
            year.Clear();
            wrap.Children.Clear();
            dateTime = Convert.ToDateTime(Date.Text);
            u= Convert.ToDateTime(Date.Text).Month;
            Info.Text = dateTime.ToString("Y");
            V();
        }
    }
}
