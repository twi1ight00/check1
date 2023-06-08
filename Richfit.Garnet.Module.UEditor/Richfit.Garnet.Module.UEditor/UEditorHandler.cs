using System.Web;

namespace Richfit.Garnet.Module.UEditor;

public class UEditorHandler : IHttpHandler
{
	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		Handler action = null;
		(context.Request["action"] switch
		{
			"config" => new ConfigHandler(context), 
			"uploadimage" => new UploadHandler(context, new UploadConfig
			{
				AllowExtensions = Config.GetStringList("imageAllowFiles"),
				PathFormat = Config.GetString("imagePathFormat"),
				SizeLimit = Config.GetInt("imageMaxSize"),
				UploadFieldName = Config.GetString("imageFieldName")
			}), 
			"uploadscrawl" => new UploadHandler(context, new UploadConfig
			{
				AllowExtensions = new string[1] { ".png" },
				PathFormat = Config.GetString("scrawlPathFormat"),
				SizeLimit = Config.GetInt("scrawlMaxSize"),
				UploadFieldName = Config.GetString("scrawlFieldName"),
				Base64 = true,
				Base64Filename = "scrawl.png"
			}), 
			"uploadvideo" => new UploadHandler(context, new UploadConfig
			{
				AllowExtensions = Config.GetStringList("videoAllowFiles"),
				PathFormat = Config.GetString("videoPathFormat"),
				SizeLimit = Config.GetInt("videoMaxSize"),
				UploadFieldName = Config.GetString("videoFieldName")
			}), 
			"uploadfile" => new UploadHandler(context, new UploadConfig
			{
				AllowExtensions = Config.GetStringList("fileAllowFiles"),
				PathFormat = Config.GetString("filePathFormat"),
				SizeLimit = Config.GetInt("fileMaxSize"),
				UploadFieldName = Config.GetString("fileFieldName")
			}), 
			"listimage" => new ListFileManager(context, Config.GetString("imageManagerListPath"), Config.GetStringList("imageManagerAllowFiles")), 
			"listfile" => new ListFileManager(context, Config.GetString("fileManagerListPath"), Config.GetStringList("fileManagerAllowFiles")), 
			"catchimage" => new CrawlerHandler(context), 
			_ => new NotSupportedHandler(context), 
		}).Process();
	}
}
