using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public record PassWord
    {
        public string? Password { get; set; }
        public int? Strength { get; set; }
    }
}
