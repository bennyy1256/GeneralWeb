using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using General.Service.ParameterDto;
using General.Model;

namespace General.Service.Implement.Mappings
{
    public class ServiceProfile : Profile
    {
        protected override void Configure()
        { 
            CreateMap<MemberParameterDto, MemberModel>()
                .ForMember(d => d.MemberId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Status, o => o.Ignore());
        }

        public ServiceProfile()
        {
            
        }
    }
}
