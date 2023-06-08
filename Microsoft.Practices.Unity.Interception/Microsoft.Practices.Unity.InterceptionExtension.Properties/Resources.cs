using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Practices.Unity.InterceptionExtension.Properties;

/// <summary>
///   A strongly-typed resource class, for looking up localized strings, etc.
/// </summary>
[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
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
				ResourceManager resourceManager = new ResourceManager("Microsoft.Practices.Unity.InterceptionExtension.Properties.Resources", typeof(Resources).Assembly);
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
	///   Looks up a localized string similar to Intercepted abstract method was invoked..
	/// </summary>
	internal static string ExceptionAbstractMethodNotImplemented => ResourceManager.GetString("ExceptionAbstractMethodNotImplemented", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Additional interfaces do not have an implementation..
	/// </summary>
	internal static string ExceptionAdditionalInterfaceNotImplemented => ResourceManager.GetString("ExceptionAdditionalInterfaceNotImplemented", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The additional interfaces supplied are invalid: {0}.
	/// </summary>
	internal static string ExceptionAdditionalInterfacesInvalid => ResourceManager.GetString("ExceptionAdditionalInterfacesInvalid", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Type must be a subclass of System.Attribute..
	/// </summary>
	internal static string ExceptionAttributeNoSubclassOfAttribute => ResourceManager.GetString("ExceptionAttributeNoSubclassOfAttribute", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Could not create instance of type {0} with no constructor arguments..
	/// </summary>
	internal static string ExceptionCannotCreateInstance => ResourceManager.GetString("ExceptionCannotCreateInstance", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Cannot map generic type parameters on a generic type definition (an unbound generic type)..
	/// </summary>
	internal static string ExceptionCannotMapGenericTypeDefinition => ResourceManager.GetString("ExceptionCannotMapGenericTypeDefinition", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Collection contains a null element..
	/// </summary>
	internal static string ExceptionContainsNullElement => ResourceManager.GetString("ExceptionContainsNullElement", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The lengths of the mapped generic parameters do not match..
	/// </summary>
	internal static string ExceptionMappedParametersDoNotMatch => ResourceManager.GetString("ExceptionMappedParametersDoNotMatch", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The collection of interfaces is null..
	/// </summary>
	internal static string ExceptionNullInterfacesCollection => ResourceManager.GetString("ExceptionNullInterfacesCollection", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The required interfaces for behavior {1} are invalid: {0}.
	/// </summary>
	internal static string ExceptionRequiredInterfacesInvalid => ResourceManager.GetString("ExceptionRequiredInterfacesInvalid", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} is not an interface..
	/// </summary>
	internal static string ExceptionTypeIsNotInterface => ResourceManager.GetString("ExceptionTypeIsNotInterface", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Null type..
	/// </summary>
	internal static string ExceptionTypeIsNull => ResourceManager.GetString("ExceptionTypeIsNull", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} is an open generic..
	/// </summary>
	internal static string ExceptionTypeIsOpenGeneric => ResourceManager.GetString("ExceptionTypeIsOpenGeneric", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} is not interceptable..
	/// </summary>
	internal static string InterceptionNotSupported => ResourceManager.GetString("InterceptionNotSupported", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Could not find the implementation of interface method {0}.{1} in type {2}.
	/// </summary>
	internal static string InterfaceMethodNotImplemented => ResourceManager.GetString("InterfaceMethodNotImplemented", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Null is not permitted as an interception behavior..
	/// </summary>
	internal static string NullBehavior => ResourceManager.GetString("NullBehavior", resourceCulture);

	internal Resources()
	{
	}
}
