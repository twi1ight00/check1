using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Practices.ServiceLocation.Properties;

/// <summary>
///   A strongly-typed resource class, for looking up localized strings, etc.
/// </summary>
[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	/// <summary>
	///   Returns the cached ResourceManager instance used by this class.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceMan, null))
			{
				ResourceManager temp = new ResourceManager("Microsoft.Practices.ServiceLocation.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = temp;
			}
			return resourceMan;
		}
	}

	/// <summary>
	///   Overrides the current thread's CurrentUICulture property for all
	///   resource lookups using this strongly typed resource class.
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
	///   Looks up a localized string similar to Activation error occured while trying to get all instances of type {0}.
	/// </summary>
	internal static string ActivateAllExceptionMessage => ResourceManager.GetString("ActivateAllExceptionMessage", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Activation error occured while trying to get instance of type {0}, key "{1}".
	/// </summary>
	internal static string ActivationExceptionMessage => ResourceManager.GetString("ActivationExceptionMessage", resourceCulture);

	internal Resources()
	{
	}
}
