using System;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.AOP.Handler;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IO;
using Richfit.Garnet.Module.Attachment.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;

namespace webapp.Handlers.Mobile;

public class attachment : IHttpHandler
{
	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		if (!string.IsNullOrEmpty(context.Request["ATTACHMENT_ID"]))
		{
			Guid attachmentID = new Guid(context.Request["ATTACHMENT_ID"]);
			ResponseData result = AccessManager.ServiceAccess("Mobile", "L_GetAttachmentById", new
			{
				ATTACHMENT_ID = attachmentID
			}.JsonSerialize());
			AttachmentDTO attachmentDTO = result.Data.JsonDeserialize<AttachmentDTO>(new JsonConverter[0]);
			DownloadFromFolder(attachmentDTO);
		}
	}

	private void DownloadFromFolder(AttachmentDTO attachmentDTO)
	{
		Stream stream = null;
		string absolutelyPath = string.Empty;
		absolutelyPath = ((!attachmentDTO.FILE_NETWORK_PATH.IsNullOrEmpty()) ? $"{attachmentDTO.FILE_NETWORK_PATH}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}" : $"{AppDomain.CurrentDomain.BaseDirectory}{attachmentDTO.FILE_RELATIVE_PATH}{attachmentDTO.ATTACHMENT_ID}");
		if (File.Exists(absolutelyPath))
		{
			try
			{
				stream = new FileStream(absolutelyPath, FileMode.Open, FileAccess.Read, FileShare.Read);
				AttachmentHepler.DownloadStream(stream, attachmentDTO.ATTACHMENT_NAME, attachmentDTO.ATTACHMENT_TYPE);
				return;
			}
			catch (Exception ex)
			{
				throw new CustomCodeException("Fundation.Public.V_0003", ex);
			}
			finally
			{
				stream?.Close();
			}
		}
		throw new ValidationException("Fundation.Public.V_0004");
	}
}
