namespace ns305;

internal class Class7090
{
	private Class7089 class7089_0;

	public Class7090(Class7057 factory, string feature)
	{
		class7089_0 = new Class7089();
		class7089_0.Add(new Class7097(factory, feature));
	}

	public Class7097 method_0(string features)
	{
		foreach (Class7097 item in class7089_0)
		{
			if (item.imethod_1(features, string.Empty))
			{
				return item;
			}
		}
		return null;
	}

	public Class7089 method_1(string features)
	{
		Class7089 @class = new Class7089();
		foreach (Class7097 item in class7089_0)
		{
			if (item.imethod_1(features, string.Empty))
			{
				@class.Add(item);
			}
		}
		return @class;
	}

	public void Add(Class7097 implementation)
	{
		class7089_0.Add(implementation);
	}
}
