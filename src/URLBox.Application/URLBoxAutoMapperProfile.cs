﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLBox
{
    public class URLBoxAutoMapperProfile : Profile
    {
        public URLBoxAutoMapperProfile()
        {
            CreateMap<Article, ArticleDto>().ForMember(p => p.Tags, opt => opt.Ignore());
            //使用ForMember(...)来忽略掉Id属性
            CreateMap<ArticleDto, Article>().ForMember(p => p.Id, opt => opt.Ignore()).ForMember(p => p.Tags, opt => opt.Ignore()).ForMember(p => p.CreationTime, opt => opt.Ignore());
        }
    }
}
