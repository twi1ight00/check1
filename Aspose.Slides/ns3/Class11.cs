namespace ns3;

internal class Class11
{
	private byte[] byte_0;

	private int int_0;

	private int int_1;

	private string string_0;

	private string string_1;

	private string string_2;

	public byte[] SaltValue
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public int KeyBits
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int BlockSize
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public string HashAlogrithm
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

	public string CipherAlogrithm
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string CipherChaining
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}
}
