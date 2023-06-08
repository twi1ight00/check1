using System.Collections;
using System.Collections.Generic;

namespace Quartz.Collection;

/// <summary>
/// Represents a collection ob objects that contains no duplicate elements.
/// </summary>	
/// <author>Marko Lahma (.NET)</author>
public interface ISet<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
}
