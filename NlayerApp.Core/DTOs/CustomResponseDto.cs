using System.Text.Json.Serialization;

namespace NLayerApp.Core.DTOs;

public class CustomResponseDto<T>
{
    public T Data { get; set; }
    [JsonIgnore]
    public List<string> Errors { get; set; }
    public int StatusCOde { get; set; }

    //Static Factory Design Pattern
    //Instead of using separate classes for method we use static methods in class just like that
    public static CustomResponseDto<T> Success(int statusCode, T data)
    {
        return new CustomResponseDto<T>() { Data = data, StatusCOde = statusCode };
    }
    public static CustomResponseDto<T> Success(int statusCode)
    {
        return new CustomResponseDto<T>() { StatusCOde = statusCode };
    }
    public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
    {
        return new CustomResponseDto<T>() { StatusCOde = statusCode, Errors = errors };
    }
    public static CustomResponseDto<T> Fail(int statusCode, string error)
    {
        return new CustomResponseDto<T>() { StatusCOde = statusCode, Errors = new List<string> { error } };
    }
}