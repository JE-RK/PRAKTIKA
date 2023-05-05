using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PRAKTIKA
{
    public class Prodazha
    {
        [Key]
        public int nomer_prodazhi { get; set; }
        public int nomer_punkta { get; set; }
        public int nomer_medikamenta { get; set; }
        public int kolichestvo { get; set; }
        public int nomer_kliyenta { get; set; }
        public int nomer_sotrudnika { get; set; }
        public DateTime data_prodazhi { get; set; }
        public int stoimost { get; set; }
        public Prodazha(int nomer_prodazhi, int nomer_punkta, int nomer_medikamenta, int kolichestvo, int nomer_kliyenta, int nomer_sotrudnika, DateTime data_prodazhi, int stoimost)
        {
            this.nomer_prodazhi = nomer_prodazhi;
            this.nomer_punkta = nomer_punkta;
            this.nomer_medikamenta = nomer_medikamenta;
            this.kolichestvo = kolichestvo;
            this.nomer_kliyenta = nomer_kliyenta;
            this.nomer_sotrudnika = nomer_sotrudnika;
            this.data_prodazhi = data_prodazhi;
            this.stoimost = stoimost;
        }

    }
}
