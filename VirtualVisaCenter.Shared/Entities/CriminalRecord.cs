using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVisaCenter.Shared.Entities
{
    public class CriminalRecord
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
    }
}
