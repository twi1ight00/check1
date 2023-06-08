using System.Linq;
using System.Web;

namespace Richfit.Garnet.Module.UEditor;

/// <summary>
/// Crawler 的摘要说明
/// </summary>
public class CrawlerHandler : Handler
{
	private string[] Sources;

	private Crawler[] Crawlers;

	public CrawlerHandler(HttpContext context)
		: base(context)
	{
	}

	public override void Process()
	{
		Sources = base.Request.Form.GetValues("source[]");
		if (Sources == null || Sources.Length == 0)
		{
			WriteJson(new
			{
				state = "参数错误：没有指定抓取源"
			});
			return;
		}
		Crawlers = Sources.Select((string x) => new Crawler(x, base.Server).Fetch()).ToArray();
		WriteJson(new
		{
			state = "SUCCESS",
			list = Crawlers.Select((Crawler x) => new
			{
				state = x.State,
				source = x.SourceUrl,
				url = x.ServerUrl
			})
		});
	}
}
