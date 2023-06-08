using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Richfit.Garnet.Common.Configuration.Designs;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 设置配置源
/// </summary>
public class SettingsConfigurationSource : DotNetConfigurationSource, ISettingsConfiguration, IConfiguration, ISettingsConfigurationSource, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 配置节
	/// </summary>
	private ConfigurationSection section;

	/// <summary>
	/// 获取或者设置配置文本
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
	/// 获取或者设置指定名称的命名值
	/// </summary>
	/// <param name="name">命名值的名称</param>
	/// <returns>命名值</returns>
	public object this[string name]
	{
		get
		{
			return GetSetting(name);
		}
		set
		{
			SetSetting(name, value);
		}
	}

	/// <summary>
	/// 创建扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public SettingsConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(sourceGroup, sourceName, sourceFile, watcher)
	{
	}

	/// <summary>
	/// 创建扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public SettingsConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
	}

	/// <summary>
	/// 析构
	/// </summary>
	~SettingsConfigurationSource()
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
	/// 加载配置源
	/// </summary>
	/// <returns></returns>
	protected override bool LoadConfiguration()
	{
		try
		{
			base.LoadConfiguration();
			section = GetSection();
			return base.IsValid = section.IsNotNull();
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 获取配置节
	/// </summary>
	/// <returns>配置节</returns>
	protected virtual ConfigurationSection GetSection()
	{
		ConfigurationSection section = base.Configuration.GetFirstSection<ConfigurationSettingSection>();
		if (section.IsNull())
		{
			section = base.Configuration.GetFirstSection<AppSettingsSection>();
		}
		return section;
	}

	/// <summary>
	/// 获取命名值的数量
	/// </summary>
	/// <returns>命名值设置数量</returns>
	public int GetSettingCount()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return 0;
			}
			if (section is AppSettingsSection)
			{
				return section.As<AppSettingsSection>().Settings.Count;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			return section.As<ConfigurationSettingSection>().Settings.Count;
		});
	}

	/// <summary>
	/// 获取命名字符串的列表
	/// </summary>
	/// <returns>命名值字典</returns>
	public Dictionary<string, string> GetValues()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (section.IsNull())
			{
				return null;
			}
			if (section is AppSettingsSection)
			{
				foreach (KeyValueConfigurationElement keyValueConfigurationElement in section.As<AppSettingsSection>().Settings)
				{
					dictionary.Add(keyValueConfigurationElement.Key, keyValueConfigurationElement.Value);
				}
				return dictionary;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			foreach (ConfigurationSettingElement current in section.As<ConfigurationSettingSection>().Settings)
			{
				dictionary.Add(current.Name, current.Value);
			}
			return dictionary;
		});
	}

	/// <summary>
	/// 获取指定名称的命名字符串，如果指定名称的命名字符串不存在则返回null
	/// </summary>
	/// <param name="name">命名字符串的名称</param>
	/// <returns>命名字符串</returns>
	public string GetValue(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return null;
			}
			if (section is AppSettingsSection)
			{
				KeyValueConfigurationElement keyValueConfigurationElement = section.As<AppSettingsSection>().Settings[name];
				return keyValueConfigurationElement.IsNull() ? null : keyValueConfigurationElement.Value;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			return configurationSettingElement.IsNull() ? null : configurationSettingElement.Value;
		});
	}

	/// <summary>
	/// 设置指定名称的命名字符串，如果设置的命名字符串为null，则转换为空字符串
	/// </summary>
	/// <param name="name">命名字符串的名称</param>
	/// <param name="value">设置的命名字符串</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	public bool SetValue(string name, string value)
	{
		name.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section is AppSettingsSection)
			{
				KeyValueConfigurationElement keyValueConfigurationElement = section.As<AppSettingsSection>().Settings[name];
				if (keyValueConfigurationElement.IsNull())
				{
					return false;
				}
				keyValueConfigurationElement.Value = value.IfNull(string.Empty);
				return true;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			if (configurationSettingElement.IsNull())
			{
				return false;
			}
			configurationSettingElement.Value = value.IfNull(string.Empty);
			return true;
		});
	}

	/// <summary>
	/// 添加指定名称的命名字符串，如果设置的命名字符串为null，则转换为空字符值
	/// </summary>
	/// <param name="name">命名字符串的名称</param>
	/// <param name="value">设置的命名字符串</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	public bool AddValue(string name, string value)
	{
		name.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section is AppSettingsSection)
			{
				AppSettingsSection appSettingsSection = section.As<AppSettingsSection>();
				if (appSettingsSection.Settings[name].IsNull())
				{
					appSettingsSection.Settings.Add(name, value.IfNull(string.Empty));
					return true;
				}
				return false;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingSection configurationSettingSection = section.As<ConfigurationSettingSection>();
			if (configurationSettingSection.Settings.Get(name).IsNull())
			{
				ConfigurationSettingElement configurationSettingElement = new ConfigurationSettingElement
				{
					Name = name,
					Type = null,
					TypeConverter = null
				};
				configurationSettingElement.Value = value;
				configurationSettingSection.Settings.Add(configurationSettingElement);
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 获取命名值的列表
	/// </summary>
	/// <returns>命名值字典</returns>
	public Dictionary<string, object> GetSettings()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (section.IsNull())
			{
				return null;
			}
			if (section is AppSettingsSection)
			{
				foreach (KeyValueConfigurationElement keyValueConfigurationElement in section.As<AppSettingsSection>().Settings)
				{
					dictionary.Add(keyValueConfigurationElement.Key, keyValueConfigurationElement.Value);
				}
				return dictionary;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			foreach (ConfigurationSettingElement current in section.As<ConfigurationSettingSection>().Settings)
			{
				dictionary.Add(current.Name, current.TypedValue);
			}
			return dictionary;
		});
	}

	/// <summary>
	/// 获取指定名称的命名值，如果指定名称的命名值不存在则返回null
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <returns>命名值</returns>
	public object GetSetting(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return null;
			}
			if (section is AppSettingsSection)
			{
				KeyValueConfigurationElement keyValueConfigurationElement = section.As<AppSettingsSection>().Settings[name];
				return keyValueConfigurationElement.IsNull() ? null : keyValueConfigurationElement.Value;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			return configurationSettingElement.IsNull() ? null : configurationSettingElement.TypedValue;
		});
	}

	/// <summary>
	/// 获取指定名称的命名值，如果指定名称的命名值不存在则返回指定的默认值
	/// </summary>
	/// <typeparam name="T">命名值的类型</typeparam>
	/// <param name="name">命名值</param>
	/// <param name="defaultValue">命名值的默认值</param>
	/// <returns>命名值</returns>
	public T GetSetting<T>(string name, T defaultValue = default(T))
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return defaultValue;
			}
			if (section is AppSettingsSection)
			{
				KeyValueConfigurationElement keyValueConfigurationElement = section.As<AppSettingsSection>().Settings[name];
				return keyValueConfigurationElement.IsNull() ? defaultValue : keyValueConfigurationElement.Value.ConvertTo<T>();
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			return configurationSettingElement.IsNull() ? defaultValue : configurationSettingElement.TypedValue.ConvertTo<T>();
		});
	}

	/// <summary>
	/// 获取指定名称的命名值，如果指定名称的命名值不存在则返回null
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="converter">命名值的转换器</param>
	/// <returns>命名值</returns>
	public object GetSetting(string name, Func<string, object> converter)
	{
		name.GuardNotNull();
		converter.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return null;
			}
			if (section is AppSettingsSection)
			{
				KeyValueConfigurationElement keyValueConfigurationElement = section.As<AppSettingsSection>().Settings[name];
				return keyValueConfigurationElement.IsNull() ? null : converter(keyValueConfigurationElement.Value);
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			return configurationSettingElement.IsNull() ? null : converter(configurationSettingElement.Value);
		});
	}

	/// <summary>
	/// 获取指定名称的命名值，如果指定名称的命名值不存在则返回null
	/// </summary>
	/// <typeparam name="T">命名值</typeparam>
	/// <param name="name">命名值名称</param>
	/// <param name="converter">命名值的转换器</param>
	/// <param name="defaultValue">命名值的默认值</param>
	/// <returns>命名值</returns>
	public T GetSetting<T>(string name, Func<string, T> converter, T defaultValue = default(T))
	{
		name.GuardNotNull();
		converter = converter.IfNull((string s) => s.ConvertTo<T>());
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return defaultValue;
			}
			if (section is AppSettingsSection)
			{
				KeyValueConfigurationElement keyValueConfigurationElement = section.As<AppSettingsSection>().Settings[name];
				return keyValueConfigurationElement.IsNull() ? defaultValue : converter(keyValueConfigurationElement.Value);
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			return configurationSettingElement.IsNull() ? defaultValue : converter(configurationSettingElement.Value);
		});
	}

	/// <summary>
	/// 获取指定名称的命名值的类型
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <returns>命名值的类型</returns>
	public Type GetSettingType(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return null;
			}
			if (section is AppSettingsSection)
			{
				return section.As<AppSettingsSection>().Settings[name].IsNull() ? null : typeof(string);
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			return configurationSettingElement.IsNull() ? null : configurationSettingElement.Type;
		});
	}

	/// <summary>
	/// 获取指定名称的命名值的类型转换器
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <returns>命名值的类型转换器</returns>
	public TypeConverter GetSettingConverter(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return null;
			}
			if (section is AppSettingsSection)
			{
				return null;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			return configurationSettingElement.IsNull() ? null : configurationSettingElement.TypeConverter;
		});
	}

	/// <summary>
	/// 设置指定名称的命名值
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="value">设置的命名值</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	public bool SetSetting(string name, object value)
	{
		name.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section is AppSettingsSection)
			{
				KeyValueConfigurationElement keyValueConfigurationElement = section.As<AppSettingsSection>().Settings[name];
				if (keyValueConfigurationElement.IsNull())
				{
					return false;
				}
				keyValueConfigurationElement.Value = (value.IsNull() ? string.Empty : value.ToString());
				return true;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			if (configurationSettingElement.IsNull())
			{
				return false;
			}
			configurationSettingElement.TypedValue = value;
			return true;
		});
	}

	/// <summary>
	/// 设置指定名称的命名值
	/// </summary>
	/// <typeparam name="T">命名值类型</typeparam>
	/// <param name="name">命名值名称</param>
	/// <param name="value">设置的命名值</param>
	/// <param name="converter">命名值转换器</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	public bool SetSetting<T>(string name, T value, Func<T, string> converter = null)
	{
		name.GuardNotNull();
		converter = converter.IfNull((T x) => x.IsNull() ? string.Empty : x.ToString());
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section is AppSettingsSection)
			{
				KeyValueConfigurationElement keyValueConfigurationElement = section.As<AppSettingsSection>().Settings[name];
				if (keyValueConfigurationElement.IsNull())
				{
					return false;
				}
				keyValueConfigurationElement.Value = converter(value);
				return true;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingElement configurationSettingElement = section.As<ConfigurationSettingSection>().Settings.Get(name);
			if (configurationSettingElement.IsNull())
			{
				return false;
			}
			configurationSettingElement.Value = converter(value);
			return true;
		});
	}

	/// <summary>
	/// 添加指定名称的命名值
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="value">设置的命名值</param>
	/// <param name="type">设置的命名值的类型；如果命名值不为空，则可以省略类型；如果命名值为空，则必须指定命名值类型</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	public bool AddSetting(string name, object value, Type type = null)
	{
		name.GuardNotNull();
		if (value.IsNull() && type.IsNull())
		{
			throw new ArgumentException();
		}
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section is AppSettingsSection)
			{
				AppSettingsSection appSettingsSection = section.As<AppSettingsSection>();
				if (appSettingsSection.Settings[name].IsNull())
				{
					appSettingsSection.Settings.Add(name, value.IsNull() ? string.Empty : value.ToString());
					return true;
				}
				return false;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingSection configurationSettingSection = section.As<ConfigurationSettingSection>();
			if (configurationSettingSection.Settings.Get(name).IsNull())
			{
				ConfigurationSettingElement configurationSettingElement = new ConfigurationSettingElement
				{
					Name = name,
					Type = (type.IsNull() ? value.GetType() : type),
					TypeConverter = null
				};
				configurationSettingElement.TypedValue = value;
				configurationSettingSection.Settings.Add(configurationSettingElement);
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 添加指定名称的命名值
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="value">设置的命名值</param>
	/// <param name="converter">设置的命名值的类型转换器，命名值和字符串之间的相互转换</param>
	/// <returns>如果设置成功返回true，否则返回false</returns>
	public bool AddSetting(string name, object value, TypeConverter converter)
	{
		name.GuardNotNull();
		converter.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section is AppSettingsSection)
			{
				AppSettingsSection appSettingsSection = section.As<AppSettingsSection>();
				if (appSettingsSection.Settings[name].IsNull())
				{
					appSettingsSection.Settings.Add(name, value.IsNull() ? string.Empty : value.ToString());
					return true;
				}
				return false;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingSection configurationSettingSection = section.As<ConfigurationSettingSection>();
			if (configurationSettingSection.Settings.Get(name).IsNull())
			{
				ConfigurationSettingElement configurationSettingElement = new ConfigurationSettingElement
				{
					Name = name,
					Type = null,
					TypeConverter = converter
				};
				configurationSettingElement.TypedValue = value;
				configurationSettingSection.Settings.Add(configurationSettingElement);
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 移除指定名称的命名值
	/// </summary>
	/// <param name="name">命名值的名称</param>
	/// <returns>如果删除成功返回true，否则返回false</returns>
	public bool RemoveSetting(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section is AppSettingsSection)
			{
				AppSettingsSection appSettingsSection = section.As<AppSettingsSection>();
				if (appSettingsSection.Settings[name].IsNull())
				{
					return false;
				}
				appSettingsSection.Settings.Remove(name);
				return true;
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			ConfigurationSettingSection configurationSettingSection = section.As<ConfigurationSettingSection>();
			if (configurationSettingSection.Settings.Get(name).IsNull())
			{
				return false;
			}
			configurationSettingSection.Settings.Remove(name);
			return true;
		});
	}

	/// <summary>
	/// 是否包含指定名称的命名值
	/// </summary>
	/// <param name="name">命名值的名称</param>
	/// <returns>如果包含指定名称的命名值返回true，否则返回false</returns>
	public bool ContainsSetting(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (section.IsNull())
			{
				return false;
			}
			if (section is AppSettingsSection)
			{
				return section.As<AppSettingsSection>().Settings[name].IsNotNull();
			}
			if (!(section is ConfigurationSettingSection))
			{
				throw new ConfigurationErrorsException();
			}
			return section.As<ConfigurationSettingSection>().Settings.Get(name).IsNotNull();
		});
	}

	/// <summary>
	/// 获取泛型枚举器
	/// 在集合副本上进行枚举
	/// </summary>
	/// <returns>枚举器</returns>
	public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
	{
		this.GuardNotDisposed();
		foreach (KeyValuePair<string, object> setting in GetSettings())
		{
			yield return setting;
		}
	}

	/// <summary>
	/// 获取枚举器
	/// 在集合副本上进行枚举
	/// </summary>
	/// <returns>枚举器</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		this.GuardNotDisposed();
		foreach (KeyValuePair<string, object> kvp in GetSettings())
		{
			yield return kvp;
		}
	}
}
