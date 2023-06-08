using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ns277;

[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[CompilerGenerated]
internal class Class6765
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceManager_0, null))
			{
				ResourceManager resourceManager = new ResourceManager("ns277.Class6765", typeof(Class6765).Assembly);
				resourceManager_0 = resourceManager;
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	internal static byte[] xhtml_lat1
	{
		get
		{
			object @object = ResourceManager.GetObject("xhtml_lat1", cultureInfo_0);
			return (byte[])@object;
		}
	}

	internal static byte[] xhtml_special
	{
		get
		{
			object @object = ResourceManager.GetObject("xhtml_special", cultureInfo_0);
			return (byte[])@object;
		}
	}

	internal static byte[] xhtml_symbol
	{
		get
		{
			object @object = ResourceManager.GetObject("xhtml_symbol", cultureInfo_0);
			return (byte[])@object;
		}
	}

	internal static string xhtml1_transitional => ResourceManager.GetString("xhtml1_transitional", cultureInfo_0);

	internal Class6765()
	{
	}
}
