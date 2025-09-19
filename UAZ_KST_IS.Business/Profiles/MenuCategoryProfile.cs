using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAZ_KST_IS.Models.Domain.Entities;
using UAZ_KST_IS.Models.ViewModels.Menu;
using UAZ_KST_IS.Models.ViewModels.MenuCategory;

namespace UAZ_KST_IS.Business.Profiles
{
    public class MenuCategoryProfile : Profile
    {
        public MenuCategoryProfile()
        {
            CreateMap<MenuCategory, MenuCategoryViewModel>()
                .ForMember(dest => dest.MenuTitle, opt => opt.MapFrom(s => s.Menu.Title));

            CreateMap<MenuCategoryCreateViewModel, MenuCategory>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<MenuCategoryEditViewModel, MenuCategory>();
        }
    }
}
