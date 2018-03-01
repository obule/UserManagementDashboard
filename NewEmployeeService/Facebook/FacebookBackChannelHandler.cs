using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace NewEmployeeService.Facebook

{
    //public class FacebookOauthResponse
    //{
    //    public string access_token { get; set; }
    //    public string token_type { get; set; }
    //    public int expires_in { get; set; }
    //}

    //public class FacebookBackChannelHandler : HttpClientHandler
    //{
    //    protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    //    {
    //        var result = await base.SendAsync(request, cancellationToken);
    //        if (!request.RequestUri.AbsolutePath.Contains("access_token"))
    //            return result;

    //        // For the access token we need to now deal with the fact that the response is now in JSON format, not form values. Owin looks for form values.
    //        var content = await result.Content.ReadAsStringAsync();
    //        var facebookOauthResponse = JsonConvert.DeserializeObject<FacebookOauthResponse>(content);

    //        var outgoingQueryString = HttpUtility.ParseQueryString(string.Empty);
    //        outgoingQueryString.Add(nameof(facebookOauthResponse.access_token), facebookOauthResponse.access_token);
    //        outgoingQueryString.Add(nameof(facebookOauthResponse.expires_in), facebookOauthResponse.expires_in + string.Empty);
    //        outgoingQueryString.Add(nameof(facebookOauthResponse.token_type), facebookOauthResponse.token_type);
    //        var postdata = outgoingQueryString.ToString();

    //        var modifiedResult = new HttpResponseMessage(HttpStatusCode.OK)
    //        {
    //            Content = new StringContent(postdata)
    //        };

    //        return modifiedResult;
    //    }
    //}

    public class FacebookBackChannelHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.RequestUri.AbsolutePath.Contains("/oauth"))
            {
                request.RequestUri = new Uri(request.RequestUri.AbsolutePath.Replace("?access_token", "&access_token"));
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}

