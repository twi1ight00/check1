namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// This interface defines a standard method to convert any 
/// <see cref="T:Microsoft.Practices.ObjectBuilder2.StagedStrategyChain`1" /> regardless
/// of the stage enum into a regular, flat strategy chain.
/// </summary>
public interface IStagedStrategyChain
{
	/// <summary>
	/// Convert this <see cref="T:Microsoft.Practices.ObjectBuilder2.StagedStrategyChain`1" /> into
	/// a flat <see cref="T:Microsoft.Practices.ObjectBuilder2.IStrategyChain" />.
	/// </summary>
	/// <returns>The flattened <see cref="T:Microsoft.Practices.ObjectBuilder2.IStrategyChain" />.</returns>
	IStrategyChain MakeStrategyChain();
}
