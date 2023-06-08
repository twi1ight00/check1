using System;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// Xml对象配置源接口
/// </summary>
public class XmlObjectConfigurationSource : FileConfigurationSource, IXmlObjectConfiguration, IConfiguration, IXmlObjectConfigurationSource, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 自定义类型，用于标识null的类型
	/// </summary>
	private class NullType
	{
	}

	/// <summary>
	/// 原始配置数据
	/// </summary>
	private string rawXml;

	/// <summary>
	/// 当前的Xml对象的类型
	/// </summary>
	private object xmlObject;

	/// <summary>
	/// 当前的Xml对象的类型
	/// </summary>
	private Type xmlType;

	/// <summary>
	/// 获取或者设置原始配置数据
	/// </summary>
	public override object RawData
	{
		get
		{
			return rawXml;
		}
		set
		{
			Text = (rawXml = (value.IsNull() ? string.Empty : value.ToString()));
		}
	}

	/// <summary>
	/// 创建扩展设置配置源对象
	/// </summary>
	/// <param name="sourceGroup">父配置组</param>
	/// <param name="sourceName">配置源名称</param>
	/// <param name="sourceFile">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public XmlObjectConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatcher watcher)
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
	public XmlObjectConfigurationSource(IConfigurationSourceGroup sourceGroup, string sourceName, string sourceFile, IWatchingTimer timer)
		: base(sourceGroup, sourceName, sourceFile, timer)
	{
		base.Encoding = Encoding.UTF8;
	}

	/// <summary>
	/// 析构
	/// </summary>
	~XmlObjectConfigurationSource()
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
			rawXml = null;
			xmlObject = null;
			xmlType = null;
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
			rawXml = Text;
			xmlObject = null;
			xmlType = null;
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
			if (xmlType.IsNotNull())
			{
				rawXml = xmlObject.XmlSerialize();
				Text = rawXml;
			}
		});
	}

	/// <summary>
	/// 获取Xml对象
	/// </summary>
	/// <param name="type">获取的Xml对象的类型</param>
	/// <returns>配置中定义的Xml对象</returns>
	public object GetValue(Type type)
	{
		type.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			if (xmlType.IsNull() || !xmlType.ReferenceEquals(type))
			{
				base.SyncRoot.Write(delegate
				{
					xmlObject = rawXml.XmlDeserialize(type);
					xmlType = type;
				});
			}
			return xmlObject;
		});
	}

	/// <summary>
	/// 获取Xml对象
	/// </summary>
	/// <typeparam name="T">获取的Xml对象的类型</typeparam>
	/// <returns>配置中定义的Xml对象</returns>
	public T GetValue<T>()
	{
		return (T)GetValue(typeof(T));
	}

	/// <summary>
	/// 设置Xml配置对象
	/// </summary>
	/// <param name="obj">Xml配置对象</param>
	public void SetValue(object obj)
	{
		obj.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			xmlObject = obj;
			xmlType = obj.GetType();
			rawXml = xmlObject.XmlSerialize();
			Text = rawXml;
		});
	}
}
