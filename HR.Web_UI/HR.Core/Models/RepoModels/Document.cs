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
        public string Name { get; set; }
        public string Type { get; set; }
        public byte[] Content { get; set; }
        public string Description { get; set; }

        public long PersonId { get; set; }
    }
}
