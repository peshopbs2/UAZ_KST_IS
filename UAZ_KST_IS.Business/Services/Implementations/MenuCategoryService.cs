using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UAZ_KST_IS.Business.Repositories;
using UAZ_KST_IS.Business.Services.Interfaces;
using UAZ_KST_IS.Models.Domain.Entities;
using UAZ_KST_IS.Models.ViewModels.Menu;
using UAZ_KST_IS.Models.ViewModels.MenuCategory;

namespace UAZ_KST_IS.Business.Services.Implementations
{
    public class MenuCategoryService : IMenuCategoryService
    {
        private readonly IRepository<MenuCategory> _menuCategoryRepository;
        private readonly IMapper _mapper;
        public MenuCategoryService(IRepository<MenuCategory> menuCategoryRepository, IMapper mapper)
        {
            _menuCategoryRepository = menuCategoryRepository;
            _mapper = mapper;
        }

        public async Task<MenuCategoryViewModel> CreateAsync(MenuCategoryCreateViewModel model)
        {
            var entity = _mapper.Map<MenuCategory>(model);

            await _menuCategoryRepository.AddAsync(entity);
            await _menuCategoryRepository.CommitAsync();
            return _mapper.Map<MenuCategoryViewModel>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var menuCategory = await _menuCategoryRepository.GetByIdAsync(id) ?? throw new InvalidOperationException($"There is no menu category with id {id}");

            _menuCategoryRepository.Remove(menuCategory);
            await _menuCategoryRepository.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<MenuCategoryViewModel>> GetAllAsync()
        {
            var menuCategories = await _menuCategoryRepository
                .GetAllAsync(mc => mc.Menu);
            return _mapper.Map<IEnumerable<MenuCategoryViewModel>>(menuCategories);
        }

        public async Task<MenuCategoryViewModel> GetByIdAsync(Guid id)
        {
            var menuCategory = await _menuCategoryRepository.GetByIdAsync(id, mc => mc.Menu) ?? throw new InvalidOperationException($"There is no menu category with id {id}");

            return _mapper.Map<MenuCategoryViewModel>(menuCategory);
        }

        public async Task<IEnumerable<MenuCategoryViewModel>> GetByMenuIdAsync(Guid menuId)
        {
            var menuCategories = await _menuCategoryRepository.FindAsync(mc => mc.MenuId == menuId, mc => mc.Menu);
            return _mapper.Map<IEnumerable<MenuCategoryViewModel>>(menuCategories);
        }

        public async Task<MenuCategoryViewModel> UpdateAsync(MenuCategoryEditViewModel model)
        {
            var menuCategory = await _menuCategoryRepository.GetByIdAsync(model.Id) ?? throw new InvalidOperationException($"There is no menu category with id {model.Id}");

            _mapper.Map(model, menuCategory);
            _menuCategoryRepository.Update(menuCategory);
            await _menuCategoryRepository.CommitAsync();

            return _mapper.Map<MenuCategoryViewModel>(menuCategory);
        }
    }
}
