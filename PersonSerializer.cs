using System;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace net3_json_test
{
    public class PersonSerializer
    {
        private Person _person = new Person();
        private string _json = string.Empty;
        private JsonSerializerOptions? _options;

        [GlobalSetup]
        public void Setup()
        {
            _options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            Random random = new Random();

            _person = new Person()
            {
                FirstName = $"Joe-{random.Next(0, 3000)}",
                LastName = $"Soap-{random.Next(0, 3000)}",
                Age = random.Next(10, 90),
            };

            _json = JsonSerializer.Serialize(_person, _options);
        }

        [Benchmark]
        public string Serialize() => JsonSerializer.Serialize(_person, _options);
        [Benchmark]
        public Person? Deserialize() => JsonSerializer.Deserialize<Person>(_json);
    }
}