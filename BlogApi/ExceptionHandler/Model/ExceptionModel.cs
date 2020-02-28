namespace BlogApi.ExceptionHandler.Model
{
    public class ExceptionModel
    {
        public int Status{get;set;}= 500;
        public string Message {get;set;}
        public string Source {get;set;}
    }
}