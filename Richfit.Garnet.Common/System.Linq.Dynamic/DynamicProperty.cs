namespace System.Linq.Dynamic;

/// <summary>
/// DynamicProperty
/// </summary>
public class DynamicProperty
{
	private string name;

	private Type type;

	/// <summary>
	/// Name
	/// </summary>
	public string Name => name;

	/// <summary>
	/// Name
	/// </summary>
	public Type Type => type;

	/// <summary>
	/// DynamicProperty
	/// </summary>
	/// <param name="name"></param>
	/// <param name="type"></param>
	public DynamicProperty(string name, Type type)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		this.name = name;
		this.type = type;
	}
}
