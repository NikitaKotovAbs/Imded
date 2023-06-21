using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для INFO.xaml
    /// </summary>
    public partial class INFO : Page
    {
        private List<string> str = new List<string>() { "Заниматься спортом", "Поиграть в футбол", "Захватить мир", "Покупки", "Поесть вкусностей" };
        private List<Userlmg> list5 = new List<Userlmg>();
        private List<Note> note = Ser.Mydeserial<List<Note>>("Note.json");

        public INFO(int o, DateTime k)
        {
            InitializeComponent();
            /*List<Note> notes = new List<Note>();
            Note note1 = new Note();
            List<string> strings = new List<string>() { "Заниматься спортом", "Поиграть в футбол" };
             note1.tags.Add(true,strings);
            //note1.tags.Add(true, "Поиграть в футбол");
              
            note1.zam = Convert.ToDateTime("01-04-2023");
            note1.image = new BitmapImage(new Uri("D:\\2\\c#\\Приложения\\Якалендарь\\Якалендарь\\weightlifting.png"));
            notes.Add(note1);
            Ser.MySeri(notes, "Note.json");*/
            PageMainxaml pageMain = new PageMainxaml();
            UserControl userControl = new UserControl();
            foreach (var n in pageMain.year)
            {
                if (o == n.Key)
                {
                    Data__.Text = n.Value.ToString("D");
                }
            }
            start();
            After(k);
           
        }
        private void After(DateTime k)
        {
            foreach (var re in list5)
            {
                foreach (var n in note)
                {
                    foreach (var n1 in n.tags)
                    {
                        foreach (var n2 in n1.Value)
                        {
                            if (n.zam == k && n2 == re.name.Text && n1.Key == true)
                            {
                                re.Check.IsChecked = true;
                            }
                        }
                    }
                }
            }
        }
        private void start()
        {
            BitmapImage list = new BitmapImage(new Uri("C:\\Users\\kudaj\\source\\repos\\CAlendar\\Якалендарь\\weightlifting.png"));
            BitmapImage list1 = new BitmapImage(new Uri("C:\\Users\\kudaj\\source\\repos\\CAlendar\\Якалендарь\\Properties\\football.png"));
            BitmapImage list2 = new BitmapImage(new Uri("C:\\Users\\kudaj\\source\\repos\\CAlendar\\Якалендарь\\Properties\\planet-earth.png"));
            BitmapImage list3 = new BitmapImage(new Uri("C:\\Users\\kudaj\\source\\repos\\CAlendar\\Якалендарь\\food-and-drink.png"));
            BitmapImage list4 = new BitmapImage(new Uri("C:\\Users\\kudaj\\source\\repos\\CAlendar\\Якалендарь\\burger.png"));
            Userlmg userlmg = new Userlmg();
            userlmg.Img.Source = list;
            userlmg.name.Text = "Заниматься спортом";
            Userlmg userlmg1 = new Userlmg();
            userlmg1.Img.Source = list1;
            userlmg1.name.Text = "Поиграть в футбол";
            Userlmg userlmg2 = new Userlmg();
            userlmg2.Img.Source = list2;
            userlmg2.name.Text = "Захватить мир";
            Userlmg userlmg3 = new Userlmg();
            userlmg3.Img.Source = list3;
            userlmg3.name.Text = "Покупки";
            Userlmg userlmg4 = new Userlmg();
            userlmg4.Img.Source = list4;
            userlmg4.name.Text = "Поесть вкусностей";
            list5.Add(userlmg);
            list5.Add(userlmg1);
            list5.Add(userlmg2);
            list5.Add(userlmg3);
            list5.Add(userlmg4);
            OLO.ItemsSource = list5;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<string> ui = new List<string>();
            Note notes = new Note();
            List<bool> bools = new List<bool>();


            for (int i = 0; i < OLO.Items.Count; i++)
            {
                if (list5[i].Check.IsChecked == true)
                {
                    bools.Add((bool)list5[i].Check.IsChecked);
                    notes.image = (BitmapSource)list5[i].Img.Source;
                    notes.zam = Convert.ToDateTime(Data__.Text);
                    ui.Add(item: list5[i].name.Text);
                }
            }
            notes.tags.Add(true, ui);
            note.Add(notes);
            Ser.MySeri(note, "Note.json");
            (Application.Current.MainWindow as MainWindow).SetContent(new PageMainxaml());
        }

        private void Exit__Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).SetContent(new PageMainxaml());
        }
    }
}
