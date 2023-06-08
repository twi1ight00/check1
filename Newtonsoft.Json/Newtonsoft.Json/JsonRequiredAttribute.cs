using System;

namespace Newtonsoft.Json;

/// <summary>
///   Instructs the <see cref="T:Newtonsoft.Json.JsonSerializer" /> to always serialize the member, and require the member has a value.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class JsonRequiredAttribute : Attribute
{
}
