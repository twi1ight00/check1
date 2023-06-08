using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 基础配置组
/// </summary>
public class ConfigurationSourceGroup : ConfigurationSource, IConfigurationSourceGroup, IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable, IEnumerable<IConfigurationSource>, IEnumerable
{
	/// <summary>
	/// 配置组所属的配置源
	/// </summary>
	private IConfigurationSource ownerSource;

	/// <summary>
	/// 配置源列表
	/// </summary>
	private List<IConfigurationSource> sources;

	/// <summary>
	/// 获取配置组标识，等同与SourceID
	/// </summary>
	public Guid GroupID
	{
		get
		{
			return base.SourceID;
		}
		protected set
		{
			base.SourceID = value;
		}
	}

	/// <summary>
	/// 获取配置组所属的配置源
	/// </summary>
	public new IConfigurationSource Owner => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return ownerSource;
	});

	/// <summary>
	/// 获取配置集合中所有的配置源，包括有效和无效的配置源
	/// </summary>
	protected IEnumerable<IConfigurationSource> CachedSources => sources.WhereNotNull();

	/// <summary>
	/// 获取配置集合中所有的配置源，包括有效和无效的配置源
	/// </summary>
	protected IEnumerable<IConfigurationSource> ValidCachedSources => CachedSources.Where((IConfigurationSource s) => ValidateSource(s));

	/// <summary>
	/// 获取配置集合中所有的配置源，包括有效和无效的配置源
	/// </summary>
	protected IEnumerable<IConfigurationSource> InvalidCachedSources => CachedSources.Where((IConfigurationSource s) => !ValidateSource(s));

	/// <summary>
	/// 获取配置集合中包含的配置源数量
	/// </summary>
	public int Count => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return CachedSources.Count();
	});

	/// <summary>
	/// 获取配置集合中配置源的数组
	/// </summary>
	public IConfigurationSource[] Sources => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return CachedSources.ToArray();
	});

	/// <summary>
	/// 获取当前的配置组
	/// </summary>
	public IConfigurationSourceGroup Group => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return this;
	});

	/// <summary>
	/// 获取配置源数组及其所有子配置源的数组
	/// </summary>
	public IConfigurationSource[] AllSources => base.SyncRoot.Read(delegate
	{
		this.GuardNotDisposed();
		return GetGroupSources();
	});

	/// <summary>
	/// 默认初始化
	/// </summary>
	protected ConfigurationSourceGroup()
	{
		GroupID = Guid.NewGuid();
		sources = new List<IConfigurationSource>();
		ownerSource = null;
	}

	/// <summary>
	/// 初始化配置组
	/// </summary>
	/// <param name="owner">配置组所有者</param>
	public ConfigurationSourceGroup(IConfigurationSource owner)
		: this()
	{
		owner.GuardNotNull();
		base.SyncRoot = owner.SyncRoot;
		ownerSource = owner;
	}

	/// <summary>
	/// 基于现有的配置组创建新的配置组
	/// </summary>
	/// <param name="group">待复制的配置源集合</param>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	public ConfigurationSourceGroup(IConfigurationSourceGroup group, bool recursive = false)
		: this()
	{
		ConfigurationSourceGroup configurationSourceGroup = this;
		group.GuardNotNull();
		base.SyncRoot = group.SyncRoot;
		ISyncLocker syncRoot = base.SyncRoot;
		Action action = delegate
		{
			IConfigurationSource[] source = (recursive ? group.GetGroupSources() : group.GetSources());
			configurationSourceGroup.AddRange(source.Where((IConfigurationSource s) => configurationSourceGroup.ValidateSource(s)));
		};
		syncRoot.Read(action);
	}

	/// <summary>
	/// 析构
	/// </summary>
	~ConfigurationSourceGroup()
	{
		Dispose(disposing: false);
	}

	/// <summary>
	/// 清理对象
	/// </summary>
	public sealed override void Dispose()
	{
		base.SyncRoot.Write(delegate
		{
			if (!base.IsDisposed)
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}
		});
	}

	/// <summary>
	/// 执行清理
	/// </summary>
	/// <param name="disposing">是否已经清理</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Clear();
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// 刷新配置源集合中的项目
	/// </summary>
	public void Refresh()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			IConfigurationSource[] array = GetSources();
			foreach (IConfigurationSource configurationSource in array)
			{
				if (configurationSource is IRefreshableConfigurationSource)
				{
					((IRefreshableConfigurationSource)configurationSource).Refresh();
				}
			}
		});
	}

	/// <summary>
	/// 保存配置源集合中的项目
	/// </summary>
	public void Save()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			IConfigurationSource[] array = GetSources();
			foreach (IConfigurationSource configurationSource in array)
			{
				if (configurationSource is ISavableConfigurationSource)
				{
					((ISavableConfigurationSource)configurationSource).Save();
				}
			}
		});
	}

	/// <summary>
	/// 验证配置源
	/// </summary>
	/// <param name="source">配置源对象</param>
	/// <returns>如果满足过滤条件返回true，否则返回false</returns>
	protected virtual bool ValidateSource(IConfigurationSource source)
	{
		if (source.IsNull())
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// 获取配置集合中的所有的配置源
	/// </summary>
	/// <param name="predicate">配置源过滤条件，为null则视为未指定条件</param>
	/// <returns>获取的配置源数组</returns>
	public IConfigurationSource[] GetSources(Func<IConfigurationSource, bool> predicate = null)
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return predicate.IsNull() ? CachedSources.ToArray() : CachedSources.Where(predicate).ToArray();
		});
	}

	/// <summary>
	/// 获取配置集合中的所有配置源及其子配置源的序列
	/// </summary>
	/// <param name="predicate">配置源过滤条件，为null则视为未指定条件</param>
	/// <returns>获取的配置源及其子配置源的数组</returns>
	public IConfigurationSource[] GetGroupSources(Func<IConfigurationSource, bool> predicate = null)
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return GetRecursiveSources(this, predicate).ToArray();
		});
	}

	/// <summary>
	/// 获取配置集合中的所有配置源及其子配置源的序列
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <returns>匹配的配置源数组</returns>
	public T[] GetGroupSources<T>()
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return GetRecursiveSources(this, (IConfigurationSource x) => x is T).OfType<T>().ToArray();
		});
	}

	/// <summary>
	/// 递归获取所有配置源及其子配置源
	/// </summary>
	/// <param name="group">当前处理的配置组</param>
	/// <param name="predicate">配置源过滤条件，为null则视为未指定条件</param>
	/// <returns>返回当前配置组中的配置源以及其子配置源</returns>
	private IEnumerable<IConfigurationSource> GetRecursiveSources(IConfigurationSourceGroup group, Func<IConfigurationSource, bool> predicate = null)
	{
		List<IConfigurationSource> sources = new List<IConfigurationSource>();
		if (group.IsNull())
		{
			return sources;
		}
		IConfigurationSource[] array = group.GetSources(predicate);
		foreach (IConfigurationSource source in array)
		{
			sources.Add(source);
			if (source is IGroupConfigurationSource)
			{
				sources.AddRange(GetRecursiveSources(((IGroupConfigurationSource)source).Group, predicate));
			}
		}
		return sources;
	}

	/// <summary>
	/// 获取符合类型的所有的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <returns>匹配的配置源数组</returns>
	public T[] GetSources<T>() where T : IConfigurationSource
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return CachedSources.OfType<T>().ToArray();
		});
	}

	/// <summary>
	/// 获取符合类型的所有的配置源
	/// </summary>
	/// <param name="type">配置源类型</param>
	/// <returns>匹配的配置源数组</returns>
	public IConfigurationSource[] GetSources(Type type)
	{
		type.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return CachedSources.Where((IConfigurationSource s) => s.GetType().IsType(type)).ToArray();
		});
	}

	/// <summary>
	/// 获取匹配指定ID的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <returns>匹配的配置源数组</returns>
	public IConfigurationSource[] GetSources(Guid id)
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return CachedSources.Where((IConfigurationSource s) => s.SourceID == id).ToArray();
		});
	}

	/// <summary>
	/// 获取匹配指定ID的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="id">配置源ID</param>
	/// <returns>匹配的配置源数组</returns>
	public T[] GetSources<T>(Guid id) where T : IConfigurationSource
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return (from s in CachedSources.OfType<T>()
				where s.SourceID == id
				select s).ToArray();
		});
	}

	/// <summary>
	/// 获取匹配指定ID的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <param name="type">配置源类型</param>
	/// <returns>匹配的配置源数组</returns>
	public IConfigurationSource[] GetSources(Guid id, Type type)
	{
		type.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return CachedSources.Where((IConfigurationSource s) => s.GetType().IsType(type) && s.SourceID == id).ToArray();
		});
	}

	/// <summary>
	/// 获取匹配指定名称的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的配置源数组</returns>
	public IConfigurationSource[] GetSources(string name, bool ignoreCase = true)
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return CachedSources.Where((IConfigurationSource s) => s.SourceName.EqualOrdinal(name, ignoreCase)).ToArray();
		});
	}

	/// <summary>
	/// 获取匹配指定名称的配置源
	/// </summary>
	/// <param name="pattern">配置源名称的正则匹配模式</param>
	/// <param name="options">正则表达式选项</param>
	/// <param name="wholeMatching">是否进行完整匹配，默认为false。</param>
	/// <returns>匹配的配置源数组</returns>
	public IConfigurationSource[] GetSources(string pattern, RegexOptions options, bool wholeMatching = false)
	{
		pattern.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return CachedSources.Where((IConfigurationSource s) => s.SourceName.IsMatch(pattern, wholeMatching, options)).ToArray();
		});
	}

	/// <summary>
	/// 获取匹配指定名称的配置源
	/// </summary>
	/// <param name="pattern">配置源名称的正则匹配模式</param>
	/// <param name="wholeMatching">是否进行完整匹配，默认为false。</param>
	/// <returns>匹配的配置源数组</returns>
	public IConfigurationSource[] GetSources(Regex pattern, bool wholeMatching = false)
	{
		pattern.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return CachedSources.Where((IConfigurationSource s) => s.SourceName.IsMatch(pattern, wholeMatching)).ToArray();
		});
	}

	/// <summary>
	/// 获取符合类型具有指定名称的所有配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的配置源数组</returns>
	public T[] GetSources<T>(string name, bool ignoreCase = true) where T : IConfigurationSource
	{
		name.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return (from s in CachedSources.OfType<T>()
				where s.SourceName.EqualOrdinal(name, ignoreCase)
				select s).ToArray();
		});
	}

	/// <summary>
	/// 获取符合类型具有指定名称的所有的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="type">配置源类型</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的配置源数组</returns>
	public IConfigurationSource[] GetSources(string name, Type type, bool ignoreCase = true)
	{
		name.GuardNotNull();
		type.GuardNotNull();
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return CachedSources.Where((IConfigurationSource s) => s.GetType().IsType(type) && s.SourceName.EqualOrdinal(name, ignoreCase)).ToArray();
		});
	}

	/// <summary>
	/// 获取符合类型的第一个配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	public T GetSource<T>() where T : IConfigurationSource
	{
		return GetSources<T>().FirstOrDefault();
	}

	/// <summary>
	/// 获取符合类型的第一个配置源
	/// </summary>
	/// <param name="type">配置源类型</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	public IConfigurationSource GetSource(Type type)
	{
		return GetSources(type).FirstOrDefault();
	}

	/// <summary>
	/// 获取指定ID的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	public IConfigurationSource GetSource(Guid id)
	{
		return GetSources(id).FirstOrDefault();
	}

	/// <summary>
	/// 获取指定ID的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="id">配置源ID</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	public T GetSource<T>(Guid id) where T : IConfigurationSource
	{
		return GetSources<T>(id).FirstOrDefault();
	}

	/// <summary>
	/// 获取指定名称的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <param name="type">配置源类型</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	public IConfigurationSource GetSource(Guid id, Type type)
	{
		return GetSources(id, type).FirstOrDefault();
	}

	/// <summary>
	/// 获取指定名称的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	public IConfigurationSource GetSource(string name, bool ignoreCase = true)
	{
		return GetSources(name, ignoreCase).FirstOrDefault();
	}

	/// <summary>
	/// 获取指定名称的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	public T GetSource<T>(string name, bool ignoreCase = true) where T : IConfigurationSource
	{
		return GetSources<T>(name, ignoreCase).FirstOrDefault();
	}

	/// <summary>
	/// 获取指定名称的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="type">配置源类型</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>匹配的第一个配置源，如果没有匹配的配置源返回null</returns>
	public IConfigurationSource GetSource(string name, Type type, bool ignoreCase = true)
	{
		return GetSources(name, type, ignoreCase).FirstOrDefault();
	}

	/// <summary>
	/// 添加配置源，同一个配置源只添加一次，重复添加则会忽略。
	/// </summary>
	/// <param name="source">待添加的配置源</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	public bool Add(IConfigurationSource source)
	{
		source.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (!CachedSources.Contains(source, (IConfigurationSource a, IConfigurationSource b) => a.ReferenceEquals(b) || (a.SourceName.EqualOrdinal(b.SourceName, ignoreCase: true) && a.Category.EqualOrdinal(b.Category, ignoreCase: true))))
			{
				sources.Add(source);
				GroupID = Guid.NewGuid();
				AddSourceListener(source);
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 添加配置源序列
	/// </summary>
	/// <param name="sources">待添加的配置源序列</param>
	/// <returns>成功添加的配置源数量</returns>
	public int AddRange(IEnumerable<IConfigurationSource> sources)
	{
		sources.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			int num = 0;
			foreach (IConfigurationSource current in sources)
			{
				if (current.IsNotNull() && Add(current))
				{
					num++;
				}
			}
			return num;
		});
	}

	/// <summary>
	/// 移除配置源
	/// </summary>
	/// <param name="source">待移除的配置源</param>
	/// <returns>移除是否成功</returns>
	public bool Remove(IConfigurationSource source)
	{
		source.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			if (CachedSources.Contains(source, (IConfigurationSource a, IConfigurationSource b) => a.ReferenceEquals(b)))
			{
				RemoveSourceListener(source);
				sources.Remove(source);
				if (ownerSource.IsNotNull() && !source.IsDisposed)
				{
					source.Dispose();
				}
				GroupID = Guid.NewGuid();
				return true;
			}
			return false;
		});
	}

	/// <summary>
	/// 移除指定类型的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <returns>是否移除成功</returns>
	public bool Remove<T>() where T : IConfigurationSource
	{
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			int num = 0;
			T[] array = GetSources<T>();
			foreach (IConfigurationSource source in array)
			{
				if (Remove(source))
				{
					num++;
				}
			}
			return num > 0;
		});
	}

	/// <summary>
	/// 移除指定类型的配置源
	/// </summary>
	/// <param name="type">配置源类型</param>
	/// <returns>是否移除成功</returns>
	public bool Remove(Type type)
	{
		type.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			int num = 0;
			IConfigurationSource[] array = GetSources(type);
			foreach (IConfigurationSource source in array)
			{
				if (Remove(source))
				{
					num++;
				}
			}
			return num > 0;
		});
	}

	/// <summary>
	/// 移除指定ID的配置源
	/// </summary>
	/// <param name="id">配置源ID</param>
	/// <returns>移除是否成功</returns>
	public bool Remove(Guid id)
	{
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			int num = 0;
			IConfigurationSource[] array = GetSources(id);
			foreach (IConfigurationSource source in array)
			{
				if (Remove(source))
				{
					num++;
				}
			}
			return num > 0;
		});
	}

	/// <summary>
	/// 移除指定名称的配置源
	/// </summary>
	/// <param name="name">配置源名称</param>
	/// <param name="ignoreCase">配置源名称是否忽略大小写</param>
	/// <returns>移除是否成功</returns>
	public bool Remove(string name, bool ignoreCase = true)
	{
		name.GuardNotNull();
		return base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			int num = 0;
			IConfigurationSource[] array = GetSources(name, ignoreCase);
			foreach (IConfigurationSource source in array)
			{
				if (Remove(source))
				{
					num++;
				}
			}
			return num > 0;
		});
	}

	/// <summary>
	/// 清空配置源集合
	/// </summary>
	public void Clear()
	{
		base.SyncRoot.Write(delegate
		{
			this.GuardNotDisposed();
			foreach (IConfigurationSource current in CachedSources)
			{
				RemoveSourceListener(current);
				if (ownerSource.IsNotNull() && !current.IsDisposed)
				{
					current.Dispose();
				}
			}
			GroupID = Guid.NewGuid();
			sources.Clear();
		});
	}

	/// <summary>
	/// 获取泛型枚举器
	/// 在集合副本上进行枚举
	/// </summary>
	/// <returns>枚举器</returns>
	public virtual IEnumerator<IConfigurationSource> GetEnumerator()
	{
		this.GuardNotDisposed();
		try
		{
			IConfigurationSource[] array = GetSources();
			for (int i = 0; i < array.Length; i++)
			{
				yield return array[i];
			}
		}
		finally
		{
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
		try
		{
			IConfigurationSource[] array = GetSources();
			for (int i = 0; i < array.Length; i++)
			{
				yield return array[i];
			}
		}
		finally
		{
		}
	}

	/// <summary>
	/// 添加配置源事件处理
	/// </summary>
	/// <param name="source">配置源</param>
	protected void AddSourceListener(IConfigurationSource source)
	{
		if (source is IWatchingConfigurationSource)
		{
			IWatchingConfigurationSource watchingSource = (IWatchingConfigurationSource)source;
			watchingSource.SourceChanged += DoSourceChanged;
			watchingSource.SourceDisposing += DoSourceDisposing;
			watchingSource.SourceDisposed += DoSourceDisposed;
		}
	}

	/// <summary>
	/// 移除配置源事件处理
	/// </summary>
	/// <param name="source">配置源</param>
	protected void RemoveSourceListener(IConfigurationSource source)
	{
		if (source is IWatchingConfigurationSource)
		{
			IWatchingConfigurationSource watchingSource = (IWatchingConfigurationSource)source;
			watchingSource.SourceChanged -= DoSourceChanged;
			watchingSource.SourceDisposing -= DoSourceDisposing;
			watchingSource.SourceDisposed -= DoSourceDisposed;
		}
	}

	/// <summary>
	/// 处理配置源变更事件
	/// 配置源变更后更新配置源信息
	/// </summary>
	/// <param name="sender">源对象</param>
	/// <param name="args">事件参数</param>
	protected virtual void DoSourceChanged(object sender, ConfigurationSourceChangedEventArgs args)
	{
		base.SyncRoot.Write(delegate
		{
			GroupID = Guid.NewGuid();
		});
	}

	/// <summary>
	/// 处理配置源清理前事件
	/// </summary>
	/// <param name="sender">源对象</param>
	/// <param name="args">事件参数</param>
	protected virtual void DoSourceDisposing(object sender, ConfigurationSourceDisposingEventArgs args)
	{
	}

	/// <summary>
	/// 处理配置源清理后事件
	/// </summary>
	/// <param name="sender">源对象</param>
	/// <param name="args">事件参数</param>
	protected virtual void DoSourceDisposed(object sender, ConfigurationSourceDisposedEventArgs args)
	{
		base.SyncRoot.Write(delegate
		{
			Remove(args.Source);
		});
	}

	/// <summary>
	/// 获取指定类型的所有配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	/// <returns>指定类型的所有配置源</returns>
	public T[] GetAll<T>(bool recursive = false) where T : IConfigurationSource
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return recursive ? GetGroupSources<T>() : GetSources<T>();
		});
	}

	/// <summary>
	/// 获取指定的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	/// <returns>指定类型的配置源</returns>
	public T Get<T>(bool recursive = false) where T : IConfigurationSource
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			return GetAll<T>(recursive).FirstOrDefault();
		});
	}

	/// <summary>
	/// 获取指定的配置源
	/// </summary>
	/// <typeparam name="T">配置源类型</typeparam>
	/// <param name="name">配置源类型名称</param>
	/// <param name="recursive">是否递归查找所有的子配置源</param>
	/// <returns>指定类型的配置源</returns>
	public T Get<T>(string name, bool recursive = false) where T : IConfigurationSource
	{
		return base.SyncRoot.Read(delegate
		{
			this.GuardNotDisposed();
			name = name.IfNull(string.Empty);
			return (from s in GetAll<T>(recursive)
				where s.SourceName.EqualOrdinal(name, ignoreCase: true)
				select s).FirstOrDefault();
		});
	}
}
