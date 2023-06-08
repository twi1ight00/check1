using System;
using System.Collections.Generic;

namespace AutoMapper;

/// <summary>
/// Options for a single map operation
/// </summary>
public interface IMappingOperationOptions
{
	/// <summary>
	/// Create any missing type maps, if found
	/// </summary>
	bool CreateMissingTypeMaps { get; set; }

	/// <summary>
	/// Add context items to be accessed at map time inside an <see cref="T:AutoMapper.IValueResolver" /> or <see cref="T:AutoMapper.ITypeConverter`2" />
	/// </summary>
	IDictionary<string, object> Items { get; }

	/// <summary>
	/// Construct services using this callback. Use this for child/nested containers
	/// </summary>
	/// <param name="constructor"></param>
	void ConstructServicesUsing(Func<Type, object> constructor);
}
