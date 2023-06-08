using System;
using System.IO;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Watching;

/// <summary>
/// 文件监控器接口
/// </summary>
public interface IFileWatcher : IWatcher, ISyncableObject, IReferencable, IDisposableObject, IDisposable
{
	/// <summary>
	/// 全局文件变更事件
	/// 对于所有的文件的变更都会触发
	/// </summary>
	event FileWatchingEventHandler FileWatchingNotify;

	/// <summary>
	/// 刷新文件监控状态
	/// </summary>
	/// <param name="file">被监控的文件全名（包括文件路径）</param>
	/// <param name="notify">是否触发通知事件</param>
	/// <returns>刷新后的文件状态</returns>
	WatchingStatus Refresh(string file, bool notify = true);

	/// <summary>
	/// 刷新文件监控状态
	/// </summary>
	/// <param name="file">被监控的文件对象</param>
	/// <param name="notify">是否触发通知事件</param>
	/// <returns>刷新后的文件状态</returns>
	WatchingStatus Refresh(FileInfo file, bool notify = true);

	/// <summary>
	/// 获取文件监控事件处理器数量
	/// </summary>
	/// <param name="file">被监控的文件全名（包括文件路径）</param>
	/// <returns>事件处理委托</returns>
	int GetFileHandlerCount(string file);

	/// <summary>
	/// 获取文件监控事件处理器数量
	/// </summary>
	/// <param name="file">被监控的文件对象</param>
	/// <returns>事件处理委托</returns>
	int GetFileHandlerCount(FileInfo file);

	/// <summary>
	/// 添加需要监控的文件
	/// </summary>
	/// <param name="file">文件对象</param>
	void AddFile(FileInfo file);

	/// <summary>
	/// 添加需要监控的文件，并指定该文件监控事件处理器
	/// </summary>
	/// <param name="file">文件对象</param>
	/// <param name="handler">事件处理委托</param>
	void AddFile(FileInfo file, FileWatchingEventHandler handler);

	/// <summary>
	/// 添加需要监控的文件
	/// </summary>
	/// <param name="file">文件全名（包括文件路径）</param>
	void AddFile(string file);

	/// <summary>
	/// 添加需要监控的文件，并指定该文件监控事件处理器
	/// </summary>
	/// <param name="file">文件全名（包括文件路径）</param>
	/// <param name="handler">事件处理委托</param>
	void AddFile(string file, FileWatchingEventHandler handler);

	/// <summary>
	/// 移除监控的文件，并且移除该文件相关的事件处理委托
	/// </summary>
	/// <param name="file">文件对象</param>
	void RemoveFile(FileInfo file);

	/// <summary>
	/// 移除监控的文件
	/// 首先移除指定的处理委托，移除后如果文件不再有任何其他委托，则移除该文件
	/// </summary>
	/// <param name="file">文件对象</param>
	/// <param name="handler">事件处理委托</param>
	void RemoveFile(FileInfo file, FileWatchingEventHandler handler);

	/// <summary>
	/// 移除指定被监控的文件，并且移除该文件相关的事件处理委托
	/// </summary>
	/// <param name="file">文件对象</param>
	void RemoveFile(string file);

	/// <summary>
	/// 移除监控的文件
	/// 首先移除指定的处理委托，移除后如果文件不再有任何其他委托，则移除该文件
	/// </summary>
	/// <param name="file">文件对象</param>
	/// <param name="handler">事件处理委托</param>
	void RemoveFile(string file, FileWatchingEventHandler handler);

	/// <summary>
	/// 移除所有被监控的文件
	/// </summary>
	void RemoveFiles();
}
