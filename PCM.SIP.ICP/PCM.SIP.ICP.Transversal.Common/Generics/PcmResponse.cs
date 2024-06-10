using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.Transversal.Common.Generics
{
    public class PcmResponse
    {
        public int Code { get; set; }
        public string? Message { get; set; }
        public bool error { get; set; }
        public object? Payload { get; set; }
    }
}
