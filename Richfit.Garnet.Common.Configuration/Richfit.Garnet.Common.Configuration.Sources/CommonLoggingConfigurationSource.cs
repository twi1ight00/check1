using System;
using System.Configuration;
using System.Xml;
using Common.Logging;
using Common.Logging.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 通用日志记录器配置源
/// </summary>
public class CommonLoggingConfigurationSource : DotNetConfigurationSource, ICommonLoggingConfiguration, IConfiguration, ICommonLoggingConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// Common.Logging.IConfigurationReader 的实现
	/// </summary>
	public class CommonLoggingConfiguration : IConfigurationReader
	{
		/// <summary>
		/// 配置源对象
		/// </summary>
		private CommonLoggingConfigurationSource source;

		/// <summary>
		/// Common Logging的配置设置对象
		/// </summary>
		private LogSetting setting;

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="source"></param>
		public CommonLoggingConfiguration(CommonLoggingConfigurationSource source)
		{
			source.GuardNotNull();
			this.source = source;
			string xml = source.Text;
			if (string.IsNullOrEmpty(xml))
			{
				throw new ArgumentNullException();
			}
			XmlDocument xdoc = new XmlDocument();
			xdoc.LoadXml(xml);
			XmlNode xnode = xdoc.SelectSingleNode("/logging");
			if (xnode == null)
			{
				throw new ArgumentException();
			}
			IConfigurationSectionHandler handler = new ConfigurationSectionHandler();
			setting = handler.Create(null, null, xnode) as LogSetting;
		}

		/// <summary>
		/// 读取配置节
		/// 实现Common.Logging的配置源接口
		/// 忽略sectionName, 始终使用common/logging
		/// </summary>
		/// <param name="sectionName">配置节名称</param>
		/// <returns>配置对象</returns>
		object IConfigurationReader.GetSection(string sectionName)
		{
			return source.SyncRoot.Read(delegate
			{
				source.GuardNotDisposed();
				return setting;
			});
		}
	}

	/// <summary>
	/// 数据库连接串配置节名称
	/// </summary>
	public const string CommonLoggingSection = "common/logging";

	/// <summary>
	/// 配置节
	/// </summary>
	private DefaultSection section;

	/// <summary>
	/// 获取或者设置原始配置文本
	/// </summary>
	public override string Text
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				this.GuardNotDisposed();
				return section.IsNull() ? null : section.SectionInformation.GetRawXml();
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				this.GuardNotDisposed();
				if (section.IsNotNull())
				{
					section.SectionInformation.SetRawXml(value.IfNull(string.Empty));
					Save();
				}
			});
		}
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public CommonLoggingConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(sourceGroup, sourceName, sourceFile, watcher)
	{
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public CommonLoggingConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~CommonLoggingConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing"></param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			section = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 加载Unity配置
	/// </summary>
	/// <returns>是否加载成功</returns>
	protected override bool LoadConfiguration()
	{
		try
		{
			base.LoadConfiguration();
			section = base.Configuration.GetSection("common/logging") as DefaultSection;
			return base.IsValid = section.IsNotNull();
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 获取通用日志配置读取器
	/// </summary>
	/// <returns>读取器</returns>
	public IConfigurationReader GetConfiguration()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return section.IsNotNull() ? new CommonLoggingConfiguration(this) : null;
		});
	}
}
