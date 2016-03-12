using Sample.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.Base
{
  
  public abstract  class Entity: EntityWithId<int>
    {
        #region Properties

        public virtual  DateTime CreatedOn { get; set; }

        public virtual int CreatedBy { get; set; }

        public virtual DateTime? LastModifiedOn { get; set; }

        public virtual int? LastModifiedBy { get; set; }
        
        #endregion

        #region Methods
        public virtual IEnumerable<ListColumnAttribute> GetListProperties()
        {
            IList<ListColumnAttribute> output = new List<ListColumnAttribute>();
            IEnumerable<PropertyInfo> properties = this.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object[] attribs = property.GetCustomAttributes(false);
                ListColumnAttribute listAttrib = null;
                UIHintAttribute hintAttrib = null;

                foreach (object attrib in attribs)
                {
                    if (attrib.GetType() == typeof(ListColumnAttribute))
                    {
                        listAttrib = (ListColumnAttribute)attrib;
                        
                    }

                    if (attrib.GetType() == typeof(UIHintAttribute))
                    {
                        hintAttrib = (UIHintAttribute)attrib;

                    }
                }

                if (listAttrib !=null)
                {
                    if (listAttrib.DisplayTemplate.Length ==0 && hintAttrib != null)
                    {
                        listAttrib.DisplayTemplate = hintAttrib.UIHint;
                    }

                    listAttrib.Info = property;
                    output.Add(listAttrib);

                }

            }

            return output;
        }

        #endregion
    }
}
