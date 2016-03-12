using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.Attributes
{
    [Serializable]
   public class ListColumnAttribute : Attribute
    {
        #region Properties

        public string DisplayName { get; set; }

        public string DisplayTemplate { get; set; }

        public bool HasLink { get; set; }


        public int Order { get; set; }

        public PropertyInfo Info { get; set; }

        #endregion

        #region Constructor
        public ListColumnAttribute()
        {
            this.DisplayName = string.Empty;
            this.DisplayTemplate = string.Empty;
            this.HasLink = false;
            this.Order = 0;
        }


        public ListColumnAttribute(string displayName, string displayTemplate)
        {
            this.DisplayName = displayName;
            this.DisplayTemplate = displayTemplate;
        }


        public ListColumnAttribute(string displayName, string displayTemplate, bool hasLink)
        {
            this.DisplayName = displayName;
            this.DisplayTemplate = displayTemplate;
            this.HasLink = hasLink;
        }
        #endregion
    }
}
