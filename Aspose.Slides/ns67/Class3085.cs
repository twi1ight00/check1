using ns99;

namespace ns67;

internal abstract class Class3085 : Class3072
{
	private float float_0;

	private Interface113 interface113_0;

	private readonly Class3406 class3406_0;

	private Class3449 class3449_0;

	public float Flatness
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public Class3406 Properties => class3406_0;

	protected Interface113 Font => interface113_0;

	protected Class3449 TextFont => class3449_0;

	protected Class3085(Class3406 properties)
	{
		class3406_0 = properties;
		float_0 = 0.01f;
		method_1();
		method_0();
	}

	public abstract Class3062 vmethod_1();

	private void method_0()
	{
		interface113_0 = Class3086.Instance.method_4(class3449_0.Typeface, Properties.Bold, Properties.Italics);
	}

	private void method_1()
	{
		class3449_0 = Properties.LatinFont;
	}
}
