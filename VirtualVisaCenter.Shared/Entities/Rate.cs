using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVisaCenter.Shared.Entities
{
    public class Rate
    {
        public int id {  get; set; }

        public Country Country { get; set; }

        public TypeVIsa TypeVIsa { get; set; }
    }
}
