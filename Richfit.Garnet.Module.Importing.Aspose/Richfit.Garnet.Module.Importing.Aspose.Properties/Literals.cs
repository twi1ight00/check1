using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Richfit.Garnet.Module.Importing.Aspose.Properties;

/// <summary>
///   一个强类型的资源类，用于查找本地化的字符串等。
/// </summary>
[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
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
				ResourceManager temp = new ResourceManager("Richfit.Garnet.Module.Importing.Aspose.Properties.Literals", typeof(Literals).Assembly);
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
	///   查找类似 The data column '{1}' in the sheet '{0}' is duplicate. 的本地化字符串。
	/// </summary>
	internal static string M_E_ImportData_ColumnDuplicate => ResourceManager.GetString("M_E_ImportData_ColumnDuplicate", resourceCulture);

	/// <summary>
	///   查找类似 没有找到需要导入的数据。 的本地化字符串。
	/// </summary>
	internal static string M_E_Importing_NoTemplate => ResourceManager.GetString("M_E_Importing_NoTemplate", resourceCulture);

	/// <summary>
	///   查找类似 Excel数据表"{0}"的第{1}行的数据解析失败，错误原因是： {2} 的本地化字符串。
	/// </summary>
	internal static string M_E_Importing_RecordResolveError => ResourceManager.GetString("M_E_Importing_RecordResolveError", resourceCulture);

	/// <summary>
	///   查找类似 Excel数据表"{0}"的第{1}行的数据验证失败，错误原因是： {2} 的本地化字符串。
	/// </summary>
	internal static string M_E_Importing_RecordValidateError => ResourceManager.GetString("M_E_Importing_RecordValidateError", resourceCulture);

	/// <summary>
	///   查找类似 不能把数据项目"{0}"的值"{1}"，转换为类型"{2}"。 的本地化字符串。
	/// </summary>
	internal static string M_E_Importing_ValueConvertError => ResourceManager.GetString("M_E_Importing_ValueConvertError", resourceCulture);

	/// <summary>
	///   查找类似 解析数据项目"{0}"的值"{1}"失败，错误原因是：{2} 的本地化字符串。
	/// </summary>
	internal static string M_E_Importing_ValueResolveError => ResourceManager.GetString("M_E_Importing_ValueResolveError", resourceCulture);

	/// <summary>
	///   查找类似 数据项目"{0}"的值"{1}"验证失败，错误原因是：{2} 的本地化字符串。
	/// </summary>
	internal static string M_E_Importing_ValueValidateError => ResourceManager.GetString("M_E_Importing_ValueValidateError", resourceCulture);

	/// <summary>
	///   查找类似 数据项目"{0}"的值"{1}"与指定的正则模式"{2}"不匹配。 的本地化字符串。
	/// </summary>
	internal static string M_E_Importing_ValueValidatePatternUnmatch => ResourceManager.GetString("M_E_Importing_ValueValidatePatternUnmatch", resourceCulture);

	/// <summary>
	///   查找类似 The template '{0}({1})' is duplicate. 的本地化字符串。
	/// </summary>
	internal static string M_E_Template_Duplicate => ResourceManager.GetString("M_E_Template_Duplicate", resourceCulture);

	/// <summary>
	///   查找类似 The template '{0}' property '{1}' is error. 的本地化字符串。
	/// </summary>
	internal static string M_E_Template_PropertyError => ResourceManager.GetString("M_E_Template_PropertyError", resourceCulture);

	/// <summary>
	///   查找类似 The template '{0}' property '{1}' is missing. 的本地化字符串。
	/// </summary>
	internal static string M_E_Template_PropertyMissing => ResourceManager.GetString("M_E_Template_PropertyMissing", resourceCulture);

	/// <summary>
	///   查找类似 Can't create template mapping type. 的本地化字符串。
	/// </summary>
	internal static string M_E_Template_TypeError => ResourceManager.GetString("M_E_Template_TypeError", resourceCulture);

	/// <summary>
	///   查找类似 The template item '{0}({1})' is duplicate. 的本地化字符串。
	/// </summary>
	internal static string M_E_TemplateItem_Duplicate => ResourceManager.GetString("M_E_TemplateItem_Duplicate", resourceCulture);

	/// <summary>
	///   查找类似 The template item '{0}' property '{1}' is error. 的本地化字符串。
	/// </summary>
	internal static string M_E_TemplateItem_PropertyError => ResourceManager.GetString("M_E_TemplateItem_PropertyError", resourceCulture);

	/// <summary>
	///   查找类似 The template item '{0}' property '{1}' is missing. 的本地化字符串。
	/// </summary>
	internal static string M_E_TemplateItem_PropertyMissing => ResourceManager.GetString("M_E_TemplateItem_PropertyMissing", resourceCulture);

	/// <summary>
	///   查找类似 Can't resolve the type of template item '{0}'. 的本地化字符串。
	/// </summary>
	internal static string M_E_TemplateItem_TypeError => ResourceManager.GetString("M_E_TemplateItem_TypeError", resourceCulture);

	internal Literals()
	{
	}
}
