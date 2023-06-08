using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Richfit.Garnet.Common.Configuration.Properties;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Configuration.Views;

/// <summary>
/// 配置视图基类
/// </summary>
public abstract class ConfigurationView : IConfigurationView
{
	/// <summary>
	/// 配置视图名称
	/// </summary>
	private string name;

	/// <summary>
	/// 视图所有者
	/// </summary>
	private IViewsConfiguration owner;

	/// <summary>
	/// 同步锁对象
	/// </summary>
	private ISyncLocker syncRoot;

	/// <summary>
	/// 获取或者设置配置视图名称
	/// </summary>
	public string Name
	{
		get
		{
			return syncRoot.Read(() => name);
		}
		set
		{
			syncRoot.Write(() => name = value.GuardNotNullAndEmpty(null, Literals.MSG_E_InvalidConfigurationViewName));
		}
	}

	/// <summary>
	/// 获取或者设置视图所有者对象
	/// </summary>
	public IViewsConfiguration Owner
	{
		get
		{
			return syncRoot.Read(() => owner);
		}
		set
		{
			syncRoot.Write(() => owner = value);
		}
	}

	/// <summary>
	/// 获取或者设置同步锁对象
	/// </summary>
	public ISyncLocker SyncRoot
	{
		get
		{
			return syncRoot;
		}
		set
		{
			syncRoot = value.GuardNotNull();
		}
	}

	/// <summary>
	/// 初始化默认配置视图
	/// </summary>
	public ConfigurationView()
	{
		syncRoot = new ReadWriteLocker();
		name = string.Empty;
		owner = null;
	}

	/// <summary>
	/// 初始化配置视图
	/// </summary>
	/// <param name="xml">视图数据</param>
	public ConfigurationView(string xml)
		: this()
	{
		Deserialize(xml);
	}

	/// <summary>
	/// 制作配置视图副本
	/// </summary>
	/// <returns>当前配置视图的副本</returns>
	public virtual IConfigurationView Copy()
	{
		return syncRoot.Read(delegate
		{
			IConfigurationView configurationView = GetType().CreateInstance<IConfigurationView>();
			configurationView.Deserialize(Serialize());
			configurationView.Name = Name;
			configurationView.Owner = Owner;
			configurationView.SyncRoot = SyncRoot;
			return configurationView;
		});
	}

	/// <summary>
	/// 获取配置视图副本
	/// </summary>
	/// <typeparam name="T">配置视图副本类型</typeparam>
	/// <returns></returns>
	public virtual T Copy<T>() where T : IConfigurationView, new()
	{
		return syncRoot.Read(delegate
		{
			T result = new T();
			result.Deserialize(Serialize());
			result.Name = Name;
			result.Owner = Owner;
			result.SyncRoot = SyncRoot;
			return result;
		});
	}

	/// <summary>
	/// 将视图序列化为Xml格式的配置数据
	/// </summary>
	/// <returns>Xml格式配置数据</returns>
	public string Serialize()
	{
		return syncRoot.Read(delegate
		{
			XElement content = SerializeView();
			XDocument xDocument = new XDocument(new XElement(Name, content));
			return xDocument.ToString();
		});
	}

	/// <summary>
	/// 序列化视图
	/// </summary>
	/// <returns></returns>
	protected abstract XElement SerializeView();

	/// <summary>
	/// 将Xml格式的配置数据反序列化为视图对象
	/// </summary>
	/// <param name="xml">Xml格式配置数据</param>
	public void Deserialize(string xml)
	{
		xml.GuardNotNullAndEmpty(typeof(ConfigurationErrorsException), Literals.MSG_E_InvalidConfiguration);
		syncRoot.Write(delegate
		{
			XDocument xDocument = XDocument.Parse(xml);
			XElement xElement = xDocument.Elements().FirstOrDefault().GuardNotNull(typeof(ConfigurationErrorsException), Literals.MSG_E_InvalidConfiguration);
			Name = xElement.Name.LocalName;
			DeserializeView(xElement);
		});
	}

	/// <summary>
	/// 反序列化视图
	/// </summary>
	/// <param name="root">Xml数据根节点</param>
	protected abstract void DeserializeView(XElement root);

	/// <summary>
	/// 获取属性值
	/// </summary>
	/// <param name="name">属性名称</param>
	/// <param name="ignoreCase">是否忽略属性名称的大小写</param>
	/// <returns>属性值</returns>
	public object GetValue(string name, bool ignoreCase = false)
	{
		name.GuardNotNull();
		return SyncRoot.Read(() => GetViewValue(name, ignoreCase));
	}

	/// <summary>
	/// 获取属性值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="name">属性名称</param>
	/// <param name="ignoreCase">是否忽略属性名称的大小写</param>
	/// <returns>属性值</returns>
	public T GetValue<T>(string name, bool ignoreCase = false)
	{
		return (T)GetValue(name, ignoreCase);
	}

	/// <summary>
	/// 获取视图属性值
	/// </summary>
	/// <param name="name">属性值类型</param>
	/// <param name="ignoreCase">是否忽略属性名称的大小写</param>
	/// <returns>属性值</returns>
	protected virtual object GetViewValue(string name, bool ignoreCase)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
		if (ignoreCase)
		{
			flags |= BindingFlags.IgnoreCase;
		}
		PropertyInfo pinfo = GetType().GetProperty(name, flags);
		if (pinfo.IsNull())
		{
			throw new ConfigurationErrorsException();
		}
		return pinfo.GetValue(this, null);
	}

	/// <summary>
	/// 设置属性值
	/// </summary>
	/// <param name="name">属性名称</param>
	/// <param name="value">属性值</param>
	/// <param name="ignoreCase">是否忽略属性名称的大小写</param>
	public void SetValue(string name, object value, bool ignoreCase = false)
	{
		name.GuardNotNull();
		SyncRoot.Write(delegate
		{
			SetViewValue(name, value, ignoreCase);
		});
	}

	/// <summary>
	/// 设置视图属性值
	/// </summary>
	/// <param name="name">属性名称</param>
	/// <param name="value">属性值</param>
	/// <param name="ignoreCase">是否忽略属性名称的大小写</param>
	protected virtual void SetViewValue(string name, object value, bool ignoreCase)
	{
		BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
		if (ignoreCase)
		{
			flags |= BindingFlags.IgnoreCase;
		}
		PropertyInfo pinfo = GetType().GetProperty(name, flags);
		if (pinfo.IsNull())
		{
			throw new ConfigurationErrorsException();
		}
		pinfo.SetValue(this, value, null);
	}

	/// <summary>
	/// 返回配置视图序列化后的Xml数据
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return Serialize();
	}
}
