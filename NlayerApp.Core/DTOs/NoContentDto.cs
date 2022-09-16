using System.Text.Json.Serialization;

namespace NLayerApp.Core.DTOs;

public class NoContentDto
{
    [JsonIgnore]
    public List<string> Errors { get; set; }
    public int StatusCOde { get; set; }

    //Static Factory Design Pattern
    //Instead of using separate classes for method we use static methods in class just like that
    public static NoContentDto Success(int statusCode)
    {
        return new NoContentDto() { StatusCOde = statusCode };
    }
    public static NoContentDto Fail(int statusCode, List<string> errors)
    {
        return new NoContentDto { StatusCOde = statusCode, Errors = errors };
    }
    public static NoContentDto Fail(int statusCode, string error)
    {
        return new NoContentDto { StatusCOde = statusCode, Errors = new List<string> { error } };
    }
}