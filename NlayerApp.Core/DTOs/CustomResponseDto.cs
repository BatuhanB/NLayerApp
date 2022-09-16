using System.Text.Json.Serialization;

namespace NLayerApp.Core.DTOs;

public class CustomResponseDto<T>
{
    public T Data { get; set; }
    [JsonIgnore]
    public List<string> Errors { get; set; }
    public string SuccessMessage { get; set; }
    public int StatusCode { get; set; }

    //Static Factory Design Pattern
    //Instead of using separate classes for method we use static methods in class just like that
    public static CustomResponseDto<T> Success(int statusCode, T data, string successMessage)
    {
        return new CustomResponseDto<T>() { StatusCode = statusCode, SuccessMessage = successMessage, Data = data };
    }
    public static CustomResponseDto<T> Success(int statusCode, T data)
    {
        return new CustomResponseDto<T>() { StatusCode = statusCode, Data = data };
    }
    public static CustomResponseDto<T> Success(int statusCode)
    {
        return new CustomResponseDto<T>() { StatusCode = statusCode };
    }
    public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
    {
        return new CustomResponseDto<T>() { StatusCode = statusCode, Errors = errors };
    }
    public static CustomResponseDto<T> Fail(int statusCode, string error)
    {
        return new CustomResponseDto<T>() { StatusCode = statusCode, Errors = new List<string> { error } };
    }
}