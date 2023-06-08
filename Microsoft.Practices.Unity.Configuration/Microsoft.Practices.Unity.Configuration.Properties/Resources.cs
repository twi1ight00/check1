using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Practices.Unity.Configuration.Properties;

/// <summary>
///   A strongly-typed resource class, for looking up localized strings, etc.
/// </summary>
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
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
				ResourceManager resourceManager = new ResourceManager("Microsoft.Practices.Unity.Configuration.Properties.Resources", typeof(Resources).Assembly);
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
	///   Looks up a localized string similar to An abstract ContainerConfiguringElement cannot be created. Please specify a concrete type..
	/// </summary>
	internal static string CannotCreateContainerConfiguringElement => ResourceManager.GetString("CannotCreateContainerConfiguringElement", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to An abstract ExtensionConfigurationElement object cannot be created. Please specify a concrete type..
	/// </summary>
	internal static string CannotCreateExtensionConfigurationElement => ResourceManager.GetString("CannotCreateExtensionConfigurationElement", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to An abstract InjectionMemberElement object cannot be created. Please specify a concrete type..
	/// </summary>
	internal static string CannotCreateInjectionMemberElement => ResourceManager.GetString("CannotCreateInjectionMemberElement", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to An abstract ParameterValueElement object cannot be created. Please specify a concrete type..
	/// </summary>
	internal static string CannotCreateParameterValueElement => ResourceManager.GetString("CannotCreateParameterValueElement", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type name or alias {0} could not be resolved. Please check your configuration file and verify this type name..
	/// </summary>
	internal static string CouldNotResolveType => ResourceManager.GetString("CouldNotResolveType", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The dependency element for generic parameter {0} must not have an explicit type name but has '{1}'..
	/// </summary>
	internal static string DependencyForGenericParameterWithTypeSet => ResourceManager.GetString("DependencyForGenericParameterWithTypeSet", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The optional dependency element for generic parameter {0} must not have an explicit type name but has '{1}'..
	/// </summary>
	internal static string DependencyForOptionalGenericParameterWithTypeSet => ResourceManager.GetString("DependencyForOptionalGenericParameterWithTypeSet", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to {0} {1}.
	/// </summary>
	internal static string DestinationNameFormat => ResourceManager.GetString("DestinationNameFormat", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The injection configuration for {0} has multiple values..
	/// </summary>
	internal static string DuplicateParameterValueElement => ResourceManager.GetString("DuplicateParameterValueElement", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The configuration element type {0} has not been registered with the section..
	/// </summary>
	internal static string ElementTypeNotRegistered => ResourceManager.GetString("ElementTypeNotRegistered", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The injection configuration for {0} is specified through both attributes and child value elements..
	/// </summary>
	internal static string ElementWithAttributesAndParameterValueElements => ResourceManager.GetString("ElementWithAttributesAndParameterValueElements", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Could not load section extension type {0}..
	/// </summary>
	internal static string ExtensionTypeNotFound => ResourceManager.GetString("ExtensionTypeNotFound", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The extension type {0} does not derive from SectionExtension..
	/// </summary>
	internal static string ExtensionTypeNotValid => ResourceManager.GetString("ExtensionTypeNotValid", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The extension element type {0} that is being added does not derive from ContainerConfiguringElement, InjectionMemberElement, or ParameterValueElement. An extension element must derive from one of these types..
	/// </summary>
	internal static string InvalidExtensionElementType => ResourceManager.GetString("InvalidExtensionElementType", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to No valid attributes were found to construct the value for the {0}. Please check the configuration file..
	/// </summary>
	internal static string InvalidValueAttributes => ResourceManager.GetString("InvalidValueAttributes", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Configuration is incorrect, the type {0} does not have a constructor that takes parameters named {1}..
	/// </summary>
	internal static string NoMatchingConstructor => ResourceManager.GetString("NoMatchingConstructor", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Configuration is incorrect, the type {0} does not have a method named {1} that takes parameters named {2}..
	/// </summary>
	internal static string NoMatchingMethod => ResourceManager.GetString("NoMatchingMethod", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The container named "{0}" is not defined in this configuration section..
	/// </summary>
	internal static string NoSuchContainer => ResourceManager.GetString("NoSuchContainer", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} does not have a property named {1}..
	/// </summary>
	internal static string NoSuchProperty => ResourceManager.GetString("NoSuchProperty", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The configuration is set to inject an array, but the type {0} is not an array type..
	/// </summary>
	internal static string NotAnArray => ResourceManager.GetString("NotAnArray", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to parameter.
	/// </summary>
	internal static string Parameter => ResourceManager.GetString("Parameter", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to property.
	/// </summary>
	internal static string Property => ResourceManager.GetString("Property", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The attribute {0} must be present and non-empty..
	/// </summary>
	internal static string RequiredPropertyMissing => ResourceManager.GetString("RequiredPropertyMissing", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The value element for {1} was specified for the generic array type {0}. Value elements are not allowed for generic array types..
	/// </summary>
	internal static string ValueNotAllowedForGenericArrayType => ResourceManager.GetString("ValueNotAllowedForGenericArrayType", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The value element for {1} was specified for the generic parameter type {0}. Value elements are not allowed for generic parameter types..
	/// </summary>
	internal static string ValueNotAllowedForGenericParameterType => ResourceManager.GetString("ValueNotAllowedForGenericParameterType", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The value element for {1} was specified for the generic type {0}. Value elements are not allowed for generic types..
	/// </summary>
	internal static string ValueNotAllowedForOpenGenericType => ResourceManager.GetString("ValueNotAllowedForOpenGenericType", resourceCulture);

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
	internal Resources()
	{
	}
}
