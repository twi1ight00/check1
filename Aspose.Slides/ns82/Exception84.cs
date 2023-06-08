namespace ns82;

internal class Exception84 : Exception83
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

	public Exception84()
	{
	}

	public Exception84(int expecting, Interface388 input, object inserted)
		: base(expecting, input)
	{
		object_1 = inserted;
	}

	public override string ToString()
	{
		if (object_1 != null && interface392_0 != null)
		{
			return string.Concat("MissingTokenException(inserted ", object_1, " at ", interface392_0.Text, ")");
		}
		if (interface392_0 != null)
		{
			return "MissingTokenException(at " + interface392_0.Text + ")";
		}
		return "MissingTokenException";
	}
}
