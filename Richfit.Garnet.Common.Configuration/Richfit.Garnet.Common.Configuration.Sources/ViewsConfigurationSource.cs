using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Richfit.Garnet.Common.Configuration.Properties;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Watching;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 多视图配置源
/// </summary>
public class ViewsConfigurationSource : FileConfigurationSource, IViewsConfiguration, IConfiguration, IRefreshableConfigurationSource, ISavableConfigurationSource, IWatchingConfigurationSource, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 配置视图
	/// </summary>
	private List<IConfigurationView> views = new List<IConfigurationView>(8);

	/// <summary>
	/// 获取配置文件对象
	/// </summary>
	FileInfo IViewsConfiguration.File => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return base.File;
	});

	/// <summary>
	/// 获取默认配置视图
	/// </summary>
	public override IConfigurationView View => GetView();

	/// <summary>
	/// 获取默认视图
	/// </summary>
	IConfigurationView IViewsConfiguration.View => GetView();

	/// <summary>
	/// 获取配置中所有配置视图的数组
	/// </summary>
	public IConfigurationView[] Views => ((IViewsConfiguration)this).Views;

	/// <summary>
	/// 获取配置中所有配置视图的数组
	/// </summary>
	IConfigurationView[] IViewsConfiguration.Views => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return views.ToArray();
	});

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="owner">父配置组</param>
	/// <param name="name">配置源名称</param>
	/// <param name="file">配置文件</param>
	/// <param name="watcher">配置源监控器</param>
	public ViewsConfigurationSource(IConfigurationSourceGroup owner, string name, string file, IWatcher watcher)
		: base(owner, name, file, watcher)
	{
		Initialize();
	}

	/// <summary>
	/// 创建配置源对象
	/// </summary>
	/// <param name="owner">父配置组</param>
	/// <param name="name">配置源名称</param>
	/// <param name="file">配置文件</param>
	/// <param name="timer">配置源监控定时器</param>
	public ViewsConfigurationSource(IConfigurationSourceGroup owner, string name, string file, IWatchingTimer timer)
		: base(owner, name, file, timer)
	{
		Initialize();
	}

	/// <summary>
	/// 析构
	/// </summary>
	~ViewsConfigurationSource()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 初始化
	/// </summary>
	private void Initialize()
	{
		base.Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
	}

	/// <summary>
	/// 清理对象方法
	/// </summary>
	/// <param name="disposing">是否已经执行了清理</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			ClearViews();
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
			base.LoadConfiguration();
			LoadConfigurationViews();
			return base.IsValid = Exists;
		}
		catch
		{
			throw;
		}
	}

	/// <summary>
	/// 加载配置视图
	/// </summary>
	private void LoadConfigurationViews()
	{
		try
		{
			string xml = Text;
			XDocument xdoc = XDocument.Parse(xml);
			XElement configuration = xdoc.Element("configuration");
			XElement configViews = configuration.Element("configViews");
			XElement viewContent = null;
			string viewName = null;
			Type viewType = null;
			IConfigurationView view = null;
			List<IConfigurationView> newViews = new List<IConfigurationView>(8);
			foreach (XElement configView in configViews.Elements("view"))
			{
				viewName = configView.Attribute("name").Value;
				viewContent = configuration.Element(viewName);
				if (viewContent.IsNull())
				{
					throw new ConfigurationErrorsException("No configuration view.");
				}
				view = views.Where((IConfigurationView x) => x.Name.EqualOrdinal(viewName)).FirstOrDefault();
				if (view.IsNotNull())
				{
					view.Deserialize(viewContent.ToString());
					RemoveCachedView(view);
					view.Owner = this;
					view.SyncRoot = base.SyncRoot;
					newViews.Add(view);
					continue;
				}
				viewType = configView.Attribute("type").Value.ResolveType();
				if (viewType.IsType<IConfigurationView>())
				{
					view = viewType.CreateInstance<IConfigurationView>();
					view.Owner = this;
					view.SyncRoot = base.SyncRoot;
					view.Deserialize(viewContent.ToString());
					newViews.Add(view);
				}
			}
			ClearCachedViews();
			views = newViews;
		}
		catch (Exception ex)
		{
			throw new ConfigurationErrorsException(Literals.MSG_E_InvalidConfiguration, ex);
		}
	}

	/// <summary>
	/// 保存配置
	/// </summary>
	public override void Save()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			XDocument xDocument = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
			XElement xElement = new XElement("configuration");
			xDocument.Add(xElement);
			XElement xElement2 = new XElement("configViews");
			xElement.Add(xElement2);
			XElement xElement3 = null;
			XElement xElement4 = null;
			foreach (IConfigurationView current in views)
			{
				xElement3 = new XElement("view");
				xElement3.Add(new XAttribute("name", current.Name), new XAttribute("type", current.GetType().AssemblyQualifiedName));
				xElement2.Add(xElement3);
				xElement4 = XElement.Parse(current.Serialize());
				xElement.Add(xElement4);
			}
			Text = xDocument.ToString();
			LoadConfiguration();
		});
	}

	/// <summary>
	/// 获取所有配置视图
	/// </summary>
	/// <returns>配置源中所有配置视图的集合</returns>
	public IConfigurationView[] GetViews()
	{
		return ((IViewsConfiguration)this).GetViews();
	}

	/// <summary>
	/// 获取所有配置视图
	/// </summary>
	/// <returns>配置源中所有配置视图的集合</returns>
	IConfigurationView[] IViewsConfiguration.GetViews()
	{
		return ((IViewsConfiguration)this).GetViews((Func<IConfigurationView, bool>)((IConfigurationView v) => true));
	}

	/// <summary>
	/// 获取所有指定类型的配置视图
	/// </summary>
	/// <param name="viewType">配置视图类型</param>
	/// <returns>指定类型的配置视图数组，如果没有该类型的配置视图，返回空数组</returns>
	public IConfigurationView[] GetViews(Type viewType)
	{
		return ((IViewsConfiguration)this).GetViews(viewType);
	}

	/// <summary>
	/// 获取所有指定类型的配置视图
	/// </summary>
	/// <param name="viewType">配置视图类型</param>
	/// <returns>指定类型的配置视图数组，如果没有该类型的配置视图，返回空数组</returns>
	IConfigurationView[] IViewsConfiguration.GetViews(Type viewType)
	{
		return ((IViewsConfiguration)this).GetViews((Func<IConfigurationView, bool>)((IConfigurationView v) => v.IsType(viewType)));
	}

	/// <summary>
	/// 获取所有指定类型的配置视图对象
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <returns>指定类型的配置视图数组，如果没有该类型的配置视图，返回空数组</returns>
	public T[] GetViews<T>() where T : IConfigurationView
	{
		return ((IViewsConfiguration)this).GetViews<T>();
	}

	/// <summary>
	/// 获取所有指定类型的配置视图对象
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <returns>指定类型的配置视图数组，如果没有该类型的配置视图，返回空数组</returns>
	T[] IViewsConfiguration.GetViews<T>()
	{
		return ((IViewsConfiguration)this).GetViews((Func<T, bool>)((T v) => true));
	}

	/// <summary>
	/// 获取满足指定条件的配置视图数组
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="predicate">匹配条件</param>
	/// <returns>返回满足指定条件的配置视图数组，如果没有符合的配置视图，返回空数组</returns>
	public T[] GetViews<T>(Func<T, bool> predicate) where T : IConfigurationView
	{
		return ((IViewsConfiguration)this).GetViews(predicate);
	}

	/// <summary>
	/// 获取满足指定条件的配置视图数组
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="predicate">匹配条件</param>
	/// <returns>返回满足指定条件的配置视图数组，如果没有符合的配置视图，返回空数组</returns>
	T[] IViewsConfiguration.GetViews<T>(Func<T, bool> predicate)
	{
		predicate.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return views.OfType<T>().Where(predicate).ToArray();
		});
	}

	/// <summary>
	/// 获取默认配置视图
	/// </summary>
	/// <returns>默认配置视图，如果没有默认配置视图，返回null</returns>
	public IConfigurationView GetView()
	{
		return ((IViewsConfiguration)this).GetView();
	}

	/// <summary>
	/// 获取默认配置视图
	/// </summary>
	/// <returns>默认配置视图，如果没有默认配置视图，返回null</returns>
	IConfigurationView IViewsConfiguration.GetView()
	{
		return ((IViewsConfiguration)this).GetView((Func<IConfigurationView, bool>)((IConfigurationView v) => true));
	}

	/// <summary>
	/// 获取与指定类型匹配的第一个配置视图
	/// </summary>
	/// <param name="viewType">配置视图类型</param>
	/// <returns>与指定类型匹配的第一个配置视图，如果没有匹配的配置视图，返回null</returns>
	public IConfigurationView GetView(Type viewType)
	{
		return ((IViewsConfiguration)this).GetView(viewType);
	}

	/// <summary>
	/// 获取与指定类型匹配的第一个配置视图
	/// </summary>
	/// <param name="viewType">配置视图类型</param>
	/// <returns>与指定类型匹配的第一个配置视图，如果没有匹配的配置视图，返回null</returns>
	IConfigurationView IViewsConfiguration.GetView(Type viewType)
	{
		viewType.GuardNotNull();
		return ((IViewsConfiguration)this).GetView((Func<IConfigurationView, bool>)((IConfigurationView v) => v.IsType(viewType)));
	}

	/// <summary>
	/// 获取与指定类型的第一个配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <returns>与指定类型匹配的第一个配置视图，如果没有匹配的配置视图，返回null</returns>
	public T GetView<T>() where T : IConfigurationView
	{
		return ((IViewsConfiguration)this).GetView<T>();
	}

	/// <summary>
	/// 获取与指定类型的第一个配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <returns>与指定类型匹配的第一个配置视图，如果没有匹配的配置视图，返回null</returns>
	T IViewsConfiguration.GetView<T>()
	{
		return ((IViewsConfiguration)this).GetView((Func<T, bool>)((T v) => true));
	}

	/// <summary>
	/// 获取指定名称的配置视图对象
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>匹配的配置视图对象，如果没有匹配的配置视图，返回null</returns>
	public IConfigurationView GetView(string viewName, bool ignoreCase = false)
	{
		return ((IViewsConfiguration)this).GetView(viewName, ignoreCase);
	}

	/// <summary>
	/// 获取指定名称的配置视图对象
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>匹配的配置视图对象，如果没有匹配的配置视图，返回null</returns>
	IConfigurationView IViewsConfiguration.GetView(string viewName, bool ignoreCase)
	{
		viewName.GuardNotNull();
		return ((IViewsConfiguration)this).GetView((Func<IConfigurationView, bool>)((IConfigurationView v) => v.Name.EqualOrdinal(viewName, ignoreCase)));
	}

	/// <summary>
	/// 获取指定名称和类型的配置视图对象
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="viewType">配置视图类型</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>匹配的配置视图对象，如果没有匹配的配置视图，返回null</returns>
	public IConfigurationView GetView(string viewName, Type viewType, bool ignoreCase = false)
	{
		return ((IViewsConfiguration)this).GetView(viewName, viewType, ignoreCase);
	}

	/// <summary>
	/// 获取指定名称和类型的配置视图对象
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="viewType">配置视图类型</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>匹配的配置视图对象，如果没有匹配的配置视图，返回null</returns>
	IConfigurationView IViewsConfiguration.GetView(string viewName, Type viewType, bool ignoreCase)
	{
		viewName.GuardNotNull();
		viewType.GuardNotNull();
		return ((IViewsConfiguration)this).GetView((Func<IConfigurationView, bool>)((IConfigurationView v) => v.IsType(viewType) && v.Name.EqualOrdinal(viewName, ignoreCase)));
	}

	/// <summary>
	/// 获取指定名称、指定类型的配置视图对象
	/// 没有匹配的配置视图，则返回null
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>匹配的配置视图对象，如果没有匹配的配置视图，返回null</returns>
	public T GetView<T>(string viewName, bool ignoreCase = false) where T : IConfigurationView
	{
		return ((IViewsConfiguration)this).GetView<T>(viewName, ignoreCase);
	}

	/// <summary>
	/// 获取指定名称、指定类型的配置视图对象
	/// 没有匹配的配置视图，则返回null
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>匹配的配置视图对象，如果没有匹配的配置视图，返回null</returns>
	T IViewsConfiguration.GetView<T>(string viewName, bool ignoreCase)
	{
		viewName.GuardNotNull();
		return ((IViewsConfiguration)this).GetView((Func<T, bool>)((T v) => v.Name.EqualOrdinal(viewName, ignoreCase)));
	}

	/// <summary>
	/// 获取满足指定条件的第一个配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="predicate">匹配条件</param>
	/// <returns>返回满足指定条件的第一个配置视图，如果没有符合的配置视图，返回null</returns>
	public T GetView<T>(Func<T, bool> predicate) where T : IConfigurationView
	{
		return ((IViewsConfiguration)this).GetView(predicate);
	}

	/// <summary>
	/// 获取满足指定条件的第一个配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="predicate">匹配条件</param>
	/// <returns>返回满足指定条件的第一个配置视图，如果没有符合的配置视图，返回null</returns>
	T IViewsConfiguration.GetView<T>(Func<T, bool> predicate)
	{
		predicate.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return views.OfType<T>().Where(predicate).FirstOrDefault();
		});
	}

	/// <summary>
	/// 添加配置视图
	/// </summary>
	/// <param name="view">待添加的配置视图</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	public bool AddView(IConfigurationView view)
	{
		return ((IViewsConfiguration)this).AddView(view);
	}

	/// <summary>
	/// 添加配置视图
	/// </summary>
	/// <param name="view">待添加的配置视图</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool IViewsConfiguration.AddView(IConfigurationView view)
	{
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (views.Any((IConfigurationView v) => v.ReferenceEquals(view) || v.Name.EqualOrdinal(view.Name)))
			{
				return false;
			}
			view.Owner = this;
			view.SyncRoot = base.SyncRoot;
			views.Add(view);
			return true;
		});
	}

	/// <summary>
	/// 添加指定类型的配置视图
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="viewType">配置视图类型</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	public bool AddView(string viewName, Type viewType)
	{
		return ((IViewsConfiguration)this).AddView(viewName, viewType);
	}

	/// <summary>
	/// 添加指定类型的配置视图
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="viewType">配置视图类型</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool IViewsConfiguration.AddView(string viewName, Type viewType)
	{
		viewName.GuardNotNull();
		viewType.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (views.Any((IConfigurationView v) => v.Name.EqualOrdinal(viewName)))
			{
				return false;
			}
			IConfigurationView configurationView = viewType.CreateInstance<IConfigurationView>();
			configurationView.Name = viewName;
			configurationView.Owner = this;
			configurationView.SyncRoot = base.SyncRoot;
			views.Add(configurationView);
			return true;
		});
	}

	/// <summary>
	/// 添加指定名称的配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="viewName">配置视图名称</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	public bool AddView<T>(string viewName) where T : IConfigurationView, new()
	{
		return ((IViewsConfiguration)this).AddView<T>(viewName);
	}

	/// <summary>
	/// 添加指定名称的配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="viewName">配置视图名称</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool IViewsConfiguration.AddView<T>(string viewName)
	{
		viewName.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (views.Any((IConfigurationView v) => v.Name.EqualOrdinal(viewName)))
			{
				return false;
			}
			IConfigurationView configurationView = new T();
			configurationView.Name = viewName;
			configurationView.Owner = this;
			configurationView.SyncRoot = base.SyncRoot;
			views.Add(configurationView);
			return true;
		});
	}

	/// <summary>
	/// 移除指定名称的配置视图
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>如果移除成功返回true，否则返回false</returns>
	public bool RemoveView(string viewName, bool ignoreCase = false)
	{
		return ((IViewsConfiguration)this).RemoveView(viewName, ignoreCase);
	}

	/// <summary>
	/// 移除指定名称的配置视图
	/// </summary>
	/// <param name="viewName">配置视图名称</param>
	/// <param name="ignoreCase">配置视图名称是否区分大小写</param>
	/// <returns>如果移除成功返回true，否则返回false</returns>
	bool IViewsConfiguration.RemoveView(string viewName, bool ignoreCase)
	{
		viewName.GuardNotNull();
		return ((IViewsConfiguration)this).RemoveView((Func<IConfigurationView, bool>)((IConfigurationView v) => v.Name.EqualOrdinal(viewName, ignoreCase))) > 0;
	}

	/// <summary>
	/// 移除符合指定条件的配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="predicate">配置视图筛选条件</param>
	/// <returns>删除的配置视图数量</returns>
	public int RemoveView<T>(Func<T, bool> predicate) where T : IConfigurationView
	{
		return ((IViewsConfiguration)this).RemoveView(predicate);
	}

	/// <summary>
	/// 移除符合指定条件的配置视图
	/// </summary>
	/// <typeparam name="T">配置视图类型</typeparam>
	/// <param name="predicate">配置视图筛选条件</param>
	/// <returns>删除的配置视图数量</returns>
	int IViewsConfiguration.RemoveView<T>(Func<T, bool> predicate)
	{
		predicate.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			int num = 0;
			IConfigurationView[] array = views.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] is T && predicate((T)array[i]))
				{
					IConfigurationView configurationView = array[i];
					configurationView.Owner = null;
					configurationView.SyncRoot = null;
					views.RemoveAt(i - num);
					num++;
				}
			}
			return num;
		});
	}

	/// <summary>
	/// 移除缓存的配置节
	/// </summary>
	/// <param name="view"></param>
	/// <returns></returns>
	private bool RemoveCachedView(IConfigurationView view)
	{
		if (view.IsNull())
		{
			return false;
		}
		int index = views.FindIndex((IConfigurationView s) => s.ReferenceEquals(view));
		if (index >= 0)
		{
			views.RemoveAt(index);
			return true;
		}
		return false;
	}

	/// <summary>
	/// 清空配置节列表，删除所有配置节
	/// </summary>
	public void ClearViews()
	{
		((IViewsConfiguration)this).ClearViews();
	}

	/// <summary>
	/// 清空配置节列表，删除所有配置节
	/// </summary>
	void IViewsConfiguration.ClearViews()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			ClearCachedViews();
		});
	}

	/// <summary>
	/// 清空缓存的配置节
	/// </summary>
	private void ClearCachedViews()
	{
		if (views.IsNotNull())
		{
			views.Clear();
		}
	}
}
