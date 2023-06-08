using System.Reflection;

namespace AutoMapper;

/// <summary>
/// Contains member configuration relating to source members
/// </summary>
public class SourceMemberConfig
{
	private bool _ignored;

	public MemberInfo SourceMember { get; private set; }

	public SourceMemberConfig(MemberInfo sourceMember)
	{
		SourceMember = sourceMember;
	}

	public void Ignore()
	{
		_ignored = true;
	}

	public bool IsIgnored()
	{
		return _ignored;
	}
}
