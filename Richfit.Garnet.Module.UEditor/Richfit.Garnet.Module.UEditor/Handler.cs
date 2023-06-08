using System.Web;
using Newtonsoft.Json;

namespace Richfit.Garnet.Module.UEditor;

/// <summary>
/// Handler 的摘要说明
/// </summary>
public abstract class Handler
{
	public HttpRequest Request { get; private set; }

	public HttpResponse Response { get; private set; }

	public HttpContext Context { get; private set; }

	public HttpServerUtility Server { get; private set; }

	public Handler(HttpContext context)
	{
		Request = context.Request;
		Response = context.Response;
		Context = context;
		Server = context.Server;
	}

	public abstract void Process();

	protected void WriteJson(object response)
	{
		string jsonpCallback = Request["callback"];
		string json = JsonConvert.SerializeObject(response);
		if (string.IsNullOrWhiteSpace(jsonpCallback))
		{
			Response.AddHeader("Content-Type", "text/plain");
			Response.Write(json);
		}
		else
		{
			Response.AddHeader("Content-Type", "application/javascript");
			Response.Write($"{jsonpCallback}({json});");
		}
		Response.End();
	}
}
