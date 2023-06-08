using System;
using System.Collections.Specialized;
using System.IO;
using Common.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Xml;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Quartz;

/// <summary>
/// Quartz服务器
/// </summary>
public class QuartzServer : IQuartzServer, IDisposable
{
	/// <summary>
	/// 日志记录器
	/// </summary>
	private readonly ILog logger;

	/// <summary>
	/// Quartz定时任务管理器工厂
	/// </summary>
	private ISchedulerFactory schedulerFactory;

	/// <summary>
	/// Quartz定时任务管理器
	/// </summary>
	private IScheduler scheduler;

	/// <summary>
	/// 创建Quartz服务器
	/// </summary>
	public QuartzServer()
	{
		logger = LogManager.GetLogger("Quartz");
	}

	/// <summary>
	/// 初始化Quartz服务器
	/// </summary>
	public virtual void Initialize()
	{
		if (schedulerFactory != null && scheduler != null)
		{
			logger.Error("Quartz Server has been initialized.");
			return;
		}
		try
		{
			schedulerFactory = new StdSchedulerFactory();
			scheduler = schedulerFactory.GetScheduler();
			logger.Info("Quartz Server initialization completed.");
		}
		catch (Exception e)
		{
			logger.Error("Quartz Server initialization failed:" + e.Message, e);
			throw;
		}
	}

	/// <summary>
	/// 使用指定的参数初始化Quartz服务
	/// </summary>
	/// <param name="args"></param>
	public virtual void Initialize(object args)
	{
		if (schedulerFactory != null && scheduler != null)
		{
			logger.Error("Quartz Server has been initialized.");
			return;
		}
		try
		{
			if (!(args is NameValueCollection props))
			{
				throw new ArgumentException("Quartz Server Parameters");
			}
			schedulerFactory = new StdSchedulerFactory(props);
			scheduler = schedulerFactory.GetScheduler();
			logger.Info("Quartz Server initialization completed.");
		}
		catch (Exception e)
		{
			logger.Error("Quartz Server initialization failed:" + e.Message, e);
			throw;
		}
	}

	/// <summary>
	/// 根据定时任务定义文件添加定时任务
	/// </summary>
	/// <param name="jobInfo"></param>
	public virtual void AddJob(FileInfo jobInfo)
	{
		lock (scheduler)
		{
			if (jobInfo == null || !jobInfo.Exists)
			{
				logger.Error("Quartz Job Definition is invalid.");
			}
			using (MemoryStream stream = new MemoryStream(jobInfo.ReadBytes()))
			{
				XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(new SimpleTypeLoadHelper());
				processor.ProcessStream(stream, "Quartz Server");
				processor.ScheduleJobs(scheduler);
				stream.Close();
			}
			logger.Info($"Quartz Job loaded sucessfully from {jobInfo.FullName}.");
		}
	}

	/// <summary>
	/// 启动定时服务
	/// </summary>
	/// <returns>是否启动成功</returns>
	public virtual bool Start()
	{
		lock (scheduler)
		{
			bool result = false;
			if (!scheduler.IsStarted)
			{
				scheduler.Start();
				result = true;
			}
			logger.Info("Quartz Server started successfully.");
			return result;
		}
	}

	/// <summary>
	/// 停止定时服务
	/// </summary>
	/// <returns>是否停止成功</returns>
	public virtual bool Stop()
	{
		lock (scheduler)
		{
			bool result = false;
			if (!scheduler.IsShutdown)
			{
				scheduler.Shutdown(waitForJobsToComplete: true);
				result = true;
			}
			logger.Info("Quartz Server shutdown complete");
			return result;
		}
	}

	/// <summary>
	/// 暂停定时服务
	/// </summary>
	public virtual void Pause()
	{
		lock (scheduler)
		{
			scheduler.PauseAll();
			logger.Info("Quartz Server paused successfully.");
		}
	}

	/// <summary>
	/// 恢复定时服务
	/// </summary>
	public virtual void Resume()
	{
		lock (scheduler)
		{
			scheduler.ResumeAll();
			logger.Info("Quartz Server resumed successfully.");
		}
	}

	/// <summary>
	/// 清理定时服务
	/// </summary>
	public virtual void Dispose()
	{
		if (scheduler != null)
		{
			Stop();
			scheduler = null;
		}
		if (schedulerFactory != null)
		{
			schedulerFactory = null;
		}
	}
}
