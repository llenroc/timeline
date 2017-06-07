using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeline
{
    public class DataUser : IData
    {
        public String Avatar { get; set; }

        public bool Online { get; set; }

        public String ScreenName { get; set; }

        public String Handle { get; set; }
    }
}
