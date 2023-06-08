using System;
using System.IO;
using System.Web;
using Microsoft.JScript;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Application.Services;

namespace Richfit.Garnet.Module.ITManagement.HandlerProcess.Handlers;

public class UploadITAttachmentHandler : IHttpHandler
{
	private IITSupportService itsupportservice = ServiceLocator.Instance.GetService<IITSupportService>();

	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		string absolutelyPath = null;
		string strAttachmentDTO = GlobalObject.unescape(context.Request.QueryString["ITAttachment"]);
		IT_SUPPORTMANGDTO itattachmentDTO = strAttachmentDTO.JsonDeserialize<IT_SUPPORTMANGDTO>(new JsonConverter[0]);
		itattachmentDTO.IT_SUPPORTMANG_SIZE = context.Request.InputStream.Length;
		string fileExtension = Path.GetExtension(itattachmentDTO.IT_SUPPORTMANG_NAME);
		absolutelyPath = ((!itattachmentDTO.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{itattachmentDTO.FILE_NETWORK_PATH}{itattachmentDTO.FILE_RELATIVE_PATH}{itattachmentDTO.IT_SUPPORTMANG_ID}" : $"{AppDomain.CurrentDomain.BaseDirectory}{itattachmentDTO.FILE_RELATIVE_PATH}{itattachmentDTO.IT_SUPPORTMANG_ID}");
		SaveFile(absolutelyPath, StreamToBytes(context.Request.InputStream));
	}

	private void SaveFile(string filePath, byte[] data)
	{
		FileMode fm = (File.Exists(filePath) ? FileMode.Append : FileMode.OpenOrCreate);
		using FileStream fs = new FileStream(filePath, fm);
		fs.Write(data, 0, data.Length);
	}

	private byte[] Base64ToBytes(string s)
	{
		return System.Convert.FromBase64String(s);
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
