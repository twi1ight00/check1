namespace ns82;

internal class Exception24 : Exception23
{
	private object object_1;

	public int MissingType => base.Expecting;

	public object Inserted
	{
		get
		{
			return object_1;
		}
		set
		{
			object_1 = value;
		}
	}

	public Exception24()
	{
	}

	public Exception24(int expecting, Interface107 input, object inserted)
		: base(expecting, input)
	{
		object_1 = inserted;
	}

	public override string ToString()
	{
		if (object_1 != null && interface86_0 != null)
		{
			return string.Concat("MissingTokenException(inserted ", object_1, " at ", interface86_0.Text, ")");
		}
		if (interface86_0 != null)
		{
			return "MissingTokenException(at " + interface86_0.Text + ")";
		}
		return "MissingTokenException";
	}
}
