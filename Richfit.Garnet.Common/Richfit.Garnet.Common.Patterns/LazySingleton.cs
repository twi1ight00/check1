using System;
using System.Reflection;

namespace Richfit.Garnet.Common.Patterns;

/// <summary>
/// 延迟加载单例类
/// </summary>
/// <typeparam name="T"></typeparam>
public class LazySingleton<T> where T : class
{
	/// <summary>
	/// 延迟加载对象
	/// </summary>
	private static readonly Lazy<T> LazyHandler = new Lazy<T>(delegate
	{
		if (instance == null)
		{
			lock (typeof(T))
			{
				if (instance == null)
				{
					ConstructorInfo constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);
					if (constructor == null || constructor.IsAssembly)
					{
						throw new Exception("Constructor is not private or protected for type " + typeof(T).Name);
					}
					instance = (T)constructor.Invoke(null);
				}
			}
		}
		return instance;
	});

	/// <summary>
	/// 静态单例
	/// </summary>
	private static T instance = null;

	/// <summary>
	/// Gets the instance of the singleton
	/// </summary>
	public static T Instance => LazyHandler.Value;

	/// <summary>
	/// Constructor
	/// </summary>
	protected LazySingleton()
	{
	}
}
