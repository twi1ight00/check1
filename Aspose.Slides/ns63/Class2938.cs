using ns60;

namespace ns63;

internal class Class2938 : Interface40
{
	private Class2746 class2746_0;

	private Class2760 class2760_0;

	private Class2764 class2764_0;

	public Class2746 TimeAnimationValueAtom
	{
		get
		{
			return class2746_0;
		}
		set
		{
			class2746_0 = value;
		}
	}

	public Class2760 VarValue
	{
		get
		{
			return class2760_0;
		}
		set
		{
			class2760_0 = value;
		}
	}

	public Class2764 VarFormula
	{
		get
		{
			return class2764_0;
		}
		set
		{
			class2764_0 = value;
		}
	}

	public Class2938(Class2746 timeAnimationValueAtom, Class2760 varValue, Class2764 varFormula)
	{
		class2746_0 = timeAnimationValueAtom;
		class2760_0 = varValue;
		class2764_0 = varFormula;
	}
}
