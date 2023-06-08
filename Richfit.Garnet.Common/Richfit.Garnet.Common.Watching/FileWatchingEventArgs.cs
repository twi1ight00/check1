using System;
using System.IO;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 文件监控事件参数
/// </summary>
public class FileWatchingEventArgs : WatchingEventArgs
{
	/// <summary>
	/// 文件信息
	/// </summary>
	public FileInfo WatchingFile
	{
		get
		{
			return (FileInfo)base.WatchingObject;
		}
		set
		{
			base.WatchingObject = value;
		}
	}

	/// <summary>
	/// 创建文件监控事件参数
	/// </summary>
	/// <param name="watchingFile">监控的文件对象</param>
	/// <param name="status">监控的文件状态</param>
	/// <param name="watchingTime">监控的文件状态</param>
	public FileWatchingEventArgs(FileInfo watchingFile, WatchingStatus status, DateTime watchingTime)
		: base(watchingFile, status, watchingTime)
	{
	}
}
