using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAZ_KST_IS.Business.Repositories;
using UAZ_KST_IS.Business.Services.Interfaces;
using UAZ_KST_IS.Models.Domain.Entities;
using UAZ_KST_IS.Models.ViewModels.MenuCategory;
using UAZ_KST_IS.Models.ViewModels.MenuItem;

namespace UAZ_KST_IS.Business.Services.Implementations
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IRepository<MenuItem> _menuItemRepository;
        private readonly IMapper _mapper;
        public MenuItemService(IRepository<MenuItem> menuItemRepository, IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        public async Task<MenuItemViewModel> CreateAsync(MenuItemCreateViewModel model)
        {
            var entity = _mapper.Map<MenuItem>(model);

            await _menuItemRepository.AddAsync(entity);
            await _menuItemRepository.CommitAsync();
            return _mapper.Map<MenuItemViewModel>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id) ?? throw new InvalidOperationException($"There is no menu item with id {id}");

            _menuItemRepository.Remove(menuItem);
            await _menuItemRepository.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<MenuItemViewModel>> GetAllAsync()
        {
            var menuCategories = await _menuItemRepository
                .GetAllAsync(mi => mi.MenuCategory);
            return _mapper.Map<IEnumerable<MenuItemViewModel>>(menuCategories);
        }

        public async Task<MenuItemViewModel> GetByIdAsync(Guid id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id, mi => mi.MenuCategory) ?? throw new InvalidOperationException($"There is no menu item with id {id}");

            return _mapper.Map<MenuItemViewModel>(menuItem);
        }

        public async Task<IEnumerable<MenuItemViewModel>> GetByMenuCategoryIdAsync(Guid menuCategoryId)
        {
            var menuCategories = await _menuItemRepository.FindAsync(mi => mi.MenuCategoryId == menuCategoryId, mi => mi.MenuCategory);
            return _mapper.Map<IEnumerable<MenuItemViewModel>>(menuCategories);
        }

        public async Task<MenuItemViewModel> UpdateAsync(MenuItemEditViewModel model)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(model.Id) ?? throw new InvalidOperationException($"There is no menu item with id {model.Id}");

            _mapper.Map(model, menuItem);
            _menuItemRepository.Update(menuItem);
            await _menuItemRepository.CommitAsync();

            return _mapper.Map<MenuItemViewModel>(menuItem);
        }
    }
}
