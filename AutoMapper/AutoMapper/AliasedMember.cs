namespace AutoMapper;

public class AliasedMember
{
	public string Member { get; private set; }

	public string Alias { get; private set; }

	public AliasedMember(string member, string alias)
	{
		Member = member;
		Alias = alias;
	}

	public bool Equals(AliasedMember other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other.Member, Member))
		{
			return object.Equals(other.Alias, Alias);
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
		if ((object)obj.GetType() != typeof(AliasedMember))
		{
			return false;
		}
		return Equals((AliasedMember)obj);
	}

	public override int GetHashCode()
	{
		return (Member.GetHashCode() * 397) ^ Alias.GetHashCode();
	}
}
