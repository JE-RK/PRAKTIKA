using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PRAKTIKA
{
    public class Aptechnyye_punkty
    {
        [Key]
        public int nomer_punkta { get; set; }
        public string naimenovaniye { get; set; }
        public string adres { get; set; }
        public Aptechnyye_punkty(int nomer_punkta, string naimenovaniye, string adres)
        {
            this.nomer_punkta = nomer_punkta;
            this.naimenovaniye = naimenovaniye;
            this.adres = adres;
        }
    }
}
