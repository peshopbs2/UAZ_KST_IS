using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAZ_KST_IS.Models.ViewModels.Menu;
using UAZ_KST_IS.Models.ViewModels.MenuCategory;

namespace UAZ_KST_IS.Business.Services.Interfaces
{
    public interface IMenuCategoryService
    {
        Task<IEnumerable<MenuCategoryViewModel>> GetAllAsync();
        Task<IEnumerable<MenuCategoryViewModel>> GetByMenuIdAsync(Guid menuId);
        Task<MenuCategoryViewModel> GetByIdAsync(Guid id);
        Task<MenuCategoryViewModel> CreateAsync(MenuCategoryCreateViewModel model);
        Task<MenuCategoryViewModel> UpdateAsync(MenuCategoryEditViewModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
