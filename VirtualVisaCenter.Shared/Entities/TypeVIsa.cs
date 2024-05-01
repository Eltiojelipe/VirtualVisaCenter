using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVisaCenter.Shared.Entities
{
    public class TypeVIsa
    {
        public int Id { get; set; }

        public ICollection<Rate> Rate { get; set; }

        public ICollection<Request> Request { get; set; }
    }
}
