using System;
using System.IO;
using System.Net;
using System.Web;

namespace Richfit.Garnet.Module.UEditor;

public class Crawler
{
	public string SourceUrl { get; set; }

	public string ServerUrl { get; set; }

	public string State { get; set; }

	private HttpServerUtility Server { get; set; }

	public Crawler(string sourceUrl, HttpServerUtility server)
	{
		SourceUrl = sourceUrl;
		Server = server;
	}

	public Crawler Fetch()
	{
		HttpWebRequest request = WebRequest.Create(SourceUrl) as HttpWebRequest;
		using HttpWebResponse response = request.GetResponse() as HttpWebResponse;
		if (response.StatusCode != HttpStatusCode.OK)
		{
			State = string.Concat("Url returns ", response.StatusCode, ", ", response.StatusDescription);
			return this;
		}
		if (response.ContentType.IndexOf("image") == -1)
		{
			State = "Url is not an image";
			return this;
		}
		ServerUrl = PathFormatter.Format(Path.GetFileName(SourceUrl), Config.GetString("catcherPathFormat"));
		string savePath = Server.MapPath(ServerUrl);
		if (!Directory.Exists(Path.GetDirectoryName(savePath)))
		{
			Directory.CreateDirectory(Path.GetDirectoryName(savePath));
		}
		try
		{
			Stream stream = response.GetResponseStream();
			BinaryReader reader = new BinaryReader(stream);
			byte[] bytes;
			using (MemoryStream ms = new MemoryStream())
			{
				byte[] buffer = new byte[4096];
				int count;
				while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
				{
					ms.Write(buffer, 0, count);
				}
				bytes = ms.ToArray();
			}
			File.WriteAllBytes(savePath, bytes);
			State = "SUCCESS";
		}
		catch (Exception e)
		{
			State = "抓取错误：" + e.Message;
		}
		return this;
	}
}
