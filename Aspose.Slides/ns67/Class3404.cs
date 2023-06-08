namespace ns67;

internal sealed class Class3404 : Class3401
{
	private string string_0;

	public string BulletCharacter
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class3404(string bulletCharacter)
	{
		BulletCharacter = bulletCharacter;
	}

	public override Class3401 vmethod_0()
	{
		return new Class3404(string_0);
	}
}
