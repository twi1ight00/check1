using System;

namespace AutoMapper.Internal;

public interface IProxyGenerator
{
	Type GetProxyType(Type interfaceType);
}
