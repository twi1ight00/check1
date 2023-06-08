namespace ns85;

internal class Class4152<TEntity> : Interface98<TEntity>
{
	private Interface98<TEntity> interface98_0;

	internal Class4152(Interface98<TEntity> spec)
	{
		interface98_0 = spec;
	}

	public bool imethod_0(TEntity candidate)
	{
		return !interface98_0.imethod_0(candidate);
	}
}
