

using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Model.Base
{
    [Serializable]
    public abstract class EntityWithId<TId>
    {
        #region Properties
        [ScaffoldColumn(false)]
        [Key]
        public virtual TId Id { get; set; }

        #endregion
    }
}
