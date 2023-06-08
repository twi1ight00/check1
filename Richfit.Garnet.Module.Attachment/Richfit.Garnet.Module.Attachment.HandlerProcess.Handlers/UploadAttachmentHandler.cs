using System;
using System.IO;
using System.Web;
using Microsoft.JScript;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Attachment.Application.DTO;
using Richfit.Garnet.Module.Attachment.Application.Services.Attachment;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;

namespace Richfit.Garnet.Module.Attachment.HandlerProcess.Handlers;

public class UploadAttachmentHandler : IHttpHandler
{
	private IAttachmentService attachmentService = ServiceLocator.Instance.GetService<IAttachmentService>();

	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		string absolutelyPath = null;
		string strAttachmentDTO = GlobalObject.unescape(context.Request.QueryString["Attachment"]);
		AttachmentDTO attachmentDTO = strAttachmentDTO.JsonDeserialize<AttachmentDTO>(new JsonConverter[0]);
		attachmentDTO.ATTACHMENT_SIZE = context.Request.InputStream.Length;
		string fileExtension = Path.GetExtension(attachmentDTO.ATTACHMENT_NAME);
		if (fileExtension.ToLower() == ".dll" || fileExtension.ToLower() == ".exe")
		{
			throw new ValidationException("Fundation.Public.V_0001");
		}
		absolutelyPath = ((!attachmentDTO.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{attachmentDTO.FILE_NETWORK_PATH}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}" : $"{AppDomain.CurrentDomain.BaseDirectory}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}");
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

	/// <summary>
	/// 将Stream 转成  Byte[]
	/// </summary>
	/// <param name="stream"></param>
	/// <returns></returns>
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
