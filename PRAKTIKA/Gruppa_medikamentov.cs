using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PRAKTIKA
{
    public  class Gruppa_medikamentov
    {
        [Key]
        public int nomer_gruppy { get; set; }
        public string nazvaniye_gruppy { get; set; }
    }
}
