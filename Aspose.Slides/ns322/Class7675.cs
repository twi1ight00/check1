namespace ns322;

internal class Class7675
{
	private object object_0;

	private Class7675 class7675_0;

	public object Data => object_0;

	public Class7675 Next
	{
		get
		{
			return class7675_0;
		}
		set
		{
			class7675_0 = value;
		}
	}

	public Class7675(object data, Class7675 next)
	{
		object_0 = data;
		class7675_0 = next;
	}

	public Class7675(object data)
		: this(data, null)
	{
	}
}
