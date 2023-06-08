namespace Aspose.Words.Settings;

public class OdsoRecipientData
{
	private bool x57d391cbbe84a0f5 = true;

	private int xccf74072a27d1bed;

	private byte[] xc6ec09a41c7353c3;

	private int xf72e01af667e9adf;

	public bool Active
	{
		get
		{
			return x57d391cbbe84a0f5;
		}
		set
		{
			x57d391cbbe84a0f5 = value;
		}
	}

	public int Column
	{
		get
		{
			return xccf74072a27d1bed;
		}
		set
		{
			xccf74072a27d1bed = value;
		}
	}

	public byte[] UniqueTag
	{
		get
		{
			return xc6ec09a41c7353c3;
		}
		set
		{
			xc6ec09a41c7353c3 = value;
		}
	}

	public int Hash
	{
		get
		{
			return xf72e01af667e9adf;
		}
		set
		{
			xf72e01af667e9adf = value;
		}
	}

	public OdsoRecipientData Clone()
	{
		return (OdsoRecipientData)MemberwiseClone();
	}
}
