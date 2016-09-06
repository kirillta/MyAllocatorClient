using System.Runtime.Serialization;

namespace MyAllocator.Client.Models
{
    [DataContract]
    public class MyAllocatorError
    {
        [DataMember(Name = "ErrorId")]
        public int ErrorId { get; set; }

        [DataMember(Name = "ErrorMsg")]
        public string ErrorMsg { get; set; }

        [DataMember(Name = "ErrorTicket")]
        public string ErrorTicket { get; set; }
    }
}
