using HR.Core.BasicContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.Models.RepoModels
{
    public class Document : BaseEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
        public virtual byte[] Content { get; set; }
        public virtual string Description { get; set; }

        public virtual long PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
