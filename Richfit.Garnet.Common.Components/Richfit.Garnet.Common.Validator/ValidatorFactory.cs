namespace Richfit.Garnet.Common.Validator;

/// <summary>
/// 验证工厂类
/// </summary>
public static class ValidatorFactory
{
	/// <summary>
	/// 工厂实例
	/// </summary>
	private static IValidatorFactory factoryHandler = null;

	/// <summary>
	/// 获取工厂类实例
	/// </summary>
	public static IValidatorFactory Factory => factoryHandler;

	/// <summary>
	/// 设置工厂实例
	/// </summary>
	/// <param name="factory">validator factory to use</param>
	public static void SetCurrent(IValidatorFactory factory)
	{
		factoryHandler = factory;
	}

	/// <summary>
	/// 创建新的工厂类实例
	/// </summary>
	/// <returns>Created IEntityValidator</returns>
	public static IValidator CreateValidator()
	{
		return (factoryHandler != null) ? factoryHandler.Create() : null;
	}
}
