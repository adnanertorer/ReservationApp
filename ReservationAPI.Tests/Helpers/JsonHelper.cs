using System.Text;
using System.Text.Json;

namespace ReservationAPI.Tests.Helpers
{
    public static class JsonHelper
    {
        private const string _jsonMediaType = "application/json";

        public static StringContent GetJsonStringContent<T>(T model)
    => new(JsonSerializer.Serialize(model), Encoding.UTF8, _jsonMediaType);

    }
}
