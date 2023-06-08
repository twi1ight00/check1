namespace AutoMapper;

/// <summary>
/// Main entry point for executing maps
/// </summary>
public interface IMappingEngineRunner
{
	IConfigurationProvider ConfigurationProvider { get; }

	object Map(ResolutionContext context);

	object CreateObject(ResolutionContext context);

	string FormatValue(ResolutionContext context);

	bool ShouldMapSourceValueAsNull(ResolutionContext context);

	bool ShouldMapSourceCollectionAsNull(ResolutionContext context);
}
