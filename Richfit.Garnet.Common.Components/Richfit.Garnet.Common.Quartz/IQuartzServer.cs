using System;
using System.IO;

namespace Richfit.Garnet.Common.Quartz;

/// <summary>
/// Quartz服务接口
/// </summary>
public interface IQuartzServer : IDisposable
{
	/// <summary>
	/// 初始化Quartz服务
	/// </summary>
	void Initialize();

	/// <summary>
	/// 使用指定的参数初始化Quartz服务
	/// </summary>
	/// <param name="args"></param>
	void Initialize(object args);

	/// <summary>
	/// 根据定时任务定义文件添加定时任务
	/// </summary>
	/// <param name="jobInfo"></param>
	void AddJob(FileInfo jobInfo);

	/// <summary>
	/// 启动定时服务
	/// </summary>
	/// <returns>启动成功返回true</returns>
	bool Start();

	/// <summary>
	/// 停止定时服务
	/// </summary>
	/// <returns>停止成功返回true</returns>
	bool Stop();

	/// <summary>
	/// 暂停定时服务
	/// </summary>
	void Pause();

	/// <summary>
	/// 恢复定时服务
	/// </summary>
	void Resume();
}
