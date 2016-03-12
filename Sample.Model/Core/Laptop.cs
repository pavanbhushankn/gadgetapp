using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sample.Model.Core
{
    [Table("Laptop")]
    public  class Laptop: EntityActive
    {

        [Display(Name ="laptop Brand")]
        [StringLength(200)]
        public string Brand { get; set; }

        [StringLength(200)]
        public string Company { get; set; }
        public int? Price { get; set; }


       
    }
}
