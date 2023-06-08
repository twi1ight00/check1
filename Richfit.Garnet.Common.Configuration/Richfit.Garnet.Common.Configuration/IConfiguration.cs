using System;
using Richfit.Garnet.Common.Configuration.Sources;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 配置接口
/// </summary>
public interface IConfiguration : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
}
