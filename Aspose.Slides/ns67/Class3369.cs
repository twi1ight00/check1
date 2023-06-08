using System;

namespace ns67;

internal sealed class Class3369 : ICloneable
{
	private string string_0;

	private Class3344 class3344_0;

	public string PictureReference
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class3344 PictureEffect
	{
		get
		{
			return class3344_0;
		}
		set
		{
			if (class3344_0 != value)
			{
				class3344_0 = value?.vmethod_0();
			}
		}
	}

	public Class3369(string pictureReference)
	{
		if (pictureReference == null)
		{
			throw new ArgumentNullException("pictureReference");
		}
		string_0 = pictureReference;
	}

	public object Clone()
	{
		return method_0();
	}

	public Class3369 method_0()
	{
		return new Class3369(this);
	}

	private Class3369(Class3369 src)
	{
		if (src == null)
		{
			throw new ArgumentNullException("src");
		}
		PictureEffect = src.PictureEffect;
		string_0 = src.PictureReference;
	}
}
