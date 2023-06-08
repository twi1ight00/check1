using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 文件监控器
/// 当文件相关事件被触发后，监控器将暂停，直到事件处理完成后，监控器将继续运行
/// </summary>
public class FileWatcher : Watcher, IFileWatcher, IWatcher, ISyncableObject, IReferencable, IDisposableObject, IDisposable
{
	/// <summary>
	/// 监控信息列表
	/// </summary>
	private Dictionary<string, FileWatchingInfo> watchingInfos = new Dictionary<string, FileWatchingInfo>();

	/// <summary>
	/// 全局文件变更事件
	/// 对于所有的文件的变更都会触发
	/// </summary>
	public event FileWatchingEventHandler FileWatchingNotify
	{
		add
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				AddHandler(value);
			});
		}
		remove
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				RemoveHandler(value);
			});
		}
	}

	/// <summary>
	/// 创建文件监控器
	/// </summary>
	public FileWatcher()
	{
	}

	/// <summary>
	/// 创建文件监控器
	/// </summary>
	/// <param name="watchingInterval">检测时间间隔</param>
	public FileWatcher(int watchingInterval)
		: base(watchingInterval)
	{
	}

	/// <summary>
	/// 创建文件监控器
	/// </summary>
	/// <param name="timer">监控定时器</param>
	public FileWatcher(IWatchingTimer timer)
		: base(timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~FileWatcher()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理监控器处理
	/// </summary>
	/// <param name="disposing">是否显式清理</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			watchingInfos.Values.ForEach(delegate(FileWatchingInfo winfo)
			{
				winfo.Dispose();
			});
			watchingInfos.Clear();
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 监控事件触发
	/// </summary>
	/// <param name="watchingTime">监控时间</param>
	protected override void OnWatchingNotify(DateTime watchingTime)
	{
		Refresh();
	}

	/// <summary>
	/// 刷新全部文件的监控状态
	/// </summary>
	/// <param name="notify">是否触发通知事件</param>
	public override void Refresh(bool notify = true)
	{
		base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			Dictionary<FileWatchingEventArgs, Delegate> callbacks = new Dictionary<FileWatchingEventArgs, Delegate>();
			WatchingStatus watchingStatus = WatchingStatus.Unchanged;
			base.SyncRoot.Write(delegate
			{
				watchingInfos.ForEach(delegate(KeyValuePair<string, FileWatchingInfo> kvp)
				{
					kvp.Value.WatchingTime = DateTime.Now;
					if ((watchingStatus = kvp.Value.GetCurrentStatus()) != 0)
					{
						kvp.Value.RefreshFileStatus();
						GetHandlers(kvp.Key).ForEach(delegate(Delegate handler)
						{
							callbacks.Add(new FileWatchingEventArgs(kvp.Value.FileHandler, watchingStatus, kvp.Value.WatchingTime), handler);
						});
						GetHandlers().ForEach(delegate(Delegate handler)
						{
							callbacks.Add(new FileWatchingEventArgs(kvp.Value.FileHandler, watchingStatus, kvp.Value.WatchingTime), handler);
						});
					}
				});
			});
			if (notify)
			{
				callbacks.ForEach(delegate(KeyValuePair<FileWatchingEventArgs, Delegate> kvp)
				{
					kvp.Value.DynamicInvoke(this, kvp.Key);
				});
			}
		});
	}

	/// <summary>
	/// 刷新文件监控状态
	/// </summary>
	/// <param name="file">被监控的文件全名（包括文件路径）</param>
	/// <param name="notify">是否触发通知事件</param>
	/// <returns>刷新后的文件状态</returns>
	public WatchingStatus Refresh(string file, bool notify = true)
	{
		file.GuardNotNull();
		return Refresh(new FileInfo(file), notify);
	}

	/// <summary>
	/// 刷新文件监控状态
	/// </summary>
	/// <param name="file">被监控的文件对象</param>
	/// <param name="notify">是否触发通知事件</param>
	/// <returns>刷新后的文件状态</returns>
	public WatchingStatus Refresh(FileInfo file, bool notify = true)
	{
		file.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			Dictionary<FileWatchingEventArgs, Delegate> callbacks = new Dictionary<FileWatchingEventArgs, Delegate>();
			WatchingStatus watchingStatus = WatchingStatus.Unchanged;
			FileWatchingInfo winfo = null;
			if (watchingInfos.ContainsKey(file.FullName))
			{
				winfo = watchingInfos[file.FullName];
			}
			if (winfo.IsNull())
			{
				return WatchingStatus.Unchanged;
			}
			base.SyncRoot.Write(delegate
			{
				winfo.WatchingTime = DateTime.Now;
				if ((watchingStatus = winfo.GetCurrentStatus()) != 0)
				{
					winfo.RefreshFileStatus();
					GetHandlers(winfo.FileHandler.FullName).ForEach(delegate(Delegate handler)
					{
						callbacks.Add(new FileWatchingEventArgs(winfo.FileHandler, watchingStatus, winfo.WatchingTime), handler);
					});
				}
			});
			if (notify)
			{
				callbacks.ForEach(delegate(KeyValuePair<FileWatchingEventArgs, Delegate> kvp)
				{
					kvp.Value.DynamicInvoke(this, kvp.Key);
				});
			}
			return watchingStatus;
		});
	}

	/// <summary>
	/// 获取文件监控事件处理器数量
	/// </summary>
	/// <param name="file">被监控的文件全名（包括文件路径）</param>
	/// <returns>事件处理委托</returns>
	public int GetFileHandlerCount(string file)
	{
		file.GuardNotNull();
		return GetFileHandlerCount(new FileInfo(file));
	}

	/// <summary>
	/// 获取文件监控事件处理器数量
	/// </summary>
	/// <param name="file">被监控的文件对象</param>
	/// <returns>事件处理委托</returns>
	public int GetFileHandlerCount(FileInfo file)
	{
		file.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return GetHandlerCount(file.FullName);
		});
	}

	/// <summary>
	/// 添加需要监控的文件
	/// </summary>
	/// <param name="file">文件全名（包括文件路径）</param>
	public void AddFile(string file)
	{
		AddWatchingFile(file, null);
	}

	/// <summary>
	/// 添加需要监控的文件，并指定该文件监控事件处理器
	/// </summary>
	/// <param name="file">文件全名（包括文件路径）</param>
	/// <param name="handler">事件处理委托</param>
	public void AddFile(string file, FileWatchingEventHandler handler)
	{
		AddWatchingFile(file, handler);
	}

	/// <summary>
	/// 添加需要监控的文件
	/// </summary>
	/// <param name="file">文件对象</param>
	public void AddFile(FileInfo file)
	{
		AddWatchingFile(file, null);
	}

	/// <summary>
	/// 添加需要监控的文件，并指定该文件监控事件处理器
	/// </summary>
	/// <param name="file">文件对象</param>
	/// <param name="handler">事件处理委托</param>
	public void AddFile(FileInfo file, FileWatchingEventHandler handler)
	{
		AddWatchingFile(file, handler);
	}

	/// <summary>
	/// 移除监控的文件
	/// </summary>
	/// <param name="file">文件全名（包括文件路径）</param>
	public void RemoveFile(string file)
	{
		RemoveWatchingFile(file, null);
	}

	/// <summary>
	/// 移除监控的文件
	/// 首先移除指定的处理委托，移除后如果文件不再有任何其他委托，则移除该文件
	/// </summary>
	/// <param name="file">文件全名（包括文件路径）</param>
	/// <param name="handler">事件处理委托</param>
	public void RemoveFile(string file, FileWatchingEventHandler handler)
	{
		RemoveWatchingFile(file, handler);
	}

	/// <summary>
	/// 移除指定被监控的文件，并且移除该文件相关的事件处理委托
	/// </summary>
	/// <param name="file">文件对象</param>
	public void RemoveFile(FileInfo file)
	{
		RemoveWatchingFile(file, null);
	}

	/// <summary>
	/// 移除监控的文件
	/// 首先移除指定的处理委托，移除后如果文件不再有任何其他委托，则移除该文件
	/// </summary>
	/// <param name="file">文件对象</param>
	/// <param name="handler">事件处理委托</param>
	public void RemoveFile(FileInfo file, FileWatchingEventHandler handler)
	{
		RemoveWatchingFile(file, handler);
	}

	/// <summary>
	/// 移除所有被监控的文件
	/// </summary>
	public void RemoveFiles()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			watchingInfos.Keys.ToArray().All(delegate(string file)
			{
				RemoveFile(file);
				return true;
			});
		});
	}

	/// <summary>
	/// 添加需要监控的文件
	/// 如果未指定文件的监控事件处理器，则只添加监控文件
	/// 如果需要监控的文件已经存在，则只添加该文件的监控事件处理器
	/// </summary>
	/// <param name="file"></param>
	/// <param name="handler"></param>
	private void AddWatchingFile(object file, FileWatchingEventHandler handler)
	{
		file.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			FileInfo fileInfo = ((file is FileInfo) ? ((FileInfo)file) : new FileInfo((string)file));
			if (!watchingInfos.ContainsKey(fileInfo.FullName))
			{
				watchingInfos.Add(fileInfo.FullName, new FileWatchingInfo(fileInfo));
			}
			AddHandler(fileInfo.FullName, handler);
		});
	}

	/// <summary>
	/// 移除与当前文件相关联的事件处理委托
	/// </summary>
	/// <param name="file"></param>
	/// <param name="handler"></param>
	private void RemoveWatchingFile(object file, FileWatchingEventHandler handler)
	{
		file.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			FileInfo fileInfo = ((file is FileInfo) ? ((FileInfo)file) : new FileInfo((string)file));
			if (watchingInfos.ContainsKey(fileInfo.FullName))
			{
				if (handler.IsNull())
				{
					watchingInfos[fileInfo.FullName].Dispose();
					watchingInfos.Remove(fileInfo.FullName);
					RemoveHandler(fileInfo.FullName);
				}
				else
				{
					RemoveHandler(fileInfo.FullName, handler);
				}
			}
		});
	}
}
