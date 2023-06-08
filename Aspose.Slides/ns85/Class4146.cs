using System.Runtime.CompilerServices;

namespace ns85;

internal abstract class Class4146<TEntity> : Interface98<TEntity>
{
	public abstract bool imethod_0(TEntity candidate);

	[SpecialName]
	public static Interface98<TEntity> smethod_0(Class4146<TEntity> left, Class4146<TEntity> right)
	{
		return left.method_0(right);
	}

	[SpecialName]
	public static Interface98<TEntity> smethod_1(Class4146<TEntity> left, Class4146<TEntity> right)
	{
		return left.method_1(right);
	}

	[SpecialName]
	public static Interface98<TEntity> smethod_2(Class4146<TEntity> left)
	{
		return left.method_2();
	}

	[SpecialName]
	public static bool smethod_3(Class4146<TEntity> specification)
	{
		return false;
	}

	[SpecialName]
	public static bool smethod_4(Class4146<TEntity> specification)
	{
		return false;
	}

	public Interface98<TEntity> method_0(Interface98<TEntity> rigth)
	{
		return new Class4151<TEntity>(this, rigth);
	}

	public Interface98<TEntity> method_1(Interface98<TEntity> rigth)
	{
		return new Class4153<TEntity>(this, rigth);
	}

	public Interface98<TEntity> method_2()
	{
		return new Class4152<TEntity>(this);
	}
}
