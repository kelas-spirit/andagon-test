using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class Response
    {
        public TransactionStatus Status { get; set; }
        public string FailedMsg { get; set; }
    }

    public enum TransactionStatus
    {
        Failed = 0,
        Succeeded = 1
    }
}
