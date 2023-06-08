namespace ns85;

internal class Class4153<TEntity> : Interface98<TEntity>
{
	private Interface98<TEntity> interface98_0;

	private Interface98<TEntity> interface98_1;

	internal Class4153(Interface98<TEntity> left, Interface98<TEntity> rigth)
	{
		interface98_0 = left;
		interface98_1 = rigth;
	}

	public bool imethod_0(TEntity candidate)
	{
		if (!interface98_0.imethod_0(candidate))
		{
			return interface98_1.imethod_0(candidate);
		}
		return true;
	}
}
