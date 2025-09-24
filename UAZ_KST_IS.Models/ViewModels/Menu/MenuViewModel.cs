using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAZ_KST_IS.Models.ViewModels.MenuCategory;

namespace UAZ_KST_IS.Models.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<MenuCategoryViewModel> MenuCategories { get; set; } = null!;

    }
}
