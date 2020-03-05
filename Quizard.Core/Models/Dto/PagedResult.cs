using System.Collections.Generic;

namespace Quizard.Core.Models.Dto
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public PagedResultMeta Meta { get; set; }
    }
}
