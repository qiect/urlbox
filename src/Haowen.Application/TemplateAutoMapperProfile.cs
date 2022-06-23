using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haowen
{
    public class TemplateAutoMapperProfile : Profile
    {
        public TemplateAutoMapperProfile()
        {
            CreateMap<Test, TestDto>();
            //使用ForMember(...)来忽略掉Id属性
            CreateMap<TestDto, Test>().ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}
