using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;

namespace Aspose.Words.Settings;

public class WriteProtection
{
	private bool x24b1b12f90dc678b;

	private string x43bfbd3c83649bc6 = "";

	private x218603e609fcc201 x5975aea07b196748 = new x218603e609fcc201();

	public bool ReadOnlyRecommended
	{
		get
		{
			return x24b1b12f90dc678b;
		}
		set
		{
			x24b1b12f90dc678b = value;
		}
	}

	internal x218603e609fcc201 x218603e609fcc201 => x5975aea07b196748;

	public bool IsWriteProtected
	{
		get
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(x43bfbd3c83649bc6))
			{
				return !x5975aea07b196748.x7149c962c02931b3;
			}
			return true;
		}
	}

	internal WriteProtection()
	{
	}

	internal WriteProtection x8b61531c8ea35b85()
	{
		WriteProtection writeProtection = (WriteProtection)MemberwiseClone();
		writeProtection.x5975aea07b196748 = x5975aea07b196748.x8b61531c8ea35b85();
		return writeProtection;
	}

	public void SetPassword(string password)
	{
		x0d299f323d241756.x0aaaea7864a53f26(password, "password");
		x43bfbd3c83649bc6 = password;
		x5975aea07b196748.xf35aae0fa4a217a4 = null;
	}

	internal string x72213a2a58cf72d7()
	{
		return x43bfbd3c83649bc6;
	}

	internal void xde1927bac9d7e698()
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x43bfbd3c83649bc6) && x5975aea07b196748.x7149c962c02931b3)
		{
			x5975aea07b196748.x94322bb2aaf0dbfe(x43bfbd3c83649bc6);
		}
	}
}
