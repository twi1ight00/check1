namespace ns318;

internal class Class7189
{
	private bool bool_0;

	private bool bool_1;

	private Interface385 interface385_0;

	public bool NormalizeAps
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool AddAspectRatio
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Interface385 Callback
	{
		get
		{
			return interface385_0;
		}
		set
		{
			interface385_0 = value;
		}
	}

	public Class7189()
	{
	}

	public Class7189(bool normalizeAps, bool addAspectRatio, Interface385 callback)
	{
		bool_0 = normalizeAps;
		bool_1 = addAspectRatio;
		interface385_0 = callback;
	}
}
