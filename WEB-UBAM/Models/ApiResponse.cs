using System.Text.Json.Serialization;

namespace WEB_UBAM.Models;

public class ApiResponse<T>
{
    [JsonPropertyName("$values")]
    public List<T> Values { get; set; }
}