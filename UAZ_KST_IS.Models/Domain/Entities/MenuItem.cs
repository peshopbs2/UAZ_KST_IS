using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAZ_KST_IS.Models.Domain.Entities
{
    public class MenuItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsFeatured { get; set; }
        public Guid MenuCategoryId { get; set; }
        public MenuCategory MenuCategory { get; set; } = null!;
    }
}
