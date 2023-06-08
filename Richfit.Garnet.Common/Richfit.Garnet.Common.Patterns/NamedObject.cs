using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Patterns;

/// <summary>
/// 命名对象
/// </summary>
public class NamedObject
{
	/// <summary>
	/// 命名对象名称
	/// </summary>
	private string name;

	/// <summary>
	/// 命名对象实例
	/// </summary>
	private object item;

	/// <summary>
	/// 获取命名对象名称
	/// </summary>
	public string Name => name;

	/// <summary>
	/// 获取或者设置命名对象
	/// </summary>
	public object Item
	{
		get
		{
			return item;
		}
		set
		{
			item = value;
		}
	}

	/// <summary>
	/// 默认构造函数，禁用
	/// </summary>
	private NamedObject()
	{
	}

	/// <summary>
	/// 使用指定的命名对象初始初始化当前命名对象实例
	/// </summary>
	/// <param name="obj">用于初始化的命名对象</param>
	/// <exception cref="T:System.ArgumentNullException">用于初始化的命名对象为空。</exception>
	public NamedObject(NamedObject obj)
	{
		obj.GuardNotNull("named object");
		name = obj.name;
		item = obj.item;
	}

	/// <summary>
	/// 使用指定名称和对象实例初始化命名对象实例
	/// </summary>
	/// <param name="name">命名对象名称</param>
	/// <param name="item">命名对象实例</param>
	/// <exception cref="T:System.ArgumentNullException">命名值名称 <paramref name="name" /> 为空或者空串。</exception>
	public NamedObject(string name, object item)
	{
		name.GuardNotNullAndEmpty("name");
		this.name = name;
		this.item = item;
	}
}
/// <summary>
/// 命名对象
/// </summary>
/// <typeparam name="T">命名对象类型</typeparam>
public class NamedObject<T>
{
	/// <summary>
	/// 命名对象名称
	/// </summary>
	private string name;

	/// <summary>
	/// 命名对象实例
	/// </summary>
	private T item;

	/// <summary>
	/// 获取命名对象名称
	/// </summary>
	public string Name => name;

	/// <summary>
	/// 获取或者设置命名对象
	/// </summary>
	public T Item
	{
		get
		{
			return item;
		}
		set
		{
			item = value;
		}
	}

	/// <summary>
	/// 默认构造函数，禁用
	/// </summary>
	private NamedObject()
	{
	}

	/// <summary>
	/// 使用指定的命名对象初始初始化当前命名对象实例
	/// </summary>
	/// <param name="obj">用于初始化的命名对象</param>
	/// <exception cref="T:System.ArgumentNullException">用于初始化的命名对象为空。</exception>
	public NamedObject(NamedObject<T> obj)
	{
		obj.GuardNotNull("named object");
		name = obj.name;
		item = obj.item;
	}

	/// <summary>
	/// 使用指定名称和对象实例初始化命名对象实例
	/// </summary>
	/// <param name="name">命名对象名称</param>
	/// <param name="item">命名对象实例</param>
	/// <exception cref="T:System.ArgumentNullException">命名值名称 <paramref name="name" /> 为空或者空串。</exception>
	public NamedObject(string name, T item)
	{
		name.GuardNotNullAndEmpty("name");
		this.name = name;
		this.item = item;
	}
}
