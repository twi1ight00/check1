using AutoMapper.Impl;

namespace AutoMapper.Internal;

public class ProxyGeneratorFactoryOverride : IProxyGeneratorFactory
{
	public IProxyGenerator Create()
	{
		return new ProxyGenerator();
	}
}
