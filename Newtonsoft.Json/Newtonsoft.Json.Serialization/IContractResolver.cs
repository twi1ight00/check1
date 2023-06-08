using System;

namespace Newtonsoft.Json.Serialization;

/// <summary>
///   Used by <see cref="T:Newtonsoft.Json.JsonSerializer" /> to resolves a <see cref="T:Newtonsoft.Json.Serialization.JsonContract" /> for a given <see cref="T:System.Type" />.
/// </summary>
/// <example>
///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\SerializationTests.cs" region="ReducingSerializedJsonSizeContractResolverObject" title="IContractResolver Class" />
///   <code lang="cs" source="..\Src\Newtonsoft.Json.Tests\Documentation\SerializationTests.cs" region="ReducingSerializedJsonSizeContractResolverExample" title="IContractResolver Example" />
/// </example>
public interface IContractResolver
{
	/// <summary>
	///   Resolves the contract for a given type.
	/// </summary>
	/// <param name="type">The type to resolve a contract for.</param>
	/// <returns>The contract for a given type.</returns>
	JsonContract ResolveContract(Type type);
}
