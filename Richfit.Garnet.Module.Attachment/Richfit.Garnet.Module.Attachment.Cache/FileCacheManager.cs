using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Richfit.Garnet.Module.Attachment.Application.DTO;

namespace Richfit.Garnet.Module.Attachment.Cache;

public static class FileCacheManager
{
	/// <summary>
	///             FileKey
	/// </summary>
	public const string FileKey = "ATTACHMENT_{0}";

	/// <summary>
	/// 用户缓存最大记录数
	/// </summary>
	private static int TotalCacheNumber;

	/// <summary>
	/// 调用ThreadTimerCallback的间隔时间
	/// </summary>
	private static int CallBackPeriod;

	/// <summary>
	/// 用户缓存过期天数
	/// </summary>
	private static TimeSpan UserTimeOut;

	/// <summary>
	/// 定时器
	/// </summary>
	private static Timer timer;

	/// <summary>
	/// 初始化管理器
	/// </summary>
	static FileCacheManager()
	{
		TotalCacheNumber = 1000;
		CallBackPeriod = 100000;
		UserTimeOut = TimeSpan.FromDays(1.0);
	}

	/// <summary>
	///             新的上传文件请求
	/// </summary>
	/// <param name="userName"></param>
	/// <param name="pwd"></param>
	public static void AddFileCache(AttachmentDTO fileModel)
	{
		FileCacheBus.Instance.Set($"ATTACHMENT_{fileModel.ATTACHMENT_ID.ToString()}", fileModel, UserTimeOut);
	}

	public static void RemoveFileCache(AttachmentDTO fileModel)
	{
		FileCacheBus.Instance.Remove($"ATTACHMENT_{fileModel.ATTACHMENT_ID.ToString()}");
	}

	/// <summary>
	/// -1，命中，不做额外处理；
	/// 0,列表中不包括当前文件，为全新上传；
	/// 1，需要续传；
	/// </summary>
	/// <param name="userName"></param>
	/// <param name="pwd"></param>
	/// <returns></returns>
	public static int IsHaveFile(ref AttachmentDTO fileModel)
	{
		if (FileCacheBus.Instance.Contains($"ATTACHMENT_{fileModel.ATTACHMENT_ID.ToString()}"))
		{
			return -1;
		}
		IEnumerable<KeyValuePair<string, object>> allFile = ((IProvider)FileCacheBus.Instance.Provider).Where((KeyValuePair<string, object> kvp) => kvp.Key.StartsWith("FileList_"));
		foreach (KeyValuePair<string, object> item in allFile)
		{
			AttachmentDTO fm = (AttachmentDTO)item.Value;
			if (fm.ATTACHMENT_NAME == fileModel.ATTACHMENT_NAME)
			{
				decimal? aTTACHMENT_SIZE = fm.ATTACHMENT_SIZE;
				decimal? aTTACHMENT_SIZE2 = fileModel.ATTACHMENT_SIZE;
				if (aTTACHMENT_SIZE.GetValueOrDefault() == aTTACHMENT_SIZE2.GetValueOrDefault() && aTTACHMENT_SIZE.HasValue == aTTACHMENT_SIZE2.HasValue && fm.Token == fileModel.Token)
				{
					fileModel.ATTACHMENT_ID = fm.ATTACHMENT_ID;
					return 1;
				}
			}
		}
		return 0;
	}

	public static AttachmentDTO GetFile(string fileId)
	{
		return (AttachmentDTO)FileCacheBus.Instance.Get(string.Format($"ATTACHMENT_{fileId}"));
	}
}
