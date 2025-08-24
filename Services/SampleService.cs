using backend.Models;
using System.Collections.Generic;

namespace backend.Services
{
    public interface ISampleService
    {
        IEnumerable<SampleModel> GetSamples();
    }

    public class SampleService : ISampleService
    {
        public IEnumerable<SampleModel> GetSamples()
        {
            return new List<SampleModel>
            {
                new SampleModel { Id = 1, Value = "Sample 1" },
                new SampleModel { Id = 2, Value = "Sample 2" }
            };
        }
    }
}
