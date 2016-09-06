using System.Collections.Generic;

namespace MyAllocator.Client.Models
{
    public interface IMyAllocatorResult
    {
        List<MyAllocatorError> Errors { get; set; }
    }
}
