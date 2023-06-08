namespace x66dd9eaee57cfba4;

internal class x40ece001856d7b50
{
	private readonly int x933fbdb4e4f6c448;

	private readonly int xed5d42e5ec2e2a9e;

	public int x72d92bd1aff02e37 => x933fbdb4e4f6c448;

	public int x419ba17a5322627b => xed5d42e5ec2e2a9e;

	public x40ece001856d7b50(int left, int right)
	{
		xed5d42e5ec2e2a9e = right;
		x933fbdb4e4f6c448 = left;
	}

	public bool Equals(x40ece001856d7b50 other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (other.xed5d42e5ec2e2a9e == xed5d42e5ec2e2a9e)
		{
			return other.x933fbdb4e4f6c448 == x933fbdb4e4f6c448;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(x40ece001856d7b50))
		{
			return false;
		}
		return Equals((x40ece001856d7b50)obj);
	}

	public override int GetHashCode()
	{
		return (xed5d42e5ec2e2a9e * 397) ^ x933fbdb4e4f6c448;
	}
}
