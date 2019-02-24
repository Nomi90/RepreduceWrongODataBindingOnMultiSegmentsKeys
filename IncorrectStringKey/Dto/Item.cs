using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncorrectStringKey.Dto
{
    public class Item
    {
        [Key]
        public string Id { get; set; }
       [Key]
        public string CompanyId { get; set; }

        public string Description { get; set; }
    }
}
