using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sample.Model.Base
{
   public abstract class EntityNamed: EntityActive
    {
        #region Properties
        [Display(Name ="Name", Order =1000)]
        [UIHint("LongText")]
        public virtual string Name { get; set; }

        #endregion
    }
}
