using System.Text.Json.Serialization;

namespace NLayerApp.Core.DTOs;

public class NoContentDto
{
    [JsonIgnore]
    public List<string> Errors { get; set; }
    public int StatusCode { get; set; }
    public string SuccessMessage { get; set; }

    //Static Factory Design Pattern
    //Instead of using separate classes for method we use static methods in class just like that
    public static NoContentDto Success(int statusCode,string successMessage)
    {
        return new NoContentDto() { StatusCode = statusCode,SuccessMessage = successMessage};
    }
    public static NoContentDto Success(int statusCode)
    {
        return new NoContentDto() { StatusCode = statusCode,};
    }
    public static NoContentDto Fail(int statusCode, List<string> errors)
    {
        return new NoContentDto { StatusCode = statusCode, Errors = errors };
    }
    public static NoContentDto Fail(int statusCode, string error)
    {
        return new NoContentDto { StatusCode = statusCode, Errors = new List<string> { error } };
    }
}