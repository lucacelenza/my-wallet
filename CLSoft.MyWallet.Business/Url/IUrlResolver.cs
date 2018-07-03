namespace CLSoft.MyWallet.Business.Url
{
    public interface IUrlResolver
    {
        string ResolveUrl(string action, string controller, object routeValues);
    }
}