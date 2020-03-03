namespace BlogApi
{
    public class JwtCredentials
    {
        public string ValidIssuer {get;set;}
        public string ValidAudience {get;set;}
        public string Key {get;set;}
        public int Expires {get;set;}
    }
}