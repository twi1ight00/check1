using System.Reflection;

namespace AutoMapper;

public interface IMemberGetter : IMemberResolver, IValueResolver
{
	MemberInfo MemberInfo { get; }

	string Name { get; }

	object GetValue(object source);
}
