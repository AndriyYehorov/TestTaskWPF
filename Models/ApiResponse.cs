using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF;

namespace TestTaskWPF.Models
{
    public class ApiResponse
    {
        public Coin[] Data { get; set; } = [];
        public long Timestamp { get; set; }
    }
}
