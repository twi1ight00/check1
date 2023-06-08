using System;
using System.Reflection;

namespace Richfit.Garnet.Common.Patterns;

/// <summary>
/// 单例模式对象基础类
/// </summary>
/// <typeparam name="T">单例对象类型</typeparam>
public class Singleton<T> where T : class
{
	/// <summary>
	/// 单例模式对象实例
	/// </summary>
	private static T instance = null;

	/// <summary>
	/// Gets the instance of the singleton
	/// </summary>
	public static T Instance
	{
		get
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
		}
	}

	/// <summary>
	/// 初始化单例基础类
	/// </summary>
	protected Singleton()
	{
	}
}
