using System;
using ns73;

namespace ns76;

internal class Class3723 : Interface65
{
	private Interface104 interface104_0;

	private Class4340 class4340_0;

	public virtual string DefaultFontFamily
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public Interface104 ResourceLoading => interface104_0;

	public string Language
	{
		get
		{
			return class4340_0.ContentLanguage;
		}
		set
		{
			class4340_0.ContentLanguage = value;
		}
	}

	public Class4340 Settings => class4340_0;

	public Class3723(Interface104 resourceLoading, Class4340 settings)
		: this(resourceLoading)
	{
		class4340_0 = settings;
	}

	public Class3723(Interface104 resourceLoading)
	{
		interface104_0 = resourceLoading;
	}
}
