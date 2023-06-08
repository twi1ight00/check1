namespace Richfit.Garnet.Common.Adapter;

/// <summary>
/// Factory
/// </summary>
public static class TypeAdapterFactory
{
	/// <summary>
	/// Factory instance
	/// </summary>
	private static ITypeAdapterFactory currentTypeAdapterFactory = null;

	/// <summary>
	/// Set the current type adapter factory
	/// </summary>
	/// <param name="adapterFactory">The adapter factory to set</param>
	public static void SetCurrent(ITypeAdapterFactory adapterFactory)
	{
		currentTypeAdapterFactory = adapterFactory;
	}

	/// <summary>
	/// Create a new type adapter from currect factory
	/// </summary>
	/// <returns>Created type adapter</returns>
	public static ITypeAdapter CreateAdapter()
	{
		return currentTypeAdapterFactory.Create();
	}
}
