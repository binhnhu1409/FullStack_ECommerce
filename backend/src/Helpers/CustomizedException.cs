namespace backend.src.Helpers;

using System.Net;

public class CustomizedException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public string ErrorMessage { get; set; }

    public CustomizedException (HttpStatusCode statusCode, string errorMessage)
    {
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }

    public static CustomizedException NotFound(string errorMessage = "Not Found")
    {
        return new CustomizedException(HttpStatusCode.NotFound, errorMessage);
    }

    public static CustomizedException Unauthorized(string errorMessage = "Unauthorized")
    {
        return new CustomizedException(HttpStatusCode.Unauthorized, errorMessage);
    }

    public static CustomizedException BadRequest(string errorMessage = "Bad request")
    {
        return new CustomizedException(HttpStatusCode.BadRequest, errorMessage);
    }
}
