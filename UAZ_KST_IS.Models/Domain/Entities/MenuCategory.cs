using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAZ_KST_IS.Models.Domain.Entities
{
    public class MenuCategory : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; } = null!;
        public int DisplayOrder { get; set; }
    }
}
