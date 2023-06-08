using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Richfit.Garnet.Module.Importing.Properties;

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
				ResourceManager temp = new ResourceManager("Richfit.Garnet.Module.Importing.Properties.Literals", typeof(Literals).Assembly);
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
	///   查找类似 The importer named '{0}' is duplicate in configuration. 的本地化字符串。
	/// </summary>
	internal static string M_E_Importer_Configuration_Duplication => ResourceManager.GetString("M_E_Importer_Configuration_Duplication", resourceCulture);

	/// <summary>
	///   查找类似 The configuration of current importer is invalid. 的本地化字符串。
	/// </summary>
	internal static string M_E_Importer_Configuration_Invalid => ResourceManager.GetString("M_E_Importer_Configuration_Invalid", resourceCulture);

	/// <summary>
	///   查找类似 The importer configuration is missing. 的本地化字符串。
	/// </summary>
	internal static string M_E_Importer_Configuration_Missing => ResourceManager.GetString("M_E_Importer_Configuration_Missing", resourceCulture);

	/// <summary>
	///   查找类似 The name of importer is invalid. 的本地化字符串。
	/// </summary>
	internal static string M_E_Importer_InvalidName => ResourceManager.GetString("M_E_Importer_InvalidName", resourceCulture);

	/// <summary>
	///   查找类似 The attribute '{0}' of element '{1}' is missing. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportManager_Configuration_AttributeMissing => ResourceManager.GetString("M_E_ImportManager_Configuration_AttributeMissing", resourceCulture);

	/// <summary>
	///   查找类似 The import manager named '{0}' is duplicate in configuration. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportManager_Configuration_Duplication => ResourceManager.GetString("M_E_ImportManager_Configuration_Duplication", resourceCulture);

	/// <summary>
	///   查找类似 Invalid manager configuration. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportManager_Configuration_Invalid => ResourceManager.GetString("M_E_ImportManager_Configuration_Invalid", resourceCulture);

	/// <summary>
	///   查找类似 The element '{0}' in "{1} is unrecognizable. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportManager_Configuration_Unrecognizable => ResourceManager.GetString("M_E_ImportManager_Configuration_Unrecognizable", resourceCulture);

	/// <summary>
	///   查找类似 The import manager is already initialized. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportManager_Initialized => ResourceManager.GetString("M_E_ImportManager_Initialized", resourceCulture);

	/// <summary>
	///   查找类似 Invalid manager name. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportManager_InvalidName => ResourceManager.GetString("M_E_ImportManager_InvalidName", resourceCulture);

	/// <summary>
	///   查找类似 No main configuration. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportManager_NoMainConfiguration => ResourceManager.GetString("M_E_ImportManager_NoMainConfiguration", resourceCulture);

	/// <summary>
	///   查找类似 No package configuration. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportManager_NoPackageConfiguration => ResourceManager.GetString("M_E_ImportManager_NoPackageConfiguration", resourceCulture);

	/// <summary>
	///   查找类似 The import manager is not yet initialized. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportManager_NotInitialized => ResourceManager.GetString("M_E_ImportManager_NotInitialized", resourceCulture);

	/// <summary>
	///   查找类似 DefaultManager 的本地化字符串。
	/// </summary>
	internal static string T_ImportManager_Configuration_DefaultName => ResourceManager.GetString("T_ImportManager_Configuration_DefaultName", resourceCulture);

	internal Literals()
	{
	}
}
