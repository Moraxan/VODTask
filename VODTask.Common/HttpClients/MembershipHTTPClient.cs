namespace VODTask.Common.HttpClients;

public class MembershipHTTPClient
{
	public HttpClient Client { get; }
	public MembershipHTTPClient(HttpClient client)
	{
		Client =  client;
	}

	
}
