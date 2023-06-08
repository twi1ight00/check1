using System;

namespace ns67;

internal sealed class Class3068
{
	private Class3434 class3434_0;

	private Class3448 class3448_0;

	private uint uint_0;

	internal Class3434 Attributes
	{
		get
		{
			return class3434_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class3434_0 = value;
		}
	}

	internal Class3448 Transform
	{
		get
		{
			return class3448_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class3448_0 = value;
		}
	}

	internal uint TextureId
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	internal Class3068(Class3434 attributes, Class3448 transform, uint textureId)
	{
		Attributes = attributes;
		Transform = transform;
		TextureId = textureId;
	}

	internal Class3068 method_0()
	{
		return new Class3068(class3434_0.method_0(), class3448_0.method_0(), uint_0);
	}
}
