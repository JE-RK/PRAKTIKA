using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PRAKTIKA
{
    public class Dolzhnosti
    {
        [Key]
        public int nomer_dolzhnosti { get; set; }
        public string nazvaniye { get; set; }
        public int oklad { get; set; }
        public Dolzhnosti(int nomer_dolzhnosti, string nazvaniye, int oklad)
        {
            this.nomer_dolzhnosti = nomer_dolzhnosti;
            this.nazvaniye = nazvaniye;   
            this.oklad = oklad;
        }
    }
}
