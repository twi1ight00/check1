using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration.Properties;

/// <summary>
///   A strongly-typed resource class, for looking up localized strings, etc.
/// </summary>
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
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
				ResourceManager resourceManager = new ResourceManager("Microsoft.Practices.Unity.InterceptionExtension.Configuration.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
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
	///   Looks up a localized string similar to The abstract type InterceptorRegistrationElement cannot be created. Please create a concrete instance..
	/// </summary>
	internal static string CannotCreateInterceptorRegistrationElement => ResourceManager.GetString("CannotCreateInterceptorRegistrationElement", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The &lt;injection/&gt; element is not allowed on element named '{0}' because it doesn't have a type attribute..
	/// </summary>
	internal static string CannotHaveInjectionWithoutTypeName => ResourceManager.GetString("CannotHaveInjectionWithoutTypeName", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The &lt;lifetime/&gt; element is not allowed on element named '{0}' because it doesn't have a type attribute..
	/// </summary>
	internal static string CannotHaveLifetimeWithoutTypeName => ResourceManager.GetString("CannotHaveLifetimeWithoutTypeName", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type name or alias {0} could not be resolved. Please check your configuration file and verify this type name..
	/// </summary>
	internal static string CouldNotResolveType => ResourceManager.GetString("CouldNotResolveType", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Cannot create instance of type {0} with a default constructor..
	/// </summary>
	internal static string ExceptionCannotCreateInstance => ResourceManager.GetString("ExceptionCannotCreateInstance", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type name {0} resolved to type {1} is not compatible with the required type {2}..
	/// </summary>
	internal static string ExceptionResolvedTypeNotCompatible => ResourceManager.GetString("ExceptionResolvedTypeNotCompatible", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} could not be resolved to a valid type. Please double check your configuration..
	/// </summary>
	internal static string InvalidInterceptorType => ResourceManager.GetString("InvalidInterceptorType", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The interception behavior element must have at least one of the 'name' or 'type' attributes..
	/// </summary>
	internal static string MustHaveAtLeastOneBehaviorAttribute => ResourceManager.GetString("MustHaveAtLeastOneBehaviorAttribute", resourceCulture);

	internal Resources()
	{
	}
}
