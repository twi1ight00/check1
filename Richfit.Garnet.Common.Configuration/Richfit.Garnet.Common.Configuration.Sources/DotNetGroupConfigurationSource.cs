using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// .Net配置源对象，含有子配置源
/// </summary>
public class DotNetGroupConfigurationSource : DotNetConfigurationSource, IDotNetGroupConfiguration, IConfiguration, IDotNetConfigurationSource, IGroupConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public DotNetGroupConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(parentGroup, sourceName, sourceFile, watcher)
	{
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public DotNetGroupConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(parentGroup, sourceName, sourceFile, timer)
	{
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="configuration">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public DotNetGroupConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, System.Configuration.Configuration configuration, IWatcher watcher)
		: base(parentGroup, sourceName, configuration.FilePath, watcher)
	{
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="parentGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="configuration">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public DotNetGroupConfigurationSource(IConfigurationSourceGroup parentGroup, string sourceName, System.Configuration.Configuration configuration, IWatchingTimer timer)
		: base(parentGroup, sourceName, configuration.FilePath, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~DotNetGroupConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing">是否已经执行了清理</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && Group.IsNotNull())
		{
			Group.Dispose();
			Group = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 加载配置
	/// </summary>
	/// <returns>如果加载成功返回true，或者返回null</returns>
	protected override bool LoadConfiguration()
	{
		try
		{
			bool status = base.LoadConfiguration();
			if (Group.IsNotNull())
			{
				Group.Dispose();
			}
			Group = new ConfigurationSourceGroup(this);
			Group.AddRange(LoadConfigurationSource(this));
			return status;
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 从配置源节中加载配置源
	/// </summary>
	/// <param name="source">待加载的标准配置源</param>
	/// <returns>加载的子配置源数组</returns>
	private IEnumerable<IConfigurationSource> LoadConfigurationSource(IDotNetConfigurationSource source)
	{
		if (source.IsNull())
		{
			yield break;
		}
		try
		{
			ConfigurationSourceSection[] sections = source.GetSections<ConfigurationSourceSection>();
			foreach (ConfigurationSourceSection section in sections)
			{
				foreach (IConfigurationSource item in LoadLocationConfigurationSource(section, Group, base.Watcher))
				{
					yield return item;
				}
				foreach (IConfigurationSource item2 in LoadDefinedConfigurationSource(section, Group, base.Watcher))
				{
					yield return item2;
				}
			}
		}
		finally
		{
		}
	}

	/// <summary>
	/// 批量加载指定位置下的所有配置源
	/// </summary>
	/// <param name="sourceSection">位置配置节</param>
	/// <param name="group">配置源所属的配置组</param>
	/// <param name="sourceWatcher">文件监视器</param>
	/// <returns>配置源序列</returns>
	private IEnumerable<IConfigurationSource> LoadLocationConfigurationSource(ConfigurationSourceSection sourceSection, IConfigurationSourceGroup group, IWatcher sourceWatcher)
	{
		if (sourceSection.IsNull() || sourceSection.Source.IsNullOrWhiteSpace())
		{
			yield break;
		}
		string sourceBasePath = Path.GetDirectoryName(sourceSection.CurrentConfiguration.FilePath);
		string sourceLocation = (sourceSection.Location.IsAbsolutePath() ? sourceSection.Location : sourceSection.Location.BuildPath(sourceBasePath));
		if (!Directory.Exists(sourceLocation))
		{
			throw new DirectoryNotFoundException($"Configuration path '{sourceLocation}' is not exists.");
		}
		Type sourceType = sourceSection.Type;
		if (sourceType.IsNull())
		{
			throw new TypeLoadException($"Configuration Source Type is not defined at Section {sourceSection.SectionInformation.Name}.");
		}
		string[] sourceFiles = Directory.GetFiles(sourceLocation, sourceSection.Source, SearchOption.AllDirectories);
		try
		{
			string[] array = sourceFiles;
			string sourceName;
			foreach (string sourceFile in array)
			{
				sourceName = Path.GetDirectoryName(sourceFile).Replace(sourceLocation, string.Empty).Trim('\\', '/')
					.Replace('\\', '.')
					.Replace('/', '.');
				sourceType = GetMappedConfigurationSource(sourceType, sourceName);
				IConfigurationSource source = sourceType.CreateInstance<IConfigurationSource>(new object[4] { group, sourceName, sourceFile, sourceWatcher }).GuardNotNull(() => new TypeLoadException($"Can't create configuration for '{sourceName}'."));
				source.Category = sourceSection.SectionInformation.Name;
				source.SourceType = sourceType.GetType();
				yield return source;
			}
		}
		finally
		{
		}
	}

	/// <summary>
	/// 加载自定义位置的配置源
	/// </summary>
	/// <param name="sourceSection">位置配置节</param>
	/// <param name="group">配置源所属的配置组</param>
	/// <param name="sourceWatcher">文件监视器</param>
	/// <returns>配置源序列</returns>
	private IEnumerable<IConfigurationSource> LoadDefinedConfigurationSource(ConfigurationSourceSection sourceSection, IConfigurationSourceGroup group, IWatcher sourceWatcher)
	{
		if (sourceSection.IsNull())
		{
			yield break;
		}
		string sourceBasePath = Path.GetDirectoryName(sourceSection.CurrentConfiguration.FilePath);
		Type sourceType = sourceSection.Type;
		foreach (ConfigurationSourceElement element in sourceSection.Sources)
		{
			sourceType = element.Type.IfNull(sourceType).GuardNotNull(() => new TypeLoadException($"Configuration Source Type is not defined at Section {sourceSection.SectionInformation.Name}."));
			sourceType = GetMappedConfigurationSource(sourceType, element.Name);
			string sourceLocation = (element.Location.IsAbsolutePath() ? element.Location : element.Location.BuildPath(sourceBasePath));
			IConfigurationSource source = sourceType.CreateInstance<IConfigurationSource>(new object[4] { group, element.Name, sourceLocation, sourceWatcher }).GuardNotNull(() => new TypeLoadException($"Can't create configuration for '{element.Name}'."));
			source.Category = sourceSection.SectionInformation.Name;
			source.SourceType = sourceType.GetType();
			yield return source;
		}
	}

	/// <summary>
	/// 获取映射到配置源类型
	/// </summary>
	/// <param name="sourceType">映射源类型</param>
	/// <param name="sourceName">映射的名称</param>
	/// <returns>映射的目标配置源类型</returns>
	private Type GetMappedConfigurationSource(Type sourceType, string sourceName)
	{
		if (sourceType.IsNull())
		{
			return null;
		}
		ConfigurationSourceMappingAttribute[] attributes = sourceType.GetCustomAttributes<ConfigurationSourceMappingAttribute>().ToArray();
		if (attributes.Length == 0)
		{
			return sourceType;
		}
		if (attributes.Length == 1 && attributes[0].SourceType.IsNotNull())
		{
			return attributes[0].SourceType;
		}
		ConfigurationSourceMappingAttribute attribute = attributes.Where((ConfigurationSourceMappingAttribute a) => a.SourceName.EqualOrdinal(sourceName, ignoreCase: true)).FirstOrDefault();
		if (attribute.IsNotNull() && attribute.SourceType.IsNotNull())
		{
			return attribute.SourceType;
		}
		return sourceType;
	}

	/// <summary>
	/// 刷新配置源
	/// </summary>
	public override void Refresh()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (Group.IsNotNull())
			{
				foreach (IConfigurationSource current in Group)
				{
					if (current is IRefreshableConfigurationSource)
					{
						current.As<IRefreshableConfigurationSource>().Refresh();
					}
				}
			}
			base.Refresh();
		});
	}

	/// <summary>
	/// 保存配置源
	/// </summary>
	public override void Save()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			foreach (IConfigurationSource current in Group)
			{
				ConfigurationSourceSection configurationSourceSection;
				if ((configurationSourceSection = GetSection<ConfigurationSourceSection>(current.Category)).IsNull())
				{
					configurationSourceSection = new ConfigurationSourceSection();
					AddSection(current.Category, configurationSourceSection);
				}
				if (!configurationSourceSection.Sources.Contains(current.SourceName))
				{
					string text;
					if (current is IFileConfigurationSource)
					{
						IFileConfigurationSource fileConfigurationSource = current.As<IFileConfigurationSource>();
						text = ((!fileConfigurationSource.FullName.StartsWith(Path.GetDirectoryName(base.FullName), StringComparison.CurrentCultureIgnoreCase)) ? fileConfigurationSource.FullName : fileConfigurationSource.FullName.Replace(Path.GetDirectoryName(base.FullName), string.Empty));
					}
					else
					{
						text = current.Location;
					}
					configurationSourceSection.Sources.Add(new ConfigurationSourceElement
					{
						Name = current.SourceName,
						Location = text,
						TypeName = current.SourceType.AssemblyQualifiedName
					});
				}
			}
			ConfigurationSourceSection[] sections = GetSections<ConfigurationSourceSection>();
			foreach (ConfigurationSourceSection configurationSourceSection in sections)
			{
				ConfigurationSourceElement[] array = configurationSourceSection.Sources.ToArray();
				foreach (ConfigurationSourceElement configurationSourceElement in array)
				{
					IConfigurationSource current = Group.GetSource(configurationSourceElement.Name);
					if (current.IsNull() || !current.Category.EqualOrdinal(configurationSourceSection.SectionInformation.Name))
					{
						configurationSourceSection.Sources.Remove(configurationSourceElement);
					}
				}
			}
			base.Save();
		});
	}
}
