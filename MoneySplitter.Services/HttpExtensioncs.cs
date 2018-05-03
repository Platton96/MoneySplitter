using System.Net.Http;

namespace MoneySplitter.Services
{
    public static class HttpExtensioncs
    {
        public static void AddCredentials(this HttpClient client)
        {
            var dependencies = new Dependencies();
            client.DefaultRequestHeaders.Add(Defines.Api.HeaderNames.USER_NAME, dependencies.MembershipService.CurrentUser.Email);
            client.DefaultRequestHeaders.Add(Defines.Api.HeaderNames.TOKEN, dependencies.MembershipService.CurrentUser.Token);
        }
    }
}
