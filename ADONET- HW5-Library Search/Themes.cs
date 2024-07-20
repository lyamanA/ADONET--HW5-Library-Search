using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET__HW5_Library_Search
{
    internal class Themes
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
