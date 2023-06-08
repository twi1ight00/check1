using System;

namespace AutoMapper;

public interface IMemberResolver : IValueResolver
{
	Type MemberType { get; }
}
