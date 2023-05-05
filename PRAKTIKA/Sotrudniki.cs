using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PRAKTIKA
{
    public class Sotrudniki
    {
        [Key]
        public int nomer_sotrudnika { get; set; }
        public int nomer_punkta { get; set; }
        public int nomer_dolzhnosti { get; set; }
        public string fio { get; set; }
        public DateTime data_rozhdeniya { get; set; }
        public string telefon { get; set; }
        public string adres { get; set; }
        public Sotrudniki(int nomer_sotrudnika, int nomer_punkta, int nomer_dolzhnosti, string fio, DateTime data_rozhdeniya, string telefon, string adres)
        {
            this.nomer_sotrudnika = nomer_sotrudnika;
            this.nomer_punkta = nomer_punkta;
            this.nomer_dolzhnosti = nomer_dolzhnosti;
            this.fio = fio;
            this.data_rozhdeniya = data_rozhdeniya;
            this.telefon = telefon;
            this.adres = adres;
        }
    }
}
