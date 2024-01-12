namespace Helmer.Shared.Tools.Models;

public class ChatApiSettings
{
	public string ClientName { get; set; }
	public string BaseUrl { get; set; }

	public string ApiTokenKey { get; set; }

	public string ApiTokenValue { get; set; }
		
	public string WebSocketUrl { get; set; }
		
	//public ChatApiSettings()
	//{
	//	//Todo: Validate: BaseUrl must end with slash!
	//}
}