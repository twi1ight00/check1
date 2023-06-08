using AutoMapper;

namespace Richfit.Garnet.Common.Dynamic;

/// <summary>
/// 数据对象映射配置文件
/// </summary>
public class DataObjectMappingProfile : Profile
{
	/// <inheritdoc />
	public override string ProfileName => "DataObjectMapping";

	/// <inheritdoc />
	protected override void Configure()
	{
	}
}
