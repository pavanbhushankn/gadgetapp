using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.Dto
{
   
        public class ActionStateDto
        {
            public bool Success { get; set; }
            public int? EntityId { get; set; }
            public string Description { get; set; }
        }
    
}
