namespace ns237;

internal class Class6510
{
	private Enum871 enum871_0;

	private int int_0;

	private string string_0;

	private string string_1;

	public string UserPassword
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

	public string OwnerPassword
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

	public int Permissions
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

	public Enum871 EncryptionAlgorithm
	{
		get
		{
			return enum871_0;
		}
		set
		{
			enum871_0 = value;
		}
	}

	public Class6510(string userPassword, string ownerPassword, int permissions, Enum871 encryptionAlgorithm)
	{
		string_0 = userPassword;
		string_1 = ownerPassword;
		int_0 = permissions;
		enum871_0 = encryptionAlgorithm;
	}
}
