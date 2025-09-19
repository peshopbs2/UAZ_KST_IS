using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAZ_KST_IS.Models.Domain.Entities;
using UAZ_KST_IS.Models.ViewModels.Menu;

namespace UAZ_KST_IS.Business.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuViewModel>();

            CreateMap<MenuCreateViewModel, Menu>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<MenuEditViewModel, Menu>();
        }
    }
}
