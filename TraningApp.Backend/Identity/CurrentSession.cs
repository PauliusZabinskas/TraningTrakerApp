namespace TraningApp.Backend.Services;

public class CurrentSession : ICurrentSession
{
    public int? GetSession()
    {
        return 1;
    }
}