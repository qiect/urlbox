using Haowen.Repositories;
using Haowen.ToolKits.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haowen
{
    public class TagService : ServiceBase, ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<ServiceResult<string>> GetTagAsync()
        {
            var tags = await _tagRepository.GetQueryableAsync();
            var tagDtos = tags.OrderBy(p => p.Name).Select(p => p.Name).ToArray();
            var result = new ServiceResult<string>();
            result.IsSuccess(JsonConvert.SerializeObject(tagDtos, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            }));
            return result;
        }
    }
}
