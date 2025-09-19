using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAZ_KST_IS.Models.ViewModels.MenuCategory
{
    public class MenuCategoryEditViewModel : BaseViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid MenuId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
