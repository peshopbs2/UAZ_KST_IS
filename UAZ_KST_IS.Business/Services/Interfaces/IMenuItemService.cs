using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAZ_KST_IS.Models.ViewModels.MenuCategory;
using UAZ_KST_IS.Models.ViewModels.MenuItem;

namespace UAZ_KST_IS.Business.Services.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemViewModel>> GetAllAsync();
        Task<IEnumerable<MenuItemViewModel>> GetByMenuCategoryIdAsync(Guid menuCategoryId);
        Task<MenuItemViewModel> GetByIdAsync(Guid id);
        Task<MenuItemViewModel> CreateAsync(MenuItemCreateViewModel model);
        Task<MenuItemViewModel> UpdateAsync(MenuItemEditViewModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
