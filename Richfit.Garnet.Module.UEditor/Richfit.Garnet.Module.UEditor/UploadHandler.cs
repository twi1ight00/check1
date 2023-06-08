using System;
using System.IO;
using System.Linq;
using System.Web;

namespace Richfit.Garnet.Module.UEditor;

/// <summary>
/// UploadHandler 的摘要说明
/// </summary>
public class UploadHandler : Handler
{
	public UploadConfig UploadConfig { get; private set; }

	public UploadResult Result { get; private set; }

	public UploadHandler(HttpContext context, UploadConfig config)
		: base(context)
	{
		UploadConfig = config;
		Result = new UploadResult
		{
			State = UploadState.Unknown
		};
	}

	public override void Process()
	{
		byte[] uploadFileBytes = null;
		string uploadFileName = null;
		if (UploadConfig.Base64)
		{
			uploadFileName = UploadConfig.Base64Filename;
			uploadFileBytes = Convert.FromBase64String(base.Request[UploadConfig.UploadFieldName]);
		}
		else
		{
			HttpPostedFile file = base.Request.Files[UploadConfig.UploadFieldName];
			uploadFileName = file.FileName;
			if (!CheckFileType(uploadFileName))
			{
				Result.State = UploadState.TypeNotAllow;
				WriteResult();
				return;
			}
			if (!CheckFileSize(file.ContentLength))
			{
				Result.State = UploadState.SizeLimitExceed;
				WriteResult();
				return;
			}
			uploadFileBytes = new byte[file.ContentLength];
			try
			{
				file.InputStream.Read(uploadFileBytes, 0, file.ContentLength);
			}
			catch (Exception)
			{
				Result.State = UploadState.NetworkError;
				WriteResult();
			}
		}
		Result.OriginFileName = uploadFileName;
		string savePath = PathFormatter.Format(uploadFileName, UploadConfig.PathFormat);
		string localPath = base.Server.MapPath(savePath);
		try
		{
			if (!Directory.Exists(Path.GetDirectoryName(localPath)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(localPath));
			}
			File.WriteAllBytes(localPath, uploadFileBytes);
			Result.Url = savePath;
			Result.State = UploadState.Success;
		}
		catch (Exception e)
		{
			Result.State = UploadState.FileAccessError;
			Result.ErrorMessage = e.Message;
		}
		finally
		{
			WriteResult();
		}
	}

	private void WriteResult()
	{
		WriteJson(new
		{
			state = GetStateMessage(Result.State),
			url = Result.Url,
			title = Result.OriginFileName,
			original = Result.OriginFileName,
			error = Result.ErrorMessage
		});
	}

	private string GetStateMessage(UploadState state)
	{
		return state switch
		{
			UploadState.Success => "SUCCESS", 
			UploadState.FileAccessError => "文件访问出错，请检查写入权限", 
			UploadState.SizeLimitExceed => "文件大小超出服务器限制", 
			UploadState.TypeNotAllow => "不允许的文件格式", 
			UploadState.NetworkError => "网络错误", 
			_ => "未知错误", 
		};
	}

	private bool CheckFileType(string filename)
	{
		string fileExtension = Path.GetExtension(filename).ToLower();
		return UploadConfig.AllowExtensions.Select((string x) => x.ToLower()).Contains(fileExtension);
	}

	private bool CheckFileSize(int size)
	{
		return size < UploadConfig.SizeLimit;
	}
}
