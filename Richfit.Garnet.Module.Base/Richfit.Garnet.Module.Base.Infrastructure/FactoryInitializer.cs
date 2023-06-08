using Richfit.Garnet.Common.Adapter;
using Richfit.Garnet.Common.Adapter.AutoMapper;
using Richfit.Garnet.Common.Validator;
using Richfit.Garnet.Common.Validator.DataAnnotations;

namespace Richfit.Garnet.Module.Base.Infrastructure;

/// <summary>
/// 实体验证工厂和类型转化工厂初始化静态类，在应用启动时候调用
/// </summary>
public static class FactoryInitializer
{
	/// <summary>
	/// 初始化方法
	/// </summary>
	public static void Initialize()
	{
		ValidatorFactory.SetCurrent(new DataAnnotationsValidatorFactory());
		TypeAdapterFactory.SetCurrent(new AutomapperTypeAdapterFactory());
	}
}
