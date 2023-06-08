using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Richfit.Garnet.Common.Configuration.Properties;

/// <summary>
///   一个强类型的资源类，用于查找本地化的字符串等。
/// </summary>
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Literals
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	/// <summary>
	///   返回此类使用的缓存的 ResourceManager 实例。
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceMan, null))
			{
				ResourceManager temp = new ResourceManager("Richfit.Garnet.Common.Configuration.Properties.Literals", typeof(Literals).Assembly);
				resourceMan = temp;
			}
			return resourceMan;
		}
	}

	/// <summary>
	///   使用此强类型资源类，为所有资源查找
	///   重写当前线程的 CurrentUICulture 属性。
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	/// <summary>
	///   查找类似 Invalid configuration. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_InvalidConfiguration => ResourceManager.GetString("MSG_E_InvalidConfiguration", resourceCulture);

	/// <summary>
	///   查找类似 Invalid configuration name. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_InvalidConfigurationViewName => ResourceManager.GetString("MSG_E_InvalidConfigurationViewName", resourceCulture);

	internal Literals()
	{
	}
}
