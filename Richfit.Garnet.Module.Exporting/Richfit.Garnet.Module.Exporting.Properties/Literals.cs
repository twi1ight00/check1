using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Richfit.Garnet.Module.Exporting.Properties;

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
				ResourceManager temp = new ResourceManager("Richfit.Garnet.Module.Exporting.Properties.Literals", typeof(Literals).Assembly);
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
	///   查找类似 DefaultManager 的本地化字符串。
	/// </summary>
	internal static string C_DefaultExportManagerConfigurationName => ResourceManager.GetString("C_DefaultExportManagerConfigurationName", resourceCulture);

	/// <summary>
	///   查找类似 The name of exporter is duplicate. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_DuplicateExporterName => ResourceManager.GetString("MSG_E_DuplicateExporterName", resourceCulture);

	/// <summary>
	///   查找类似 The name of manager is duplicate. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_DuplicateManagerName => ResourceManager.GetString("MSG_E_DuplicateManagerName", resourceCulture);

	/// <summary>
	///   查找类似 The exporter already exists. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_ExporterExists => ResourceManager.GetString("MSG_E_ExporterExists", resourceCulture);

	/// <summary>
	///   查找类似 The export manager is already initialized. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_ExportManagerInitialized => ResourceManager.GetString("MSG_E_ExportManagerInitialized", resourceCulture);

	/// <summary>
	///   查找类似 The export manager is not yet initialized. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_ExportManagerNotInitialized => ResourceManager.GetString("MSG_E_ExportManagerNotInitialized", resourceCulture);

	/// <summary>
	///   查找类似 Invalid exporter configuration. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_InvalidExporterConfiguration => ResourceManager.GetString("MSG_E_InvalidExporterConfiguration", resourceCulture);

	/// <summary>
	///   查找类似 Invalid exporter name. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_InvalidExporterName => ResourceManager.GetString("MSG_E_InvalidExporterName", resourceCulture);

	/// <summary>
	///   查找类似 Invalid manager configuration. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_InvalidManagerConfiguration => ResourceManager.GetString("MSG_E_InvalidManagerConfiguration", resourceCulture);

	/// <summary>
	///   查找类似 Invalid manager name. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_InvalidManagerName => ResourceManager.GetString("MSG_E_InvalidManagerName", resourceCulture);

	/// <summary>
	///   查找类似 No configuration for exporter. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_NoExporterConfiguration => ResourceManager.GetString("MSG_E_NoExporterConfiguration", resourceCulture);

	/// <summary>
	///   查找类似 No main configuration. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_NoMainConfiguration => ResourceManager.GetString("MSG_E_NoMainConfiguration", resourceCulture);

	/// <summary>
	///   查找类似 No manager configuration. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_NoManagerConfiguration => ResourceManager.GetString("MSG_E_NoManagerConfiguration", resourceCulture);

	/// <summary>
	///   查找类似 No package configuration. 的本地化字符串。
	/// </summary>
	internal static string MSG_E_NoPackageConfiguration => ResourceManager.GetString("MSG_E_NoPackageConfiguration", resourceCulture);

	internal Literals()
	{
	}
}
