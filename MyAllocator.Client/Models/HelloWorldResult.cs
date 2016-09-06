using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyAllocator.Client.Models
{
    [DataContract]
    public class HelloWorldResult : IMyAllocatorResult
    {
        [DataMember(Name = "callback_delay")]
        public int CallbackDelay { get; set; }

        [DataMember(Name = "hello")]
        public string Hello { get; set; }


        [DataMember(Name = "Errors")]
        public List<MyAllocatorError> Errors { get; set; }
    }
}
