using AutoMapper;

namespace Richfit.Garnet.Common.Adapter.AutoMapper;

/// <summary>
/// AutoMapper 公共配置文件
/// </summary>
public class CommonProfile : Profile
{
	/// <inheritdoc />
	public override string ProfileName => "Common";

	/// <inheritdoc />
	protected override void Configure()
	{
	}
}
