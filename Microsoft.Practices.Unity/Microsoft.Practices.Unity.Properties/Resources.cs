using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Practices.Unity.Properties;

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
				ResourceManager resourceManager = new ResourceManager("Microsoft.Practices.Unity.Properties.Resources", typeof(Resources).Assembly);
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
	///   Looks up a localized string similar to The type {0} has multiple constructors of length {1}. Unable to disambiguate..
	/// </summary>
	internal static string AmbiguousInjectionConstructor => ResourceManager.GetString("AmbiguousInjectionConstructor", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The provided string argument must not be empty..
	/// </summary>
	internal static string ArgumentMustNotBeEmpty => ResourceManager.GetString("ArgumentMustNotBeEmpty", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The current build operation (build key {2}) failed: {3} (Strategy type {0}, index {1}).
	/// </summary>
	internal static string BuildFailedException => ResourceManager.GetString("BuildFailedException", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The current type, {0}, is an interface and cannot be constructed. Are you missing a type mapping?.
	/// </summary>
	internal static string CannotConstructInterface => ResourceManager.GetString("CannotConstructInterface", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Cannot extract type from build key {0}..
	/// </summary>
	internal static string CannotExtractTypeFromBuildKey => ResourceManager.GetString("CannotExtractTypeFromBuildKey", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The method {0}.{1}({2}) is an open generic method. Open generic methods cannot be injected..
	/// </summary>
	internal static string CannotInjectGenericMethod => ResourceManager.GetString("CannotInjectGenericMethod", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The property {0} on type {1} is an indexer. Indexed properties cannot be injected..
	/// </summary>
	internal static string CannotInjectIndexer => ResourceManager.GetString("CannotInjectIndexer", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The method {1} on type {0} has an out parameter. Injection cannot be performed..
	/// </summary>
	internal static string CannotInjectMethodWithOutParam => ResourceManager.GetString("CannotInjectMethodWithOutParam", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The method {0}.{1}({2}) has at least one out parameter. Methods with out parameters cannot be injected..
	/// </summary>
	internal static string CannotInjectMethodWithOutParams => ResourceManager.GetString("CannotInjectMethodWithOutParams", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The method {0}.{1}({2}) has at least one ref parameter.Methods with ref parameters cannot be injected..
	/// </summary>
	internal static string CannotInjectMethodWithRefParams => ResourceManager.GetString("CannotInjectMethodWithRefParams", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The method {1} on type {0} is marked for injection, but it is an open generic method. Injection cannot be performed..
	/// </summary>
	internal static string CannotInjectOpenGenericMethod => ResourceManager.GetString("CannotInjectOpenGenericMethod", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The method {0}.{1}({2}) is static. Static methods cannot be injected..
	/// </summary>
	internal static string CannotInjectStaticMethod => ResourceManager.GetString("CannotInjectStaticMethod", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} is an open generic type. An open generic type cannot be resolved..
	/// </summary>
	internal static string CannotResolveOpenGenericType => ResourceManager.GetString("CannotResolveOpenGenericType", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Resolving parameter "{0}" of constructor {1}.
	/// </summary>
	internal static string ConstructorArgumentResolveOperation => ResourceManager.GetString("ConstructorArgumentResolveOperation", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The parameter {0} could not be resolved when attempting to call constructor {1}..
	/// </summary>
	internal static string ConstructorParameterResolutionFailed => ResourceManager.GetString("ConstructorParameterResolutionFailed", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Parameter type inference does not work for null values. Indicate the parameter type explicitly using a properly configured instance of the InjectionParameter or InjectionParameter&lt;T&gt; classes..
	/// </summary>
	internal static string ExceptionNullParameterValue => ResourceManager.GetString("ExceptionNullParameterValue", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Calling constructor {0}.
	/// </summary>
	internal static string InvokingConstructorOperation => ResourceManager.GetString("InvokingConstructorOperation", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Calling method {0}.{1}.
	/// </summary>
	internal static string InvokingMethodOperation => ResourceManager.GetString("InvokingMethodOperation", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to An item with the given key is already present in the dictionary..
	/// </summary>
	internal static string KeyAlreadyPresent => ResourceManager.GetString("KeyAlreadyPresent", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The lifetime manager is already registered. Lifetime managers cannot be reused, please create a new one..
	/// </summary>
	internal static string LifetimeManagerInUse => ResourceManager.GetString("LifetimeManagerInUse", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The override marker build plan policy has been invoked. This should never happen, looks like a bug in the container..
	/// </summary>
	internal static string MarkerBuildPlanInvoked => ResourceManager.GetString("MarkerBuildPlanInvoked", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Resolving parameter "{0}" of method {1}.{2}.
	/// </summary>
	internal static string MethodArgumentResolveOperation => ResourceManager.GetString("MethodArgumentResolveOperation", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The value for parameter "{1}" of method {0} could not be resolved. .
	/// </summary>
	internal static string MethodParameterResolutionFailed => ResourceManager.GetString("MethodParameterResolutionFailed", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Could not resolve dependency for build key {0}..
	/// </summary>
	internal static string MissingDependency => ResourceManager.GetString("MissingDependency", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} has multiple constructors marked with the InjectionConstructor attribute. Unable to disambiguate..
	/// </summary>
	internal static string MultipleInjectionConstructors => ResourceManager.GetString("MultipleInjectionConstructors", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The supplied type {0} must be an open generic type..
	/// </summary>
	internal static string MustHaveOpenGenericType => ResourceManager.GetString("MustHaveOpenGenericType", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The supplied type {0} does not have the same number of generic arguments as the target type {1}..
	/// </summary>
	internal static string MustHaveSameNumberOfGenericArguments => ResourceManager.GetString("MustHaveSameNumberOfGenericArguments", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} does not have an accessible constructor..
	/// </summary>
	internal static string NoConstructorFound => ResourceManager.GetString("NoConstructorFound", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} does not have a generic argument named "{1}".
	/// </summary>
	internal static string NoMatchingGenericArgument => ResourceManager.GetString("NoMatchingGenericArgument", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to while resolving.
	/// </summary>
	internal static string NoOperationExceptionReason => ResourceManager.GetString("NoOperationExceptionReason", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} does not have a constructor that takes the parameters ({1})..
	/// </summary>
	internal static string NoSuchConstructor => ResourceManager.GetString("NoSuchConstructor", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} does not have a public method named {1} that takes the parameters ({2})..
	/// </summary>
	internal static string NoSuchMethod => ResourceManager.GetString("NoSuchMethod", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} does not contain an instance property named {1}..
	/// </summary>
	internal static string NoSuchProperty => ResourceManager.GetString("NoSuchProperty", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} is not a generic type, and you are attempting to inject a generic parameter named "{1}"..
	/// </summary>
	internal static string NotAGenericType => ResourceManager.GetString("NotAGenericType", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} is not an array type with rank 1, and you are attempting to use a [DependencyArray] attribute on a parameter or property with this type..
	/// </summary>
	internal static string NotAnArrayTypeWithRankOne => ResourceManager.GetString("NotAnArrayTypeWithRankOne", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Optional dependencies must be reference types. The type {0} is a value type..
	/// </summary>
	internal static string OptionalDependenciesMustBeReferenceTypes => ResourceManager.GetString("OptionalDependenciesMustBeReferenceTypes", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The property {0} on type {1} is not settable..
	/// </summary>
	internal static string PropertyNotSettable => ResourceManager.GetString("PropertyNotSettable", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The property {0} on type {1} is of type {2}, and cannot be injected with a value of type {3}..
	/// </summary>
	internal static string PropertyTypeMismatch => ResourceManager.GetString("PropertyTypeMismatch", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The value for the property "{0}" could not be resolved..
	/// </summary>
	internal static string PropertyValueResolutionFailed => ResourceManager.GetString("PropertyValueResolutionFailed", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The provided string argument must not be empty..
	/// </summary>
	internal static string ProvidedStringArgMustNotBeEmpty => ResourceManager.GetString("ProvidedStringArgMustNotBeEmpty", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Resolution of the dependency failed, type = "{0}", name = "{1}".
	///             Exception occurred while: {2}.
	///             Exception is: {3} - {4}
	///             -----------------------------------------------
	///             At the time of the exception, the container was:
	///             .
	/// </summary>
	internal static string ResolutionFailed => ResourceManager.GetString("ResolutionFailed", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Resolving {0},{1}.
	/// </summary>
	internal static string ResolutionTraceDetail => ResourceManager.GetString("ResolutionTraceDetail", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Resolving {0},{1} (mapped from {2}, {3}).
	/// </summary>
	internal static string ResolutionWithMappingTraceDetail => ResourceManager.GetString("ResolutionWithMappingTraceDetail", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Resolving value for property {0}.{1}.
	/// </summary>
	internal static string ResolvingPropertyValueOperation => ResourceManager.GetString("ResolvingPropertyValueOperation", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The constructor {1} selected for type {0} has ref or out parameters. Such parameters are not supported for constructor injection..
	/// </summary>
	internal static string SelectedConstructorHasRefParameters => ResourceManager.GetString("SelectedConstructorHasRefParameters", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to Setting value for property {0}.{1}.
	/// </summary>
	internal static string SettingPropertyOperation => ResourceManager.GetString("SettingPropertyOperation", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {0} cannot be constructed. You must configure the container to supply this value..
	/// </summary>
	internal static string TypeIsNotConstructable => ResourceManager.GetString("TypeIsNotConstructable", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to The type {1} cannot be assigned to variables of type {0}..
	/// </summary>
	internal static string TypesAreNotAssignable => ResourceManager.GetString("TypesAreNotAssignable", resourceCulture);

	/// <summary>
	///   Looks up a localized string similar to &lt;unknown&gt;.
	/// </summary>
	internal static string UnknownType => ResourceManager.GetString("UnknownType", resourceCulture);

	internal Resources()
	{
	}
}
