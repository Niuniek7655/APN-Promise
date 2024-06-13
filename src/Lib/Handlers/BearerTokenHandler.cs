using System.Net.Http.Headers;

namespace Lib.Handlers;

internal class BearerTokenHandler : DelegatingHandler
{
    private readonly Func<Task<string>> _getToken;

    internal BearerTokenHandler(Func<Task<string>> getToken)
    {
        _getToken = getToken;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _getToken();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}