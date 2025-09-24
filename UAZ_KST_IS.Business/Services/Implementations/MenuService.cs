using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAZ_KST_IS.Business.Repositories;
using UAZ_KST_IS.Business.Services.Interfaces;
using UAZ_KST_IS.Models.Domain.Entities;
using UAZ_KST_IS.Models.ViewModels.Menu;

namespace UAZ_KST_IS.Business.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _menuRepository;
        private readonly IMapper _mapper;
        public MenuService(IRepository<Menu> menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<MenuViewModel> CreateAsync(MenuCreateViewModel model)
        {
            var entity = _mapper.Map<Menu>(model);

            await _menuRepository.AddAsync(entity);
            await _menuRepository.CommitAsync();
            return _mapper.Map<MenuViewModel>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var menu = await _menuRepository.GetByIdAsync(id) ?? throw new InvalidOperationException($"There is no menu with id {id}");

            _menuRepository.Remove(menu);
            await _menuRepository.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<MenuViewModel>> GetAllAsync()
        {
            var menus = await _menuRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuViewModel>>(menus);
        }

        public async Task<MenuViewModel> GetByIdAsync(Guid id)
        {
            var menu = await _menuRepository.GetByIdAsync(id) ?? throw new InvalidOperationException($"There is no menu with id {id}");

            return _mapper.Map<MenuViewModel>(menu);
        }

        public async Task<MenuViewModel> GetFullMenuByIdAsync(Guid id)
        {
            var menu = await _menuRepository.Query()
                .Include(m => m.MenuCategories)
                    .ThenInclude(mc => mc.MenuItems)
                        .ToListAsync();
            return _mapper.Map<MenuViewModel>(menu);
        }

        public async Task<MenuViewModel> UpdateAsync(MenuEditViewModel model)
        {
            var menu = await _menuRepository.GetByIdAsync(model.Id) ?? throw new InvalidOperationException($"There is no menu with id {model.Id}");

            _mapper.Map(model, menu);
            _menuRepository.Update(menu);
            await _menuRepository.CommitAsync();

            return _mapper.Map<MenuViewModel>(menu);
        }
    }
}
