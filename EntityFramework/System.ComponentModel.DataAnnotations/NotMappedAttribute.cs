using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel.DataAnnotations;

/// <summary>
///     Denotes that a property or class should be excluded from database mapping.
/// </summary>
[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes")]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
public class NotMappedAttribute : Attribute
{
}
