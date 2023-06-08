using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Text;

/// <summary>
/// 正则表达式缓存
/// </summary>
public static class RegexManager
{
	/// <summary>
	/// 正则表达式信息
	/// </summary>
	private class RegexInfo : IEquatable<RegexInfo>, IComparable<RegexInfo>, IComparable
	{
		/// <summary>
		/// 正则表达式标记值
		/// </summary>
		private string mark;

		/// <summary>
		/// 正则表达式
		/// </summary>
		private string text;

		/// <summary>
		/// 正则表达式选项
		/// </summary>
		private RegexOptions options;

		/// <summary>
		/// 正则表达式对象
		/// </summary>
		private Regex regex;

		/// <summary>
		/// 活动时间，最后访问时间
		/// </summary>
		private long activeTime;

		/// <summary>
		/// 活动计数器
		/// </summary>
		private long activeCount;

		/// <summary>
		/// 获取最后活动时间
		/// </summary>
		public long ActiveTime => activeTime;

		/// <summary>
		/// 获取总计活动次数
		/// </summary>
		public long ActiveCount => activeCount;

		/// <summary>
		/// 默认初始化
		/// </summary>
		private RegexInfo()
		{
			text = string.Empty;
			options = RegexOptions.None;
			mark = string.Empty;
			regex = null;
			activeTime = DateTime.Now.Ticks;
			activeCount = 0L;
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="text">正则表达式</param>
		public RegexInfo(string text)
			: this()
		{
			text.GuardNotNull(Literals.MSG_RegexManagerRegexTextEmpty);
			this.text = text;
			mark = "{0}@{1}".FormatValue(this.text, options.ToString());
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="text">正则表达式</param>
		/// <param name="options">正则表达式选项</param>
		public RegexInfo(string text, RegexOptions options)
			: this()
		{
			text.GuardNotNull(Literals.MSG_RegexManagerRegexTextEmpty);
			this.text = text;
			this.options = options;
			mark = "{0}@{1}".FormatValue(this.text, this.options.ToString());
		}

		/// <summary>
		/// 获取哈希值
		/// </summary>
		/// <returns>信息结构的哈希值</returns>
		public override int GetHashCode()
		{
			return mark.GetHashCode();
		}

		/// <summary>
		/// 测试两个信息结构是否相等
		/// </summary>
		/// <param name="obj">待检测的对象</param>
		/// <returns>如果相等返回true，否则返回false</returns>
		public override bool Equals(object obj)
		{
			if (obj is RegexInfo)
			{
				return Equals((RegexInfo)obj);
			}
			return object.Equals(this, obj);
		}

		/// <summary>
		/// 测试两个信息结构是否相等
		/// </summary>
		/// <param name="info">待检测的信息结构</param>
		/// <returns>如果相等返回true，否则返回false</returns>
		public bool Equals(RegexInfo info)
		{
			return mark.EqualOrdinal(info.mark);
		}

		/// <summary>
		/// 比较两个信息结构的活动计数和活动时间
		/// </summary>
		/// <param name="obj">待比较的信息结构</param>
		/// <returns></returns>
		public int CompareTo(object obj)
		{
			if (obj is RegexInfo)
			{
				return CompareTo((RegexInfo)obj);
			}
			throw new NotSupportedException();
		}

		/// <summary>
		/// 比较两个信息结构的活动计数和活动时间
		/// </summary>
		/// <param name="other">待比较的信息结构</param>
		/// <returns></returns>
		public int CompareTo(RegexInfo other)
		{
			if (activeCount == other.activeCount)
			{
				return activeTime.CompareTo(other.activeTime);
			}
			return activeCount.CompareTo(other.activeCount);
		}

		/// <summary>
		/// 获取当前的正则表达式
		/// </summary>
		/// <returns></returns>
		public Regex GetRegex()
		{
			return regex;
		}

		/// <summary>
		/// 设置当前的正则表达式
		/// </summary>
		/// <param name="regex"></param>
		public void SetRegex(Regex regex)
		{
			if (regex.IsNotNull())
			{
				Interlocked.Exchange(ref this.regex, regex);
			}
		}

		/// <summary>
		/// 使用当前的正则表达式的信息创建正则表达式
		/// </summary>
		/// <returns></returns>
		public Regex CreateRegex()
		{
			Interlocked.Exchange(ref regex, new Regex(text, options));
			return regex;
		}

		/// <summary>
		/// 递增访问计数，如果访问计数已经到达最大值，则重置为0
		/// </summary>
		/// <returns>是否已经重置计数</returns>
		public bool IncreaseActiveCount()
		{
			long count = Interlocked.CompareExchange(ref activeCount, 0L, long.MaxValue);
			Interlocked.Increment(ref activeCount);
			return count == long.MaxValue;
		}

		/// <summary>
		/// 重置访问计数
		/// </summary>
		/// <returns></returns>
		public void ResetActiveCount()
		{
			Interlocked.Exchange(ref activeCount, 0L);
		}

		/// <summary>
		/// 更新访问时间
		/// </summary>
		/// <returns></returns>
		public void UpdateActiveTime()
		{
			Interlocked.Exchange(ref activeTime, DateTime.Now.Ticks);
		}
	}

	/// <summary>
	/// 同步锁
	/// </summary>
	private static ISyncLocker syncRoot = new ReadWriteLocker();

	/// <summary>
	/// 缓存
	/// </summary>
	private static Dictionary<RegexInfo, RegexInfo> cache = new Dictionary<RegexInfo, RegexInfo>(100);

	/// <summary>
	/// 缓存容器，默认100
	/// </summary>
	private static int capacity = 100;

	/// <summary>
	/// 获取同步对象
	/// </summary>
	public static ISyncLocker SyncRoot => syncRoot;

	/// <summary>
	/// 获取或者设置缓存容量
	/// </summary>
	public static int Capacity
	{
		get
		{
			return syncRoot.Read(() => capacity);
		}
		set
		{
			syncRoot.Write(delegate
			{
				if (value <= 0)
				{
					throw new ArgumentOutOfRangeException(Literals.MSG_RegexManagerCacheCapacityOutOfRange);
				}
				if (value < cache.Count)
				{
					RegexInfo[] array = cache.Keys.OfType<RegexInfo>().OrderBy().Take(cache.Count - value)
						.ToArray();
					RegexInfo[] array2 = array;
					foreach (RegexInfo key in array2)
					{
						cache.Remove(key);
					}
				}
				capacity = value;
			});
		}
	}

	/// <summary>
	/// 获取缓存的正则表达式容量
	/// </summary>
	public static int Count => syncRoot.Read(() => cache.Count);

	/// <summary>
	/// 获取具有指定正则表达式的正则对象，如果不存在则创建新的正则对象
	/// </summary>
	/// <param name="regex">正则表达式</param>
	/// <returns>正则表达式对象</returns>
	public static Regex GetOrAdd(string regex)
	{
		return GetOrAdd(regex, RegexOptions.None);
	}

	/// <summary>
	/// 获取具有指定正则表达式对象， 如果不存在则创建新的正则对象
	/// </summary>
	/// <param name="regex">正则表达式</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>正则表达式对象</returns>
	public static Regex GetOrAdd(string regex, RegexOptions options)
	{
		regex.GuardNotNull();
		return syncRoot.Read(delegate
		{
			RegexInfo info = new RegexInfo(regex, options);
			RegexInfo cachedInfo;
			return (cachedInfo = GetInfo(info)).IsNotNull() ? cachedInfo.GetRegex() : syncRoot.Write(delegate
			{
				if ((cachedInfo = GetInfo(info)).IsNotNull())
				{
					return cachedInfo.GetRegex();
				}
				return AddInfo(info) ? info.GetRegex() : null;
			});
		});
	}

	/// <summary>
	/// 从缓存中获取表达式对象信息，如果未缓存返回null
	/// </summary>
	/// <param name="info">正则表达式对象信息</param>
	/// <returns>缓存的正则表达式对象信息</returns>
	private static RegexInfo GetInfo(RegexInfo info)
	{
		if (cache.ContainsKey(info))
		{
			RegexInfo cacheInfo = cache[info];
			cacheInfo.UpdateActiveTime();
			if (cacheInfo.IncreaseActiveCount())
			{
				foreach (KeyValuePair<RegexInfo, RegexInfo> item in cache)
				{
					item.Value.ResetActiveCount();
				}
			}
			return cacheInfo;
		}
		return null;
	}

	/// <summary>
	/// 向缓存中添加正则表达式对象信息
	/// </summary>
	/// <param name="info">正则表达式信息</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	private static bool AddInfo(RegexInfo info)
	{
		if (cache.ContainsKey(info))
		{
			return false;
		}
		if (cache.Count >= capacity)
		{
			RegexInfo[] ris = cache.Keys.OfType<RegexInfo>().OrderBy().Take(cache.Count - capacity + 1)
				.ToArray();
			RegexInfo[] array = ris;
			foreach (RegexInfo ri in array)
			{
				cache.Remove(ri);
			}
		}
		info.CreateRegex();
		cache.Add(info, info);
		return true;
	}

	/// <summary>
	/// 从缓存中移除指定的正则表达式对象，并返回被移除的正则表达式对象，如果指定的对象不存在则返回null
	/// </summary>
	/// <param name="regex">待移除的正则表达式</param>
	/// <returns>被移除的正则表达式对象，如果不存在则返回null</returns>
	public static Regex Remove(string regex)
	{
		return Remove(regex, RegexOptions.None);
	}

	/// <summary>
	/// 从缓存中移除指定的正则表达式对象，并返回被移除的正则表达式对象，如果指定的对象不存在则返回null
	/// </summary>
	/// <param name="regex">待移除的正则表达式</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被移除的正则表达式对象，如果不存在则返回null</returns>
	public static Regex Remove(string regex, RegexOptions options)
	{
		regex.GuardNotNull();
		return syncRoot.Write(delegate
		{
			RegexInfo key = new RegexInfo(regex, options);
			if (cache.ContainsKey(key))
			{
				RegexInfo regexInfo = cache[key];
				cache.Remove(key);
				return regexInfo.GetRegex();
			}
			return null;
		});
	}

	/// <summary>
	/// 清空正则表达式缓存
	/// </summary>
	public static void Clear()
	{
		syncRoot.Write(delegate
		{
			cache.Clear();
		});
	}
}
