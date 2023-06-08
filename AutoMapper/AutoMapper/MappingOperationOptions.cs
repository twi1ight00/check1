using System;
using System.Collections.Generic;

namespace AutoMapper;

public class MappingOperationOptions : IMappingOperationOptions
{
	public Func<Type, object> ServiceCtor { get; private set; }

	public bool CreateMissingTypeMaps { get; set; }

	public IDictionary<string, object> Items { get; private set; }

	public MappingOperationOptions()
	{
		Items = new Dictionary<string, object>();
	}

	void IMappingOperationOptions.ConstructServicesUsing(Func<Type, object> constructor)
	{
		ServiceCtor = constructor;
	}
}
