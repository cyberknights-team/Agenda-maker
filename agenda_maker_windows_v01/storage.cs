using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_maker_windows_v01
{
    public class storage
    {
        public string title { get; set; }
        public string description { get; set; }

        public storage() { }
        public storage(string Title,string Description)
        {
            this.title = Title;
            this.description = Description;
        }
    }
}
