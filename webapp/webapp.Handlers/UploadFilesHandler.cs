using System;
using System.IO;
using System.Web;
using Microsoft.JScript;

namespace webapp.Handlers;

public class UploadFilesHandler : IHttpHandler
{
	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		string filePath = null;
		context.Response.ContentType = "text/plain";
		string value = null;
		Result result = new Result();
		string json = "";
		string filename = GlobalObject.unescape(context.Request.QueryString["File"]);
		if (context.Request.InputStream.Length < 0 || filename == null || filename == "")
		{
			json = "false";
		}
		else
		{
			filePath = string.Format("{0}{1}{2}", AppDomain.CurrentDomain.BaseDirectory, "upload\\", filename);
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
			json = SaveFile(filePath, StreamToBytes(context.Request.InputStream));
		}
		context.Response.Write(json);
		context.Response.End();
	}

	public string SaveFile(string filePath, byte[] data)
	{
		Result result = new Result();
		try
		{
			FileMode fm = (File.Exists(filePath) ? FileMode.Append : FileMode.OpenOrCreate);
			using (FileStream fs = new FileStream(filePath, fm))
			{
				fs.Write(data, 0, data.Length);
			}
			return "true";
		}
		catch (Exception)
		{
			return "false";
		}
	}

	private byte[] StreamToBytes(Stream stream)
	{
		stream.Position = 0L;
		byte[] buffer = new byte[stream.Length];
		for (int totalBytesCopied = 0; totalBytesCopied < stream.Length; totalBytesCopied += stream.Read(buffer, totalBytesCopied, System.Convert.ToInt32(stream.Length) - totalBytesCopied))
		{
		}
		return buffer;
	}
}
