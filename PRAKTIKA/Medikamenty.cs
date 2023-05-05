using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PRAKTIKA
{
    public class Medikamenty
    {
        [Key]
        public int nomer_medikamenta { get; set; }
        public int nomer_gruppy { get; set; }
        public string nazvaniye_medikamenta { get; set; }
        public string forma_upakovki { get; set; }
        public string protivopokazaniya { get; set; }
        public string dozirovka { get; set; }
        public int stoimost_medikamenta { get; set; }
        public Medikamenty(int nomer_medikamenta, int nomer_gruppy, string nazvaniye_medikamenta, string forma_upakovki, string protivopokazaniya, string dozirovka, int stoimost_medikamenta)
        {
            this.nomer_medikamenta = nomer_medikamenta;
            this.nomer_gruppy = nomer_gruppy;
            this.nazvaniye_medikamenta = nazvaniye_medikamenta;
            this.forma_upakovki = forma_upakovki;
            this.protivopokazaniya = protivopokazaniya;
            this.dozirovka = dozirovka;
            this.stoimost_medikamenta = stoimost_medikamenta;          
        }
    }
}
