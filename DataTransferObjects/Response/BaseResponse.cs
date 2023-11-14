namespace GoodMarket.DataTransferObjects.Response;

public class BaseResponse<T>
{
    public bool Status { get; set; }
    public T Data { get; set; }
    public int ErrorCode { get; set; }
    public string Message { get; set; }

    public BaseResponse()
    {
        Status = true; // Assuming success by default
        ErrorCode = 0; // Assuming no error by default
    }

    public static BaseResponse<T> Success(T data, string message = "Success")
    {
        return new BaseResponse<T>
        {
            Data = data,
            Message = message
        };
    }

    public static BaseResponse<T> Fail(int errorCode, string message)
    {
        return new BaseResponse<T>
        {
            Status = false,
            ErrorCode = errorCode,
            Message = message
        };
    }
}
