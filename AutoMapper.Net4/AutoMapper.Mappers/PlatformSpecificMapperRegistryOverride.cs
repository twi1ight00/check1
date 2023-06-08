using System.Linq;

namespace AutoMapper.Mappers;

public class PlatformSpecificMapperRegistryOverride : IPlatformSpecificMapperRegistry
{
	public void Initialize()
	{
		InsertBefore<TypeMapMapper>(new DataReaderMapper());
		InsertBefore<DictionaryMapper>(new NameValueCollectionMapper());
		InsertBefore<ReadOnlyCollectionMapper>(new ListSourceMapper());
		InsertBefore<CollectionMapper>(new HashSetMapper());
		InsertBefore<NullableSourceMapper>(new TypeConverterMapper());
	}

	private void InsertBefore<TObjectMapper>(IObjectMapper mapper) where TObjectMapper : IObjectMapper
	{
		IObjectMapper objectMapper = MapperRegistry.Mappers.FirstOrDefault((IObjectMapper om) => om is TObjectMapper);
		int index = ((objectMapper != null) ? MapperRegistry.Mappers.IndexOf(objectMapper) : 0);
		MapperRegistry.Mappers.Insert(index, mapper);
	}
}
