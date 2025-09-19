using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAZ_KST_IS.Models.ViewModels.MenuCategory
{
    public class MenuCategoryViewModel : BaseViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid MenuId { get; set; }
        public string MenuTitle { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
