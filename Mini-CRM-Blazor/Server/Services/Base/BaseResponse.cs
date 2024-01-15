namespace Mini_CRM_Blazor.Server.Services.Base
{
    public class BaseResponse<T>
    {
        public BaseResponse(T objeto)
        {
            Sucess = true;
            Message = string.Empty;
            Content = objeto;
        }

        public BaseResponse(string errorMessage)
        {
            Sucess = false;
            Message = errorMessage;
            Content = default;
        }

        public bool Sucess { get; private set; }
        public string Message { get; private set; }
        public T? Content { get; private set; }
    }
}
