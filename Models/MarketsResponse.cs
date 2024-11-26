using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWPF.Models
{
    public class MarketsResponse
    {
        public Market[] Data { get; set; } = [];
        public long Timestamp { get; set; }
    }
}
