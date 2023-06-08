using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 设置配置源组集合
/// </summary>
public class SettingsConfigurationSourceGroup : ConfigurationSourceGroup, ISettingsGroupConfiguration, IConfiguration, ISettingsGroupConfigurationSource, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IGroupConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
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
	/// 使用配置源组初始化
	/// </summary>
	/// <param name="group">配置源组</param>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	public SettingsConfigurationSourceGroup(IConfigurationSourceGroup group, bool recursive = false)
		: base(group, recursive)
	{
	}

	/// <summary>
	/// 验证配置源
	/// </summary>
	/// <param name="source"></param>
	/// <returns></returns>
	protected override bool ValidateSource(IConfigurationSource source)
	{
		if (!base.ValidateSource(source))
		{
			return false;
		}
		return source is ISettingsConfiguration;
	}

	/// <summary>
	/// 获取所有的命名值配置源
	/// </summary>
	/// <returns>命名值配置源数组</returns>
	public ISettingsConfiguration[] GetConfigurations()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return GetSources<ISettingsConfiguration>();
		});
	}

	/// <summary>
	/// 获取指定名称的命名值配置源
	/// </summary>
	/// <param name="name">命名值配置源名称</param>
	/// <returns>命名值配置源</returns>
	public ISettingsConfiguration GetConfiguration(string name)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return GetSource<ISettingsConfiguration>(name);
		});
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
			return (from s in base.ValidCachedSources.OfType<ISettingsConfiguration>()
				select s.GetSettingCount()).Sum();
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
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				dictionary.AddRange(settingsConfiguration.GetValues());
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
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.GetValue(name);
				}
			}
			return null;
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
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.SetValue(name, value);
				}
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
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				dictionary.AddRange(settingsConfiguration.GetSettings());
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
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.GetSetting(name);
				}
			}
			return null;
		});
	}

	/// <summary>
	/// 获取指定名称的命名值，如果指定名称的命名值不存在则返回指定的默认值
	/// </summary>
	/// <typeparam name="T">命名值的类型</typeparam>
	/// <param name="name">命名值名称</param>
	/// <param name="defaultValue">命名值的默认值</param>
	/// <returns>命名值</returns>
	public T GetSetting<T>(string name, T defaultValue = default(T))
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.GetSetting(name, default(T));
				}
			}
			return defaultValue;
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
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.GetSetting(name, converter);
				}
			}
			return null;
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
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.GetSetting(name, converter, default(T));
				}
			}
			return defaultValue;
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
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.GetSettingType(name);
				}
			}
			return null;
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
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.GetSettingConverter(name);
				}
			}
			return null;
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
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.SetSetting(name, value);
				}
			}
			return false;
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
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return settingsConfiguration.SetSetting(name, value, converter);
				}
			}
			return false;
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
			foreach (ISettingsConfiguration settingsConfiguration in base.ValidCachedSources)
			{
				if (settingsConfiguration.ContainsSetting(name))
				{
					return true;
				}
			}
			return false;
		});
	}

	/// <summary>
	/// 获取泛型枚举器
	/// 在集合副本上进行枚举
	/// </summary>
	/// <returns>枚举器</returns>
	public new IEnumerator<KeyValuePair<string, object>> GetEnumerator()
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
