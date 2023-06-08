using System;
using System.Collections;
using System.Collections.Specialized;

namespace Common.Logging.Factory;

/// <summary>
/// An implementation of <see cref="T:Common.Logging.ILoggerFactoryAdapter" /> that caches loggers handed out by this factory.
/// </summary>
/// <remarks>
/// Implementors just need to override <see cref="M:Common.Logging.Factory.AbstractCachingLoggerFactoryAdapter.CreateLogger(System.String)" />.
/// </remarks>
/// <author>Erich Eichinger</author>
public abstract class AbstractCachingLoggerFactoryAdapter : ILoggerFactoryAdapter
{
	private readonly Hashtable _cachedLoggers;

	/// <summary>
	/// Creates a new instance, the logger cache being case-sensitive.
	/// </summary>
	protected AbstractCachingLoggerFactoryAdapter()
		: this(caseSensitiveLoggerCache: true)
	{
	}

	/// <summary>
	/// Creates a new instance, the logger cache being <paramref name="caseSensitiveLoggerCache" />.
	/// </summary>
	/// <param name="caseSensitiveLoggerCache"></param>
	protected AbstractCachingLoggerFactoryAdapter(bool caseSensitiveLoggerCache)
	{
		_cachedLoggers = (caseSensitiveLoggerCache ? new Hashtable() : CollectionsUtil.CreateCaseInsensitiveHashtable());
	}

	/// <summary>
	/// Purges all loggers from cache
	/// </summary>
	protected void ClearLoggerCache()
	{
		lock (_cachedLoggers)
		{
			_cachedLoggers.Clear();
		}
	}

	/// <summary>
	/// Create the specified named logger instance
	/// </summary>
	/// <remarks>
	/// Derived factories need to implement this method to create the
	/// actual logger instance.
	/// </remarks>
	protected abstract ILog CreateLogger(string name);

	/// <summary>
	/// Get a ILog instance by <see cref="T:System.Type" />.
	/// </summary>
	/// <param name="type">Usually the <see cref="T:System.Type" /> of the current class.</param>
	/// <returns>
	/// An ILog instance either obtained from the internal cache or created by a call to <see cref="M:Common.Logging.Factory.AbstractCachingLoggerFactoryAdapter.CreateLogger(System.String)" />.
	/// </returns>
	public ILog GetLogger(Type type)
	{
		return GetLoggerInternal(type.FullName);
	}

	/// <summary>
	/// Get a ILog instance by name.
	/// </summary>
	/// <param name="name">Usually a <see cref="T:System.Type" />'s Name or FullName property.</param>
	/// <returns>
	/// An ILog instance either obtained from the internal cache or created by a call to <see cref="M:Common.Logging.Factory.AbstractCachingLoggerFactoryAdapter.CreateLogger(System.String)" />.
	/// </returns>
	public ILog GetLogger(string name)
	{
		return GetLoggerInternal(name);
	}

	/// <summary>
	/// Get or create a ILog instance by name.
	/// </summary>
	/// <param name="name">Usually a <see cref="T:System.Type" />'s Name or FullName property.</param>
	/// <returns>
	/// An ILog instance either obtained from the internal cache or created by a call to <see cref="M:Common.Logging.Factory.AbstractCachingLoggerFactoryAdapter.CreateLogger(System.String)" />.
	/// </returns>
	private ILog GetLoggerInternal(string name)
	{
		ILog log = _cachedLoggers[name] as ILog;
		if (log == null)
		{
			lock (_cachedLoggers)
			{
				log = _cachedLoggers[name] as ILog;
				if (log == null)
				{
					log = CreateLogger(name);
					if (log == null)
					{
						throw new ArgumentException($"{GetType().FullName} returned null on creating logger instance for name {name}");
					}
					_cachedLoggers.Add(name, log);
				}
			}
		}
		return log;
	}
}
