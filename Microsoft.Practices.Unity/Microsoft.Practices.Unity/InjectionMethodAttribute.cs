using System;

namespace Microsoft.Practices.Unity;

/// <summary>
/// This attribute is used to mark methods that should be called when
/// the container is building an object.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class InjectionMethodAttribute : Attribute
{
}
