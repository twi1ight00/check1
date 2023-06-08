namespace Richfit.Garnet.Common.Patterns;

/// <summary>
/// 命名值
/// </summary>
public struct NamedValue
{
	/// <summary>
	/// 命名对象名称
	/// </summary>
	private string name;

	/// <summary>
	/// 命名对象实例
	/// </summary>
	private object value;

	/// <summary>
	/// 获取命名对象名称
	/// </summary>
	public string Name => name;

	/// <summary>
	/// 获取或者设置命名对象
	/// </summary>
	public object Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	/// <summary>
	/// 使用指定的命名值初始初始化当前命名值
	/// </summary>
	/// <param name="obj">用于初始化的命名值</param>
	public NamedValue(NamedValue obj)
	{
		name = obj.name;
		value = obj.value;
	}

	/// <summary>
	/// 使用指定名称和值初始化命名值
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="value">命名值</param>
	/// <exception cref="T:System.ArgumentNullException">命名值名称 <paramref name="name" /> 为空或者空串。</exception>
	public NamedValue(string name, object value)
	{
		this.name = name;
		this.value = value;
	}
}
/// <summary>
/// 命名值
/// </summary>
/// <typeparam name="T">命名值类型</typeparam>
public struct NamedValue<T>
{
	/// <summary>
	/// 命名对象名称
	/// </summary>
	private string name;

	/// <summary>
	/// 命名对象实例
	/// </summary>
	private T value;

	/// <summary>
	/// 获取命名对象名称
	/// </summary>
	public string Name => name;

	/// <summary>
	/// 获取或者设置命名对象
	/// </summary>
	public T Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	/// <summary>
	/// 使用指定的命名值初始初始化当前命名值
	/// </summary>
	/// <param name="obj">用于初始化的命名值</param>
	public NamedValue(NamedValue<T> obj)
	{
		name = obj.name;
		value = obj.value;
	}

	/// <summary>
	/// 使用指定名称和值初始化命名值
	/// </summary>
	/// <param name="name">命名值名称</param>
	/// <param name="value">命名值</param>
	/// <exception cref="T:System.ArgumentNullException">命名值名称 <paramref name="name" /> 为空或者空串。</exception>
	public NamedValue(string name, T value)
	{
		this.name = name;
		this.value = value;
	}
}
