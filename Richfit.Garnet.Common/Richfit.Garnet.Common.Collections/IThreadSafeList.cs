using System;
using System.Collections;
using System.Collections.Generic;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 线程安全集合接口
/// </summary>
public interface IThreadSafeList<T> : IList<T>, ICollection<T>, IEnumerable<T>, ICollection, IEnumerable, IDisposableObject, IDisposable
{
}
