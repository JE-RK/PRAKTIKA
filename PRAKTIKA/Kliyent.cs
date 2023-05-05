using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PRAKTIKA
{
    public class Kliyent
    {
        [Key]
        public int nomer_kliyenta { get; set; }
        public string dannyye_karty { get; set; }
        public string fio { get; set; }
        public Kliyent(int nomer_kliyenta, string dannyye_karty, string fio)
        {
            this.nomer_kliyenta = nomer_kliyenta;
            this.dannyye_karty = dannyye_karty;
            this.fio = fio;
        }
    }
}
