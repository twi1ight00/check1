using System;

namespace Richfit.Garnet.Module.Base.Infrastructure.TimeZone;

/// <summary>
/// 标识类上Datetime属性不需要时区处理，默认时间属性需要时区处理
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ZoneAwayAttribute : Attribute
{
}
