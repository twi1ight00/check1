namespace ns67;

internal sealed class Class3078 : Class3075
{
	public Class3078(Class3404 bullet, Class3391 color, Class3394 size, Class3398 typeface, Class3406 characterProperties, Class3455 textBodyExtents)
		: base(bullet, color, size, typeface, characterProperties)
	{
		Class3406 properties = method_3();
		Class3080 @class = new Class3080(properties, textBodyExtents);
		string bulletCharacter = bullet.BulletCharacter;
		foreach (char ch in bulletCharacter)
		{
			@class.method_5(ch);
		}
		method_1(@class);
	}

	public override Class3455 vmethod_0()
	{
		Class3072[] array = method_0();
		return array[0].vmethod_0();
	}
}
