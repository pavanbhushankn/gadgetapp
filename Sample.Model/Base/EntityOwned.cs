using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.Base
{
   public abstract  class EntityOwned: EntityActive
    {
        #region Properties
        public int? OwnerId { get; set; }
        public virtual Directorate Owner { get; set; }

        #endregion
    }
}
