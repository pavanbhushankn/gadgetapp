using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.Base
{
   public abstract class EntityActive: Entity
    {
        #region Properties

        public virtual bool IsActive { get; set; } = true;

        public virtual bool Intrash { get; set; } = false;
        #endregion
    }
}
