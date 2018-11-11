using System;

namespace HW7.Models
{
    public class RequestLog
    {

        public int RequestId { get; set; }

        public DateTime DateInserted { get; set; }

        public string RequestUrl { get; set; }

        public string RequestType { get; set; }

        public string Word { get; set; }

        public string Ip { get; set; }

        public string Browser { get; set; }
    }
}