using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAZ_KST_IS.Models.Domain.Entities;
using UAZ_KST_IS.Models.ViewModels.MenuCategory;
using UAZ_KST_IS.Models.ViewModels.MenuItem;

namespace UAZ_KST_IS.Business.Profiles
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuItem, MenuItemViewModel>()
                .ForMember(dest => dest.MenuCategoryTitle, opt => opt.MapFrom(s => s.MenuCategory.Title));

            CreateMap<MenuItemCreateViewModel, MenuItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<MenuItemEditViewModel, MenuItem>();
        }
    }
}
