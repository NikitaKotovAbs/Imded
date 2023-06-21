using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Якалендарь
{
    internal class Note
    {
        public BitmapSource image;
      /* public bool che;
        public string desc;*/
        public DateTime zam;
        public Dictionary<bool,List< string>> tags = new Dictionary<bool,List<string>>();
    }
}
