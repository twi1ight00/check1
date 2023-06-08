using System;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Json对象配置源
/// </summary>
public class JsonObjectConfigurationSource : FileConfigurationSource, IJsonObjectConfiguration, IConfiguration, IJsonObjectConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 自定义类型，用于标识null的类型
	/// </summary>
	private class NullType
	{
	}

	/// <summary>
	/// 原始数据文本
	/// </summary>
	private string rawText;

	/// <summary>
	/// 当前的JSON对象的类型
	/// </summary>
	private object jsonObject;

	/// <summary>
	/// 当前的JSON对象的类型
	/// </summary>
	private Type jsonType;

	/// <summary>
	/// 获取或者设置原始配置数据
	/// </summary>
	public override object RawData
	{
		get
		{
			return rawText;
		}
		set
		{
			Text = (rawText = (value.IsNull() ? string.Empty : value.ToString()));
		}
	}

	/// <summary>
	/// 创建扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public JsonObjectConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
		: base(sourceGroup, sourceName, sourceFile, watcher)
	{
		base.Encoding = Encoding.UTF8;
	}

	/// <summary>
	/// 创建扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public JsonObjectConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
		base.Encoding = Encoding.UTF8;
	}

	/// <summary>
	/// 析构
	/// </summary>
	~JsonObjectConfigurationSource()
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
			rawText = null;
			jsonObject = null;
			jsonType = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 加载扩展设置配置
	/// </summary>
	/// <returns>如果加载成功返回true，否则返回false</returns>
	protected override bool LoadConfiguration()
	{
		try
		{
			bool status = base.LoadConfiguration();
			rawText = Text;
			jsonObject = null;
			jsonType = null;
			return status;
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 保存配置源
	/// </summary>
	public override void Save()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (jsonType.IsNotNull())
			{
				rawText = jsonObject.JsonSerialize();
				Text = rawText;
			}
		});
	}

	/// <summary>
	/// 获取JSON对象
	/// </summary>
	/// <param name="type">获取的JSON对象的类型</param>
	/// <returns>配置中定义的JSON对象</returns>
	public object GetValue(Type type)
	{
		type.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (jsonType.IsNull() || !jsonType.ReferenceEquals(type))
			{
				if (rawText.IsNull())
				{
					return null;
				}
				base.SyncRoot.Write(delegate
				{
					jsonObject = Text.JsonDeserialize(type);
					jsonType = type;
				});
			}
			return jsonObject;
		});
	}

	/// <summary>
	/// 获取JSON对象
	/// </summary>
	/// <typeparam name="T">获取的JSON对象的类型</typeparam>
	/// <returns>配置中定义的JSON对象</returns>
	public T GetValue<T>()
	{
		return GetValue(typeof(T)).As<T>();
	}

	/// <summary>
	/// 设置JSON配置对象
	/// </summary>
	/// <param name="obj">JSON配置对象</param>
	public void SetValue(object obj)
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			jsonObject = obj;
			jsonType = (obj.IsNull() ? typeof(NullType) : obj.GetType());
			rawText = jsonObject.JsonSerialize();
			Text = rawText;
		});
	}
}
