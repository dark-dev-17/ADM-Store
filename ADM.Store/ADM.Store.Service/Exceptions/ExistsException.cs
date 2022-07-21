namespace ADM.Store.Service.Exceptions
{
    public class ExceptionService: Exception
    {
        public int ErrorCode { get; private set; }
        public string LevelError { get; private set; }
        public string ErrorMessage { get; private set; }

        public ExceptionService(int errorCode, string levelError, string message): base(message) 
        { 
            this.ErrorCode = errorCode;
            this.LevelError = levelError;
            this.ErrorMessage = message;
        }
    }
}
