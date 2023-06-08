using System;
using System.IO;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 文件监控信息
/// </summary>
public class FileWatchingInfo : IDisposable
{
	/// <summary>
	/// 被监控文件引用
	/// </summary>
	public FileInfo FileHandler { get; set; }

	/// <summary>
	/// 被监控文件时间戳
	/// </summary>
	public DateTime FileTimestamp { get; set; }

	/// <summary>
	/// 被监控的文件是否存在
	/// </summary>
	public bool FileExists { get; set; }

	/// <summary>
	/// 监控时间
	/// </summary>
	public DateTime WatchingTime { get; set; }

	/// <summary>
	/// 指示被监控文件是否发生更改
	/// </summary>
	public bool HasChanged => FileTimestamp != GetLastWriteTime();

	/// <summary>
	/// 初始化监控信息
	/// </summary>
	private FileWatchingInfo()
	{
		FileHandler = null;
		FileTimestamp = DateTime.MinValue;
		FileExists = false;
		WatchingTime = DateTime.MinValue;
	}

	/// <summary>
	/// 初始化监控信息
	/// </summary>
	/// <param name="file">监控的文件路径</param>
	public FileWatchingInfo(string file)
		: this()
	{
		file.GuardNotNullAndEmpty();
		FileHandler = new FileInfo(file);
		RefreshFileStatus();
	}

	/// <summary>
	/// 初始化监控信息
	/// </summary>
	/// <param name="file">监控的文件的对象</param>
	public FileWatchingInfo(FileInfo file)
		: this()
	{
		file.GuardNotNull();
		FileHandler = file;
		RefreshFileStatus();
	}

	/// <summary>
	/// 释放对象
	/// </summary>
	public void Dispose()
	{
		FileHandler = null;
		FileTimestamp = DateTime.MinValue;
		FileExists = false;
	}

	/// <summary>
	/// 获取被监控文件的当前状态
	/// </summary>
	/// <returns></returns>
	public WatchingStatus GetCurrentStatus()
	{
		if (FileHandler.IsNull())
		{
			return WatchingStatus.Unchanged;
		}
		Refresh();
		if (FileHandler.Exists == FileExists)
		{
			return HasChanged ? WatchingStatus.Changed : WatchingStatus.Unchanged;
		}
		return FileHandler.Exists ? WatchingStatus.New : WatchingStatus.Missing;
	}

	/// <summary>
	/// 刷新文件状态信息
	/// </summary>
	public void Refresh()
	{
		if (FileHandler.IsNotNull())
		{
			try
			{
				FileHandler.Refresh();
			}
			catch
			{
			}
		}
	}

	/// <summary>
	/// 更新文件监控信息
	/// </summary>
	public void RefreshFileStatus()
	{
		if (FileHandler.IsNotNull())
		{
			FileExists = FileHandler.Exists;
			FileTimestamp = GetLastWriteTime();
		}
	}

	/// <summary>
	/// 获取文件最后修改时间
	/// 如果文件不存在则返回DateTime.MinValue
	/// </summary>
	/// <returns></returns>
	private DateTime GetLastWriteTime()
	{
		if (FileHandler.IsNull() || !FileHandler.Exists)
		{
			return DateTime.MinValue;
		}
		return FileHandler.LastWriteTime;
	}
}
