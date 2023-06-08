using System;
using System.Collections;
using System.Collections.Generic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 类型安全集合
/// </summary>
public class ThreadSafeList<T> : SyncableObject, IThreadSafeList<T>, IList<T>, ICollection<T>, IEnumerable<T>, ICollection, IEnumerable, IDisposableObject, IDisposable
{
	/// <summary>
	/// 内部集合
	/// </summary>
	private List<T> list;

	/// <summary>
	/// 获取或设置该内部数据结构在不调整大小的情况下能够容纳的元素总数。
	/// </summary>
	public int Capacity
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				CheckDisposed();
				return list.Capacity;
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				CheckDisposed();
				list.Capacity = value.GuardGreaterThanOrEqualTo(Count);
			});
		}
	}

	/// <summary>
	/// 获取列表中实际包含的元素数量
	/// </summary>
	public int Count => base.SyncRoot.Read(delegate
	{
		CheckDisposed();
		return list.Count;
	});

	/// <summary>
	/// 指示当前集合是否为空（不包含任何元素）
	/// </summary>
	public bool IsEmpty => base.SyncRoot.Read(delegate
	{
		CheckDisposed();
		return list.Count == 0;
	});

	/// <summary>
	/// 指示当前的集合是否是只读集合
	/// </summary>
	public bool IsReadOnly => false;

	/// <summary>
	/// 指示对集合的访问是否是同步的
	/// </summary>
	public bool IsSynchronized => true;

	/// <summary>
	/// 获取用于同步对集合访问的对象
	/// </summary>
	object ICollection.SyncRoot => base.SyncRoot;

	/// <summary>
	/// 获取或设置指定索引处的元素
	/// </summary>
	/// <param name="index">获取的元素索引，如果设置为负数则为逆向索引，最后一个元素的索引为-1</param>
	/// <returns>指定索引处的元素</returns>
	public T this[int index]
	{
		get
		{
			return base.SyncRoot.Read(delegate
			{
				CheckDisposed();
				index = ((index < 0) ? (list.Count + index) : index);
				index.GuardBetween(0, list.Count - 1);
				return list[index];
			});
		}
		set
		{
			base.SyncRoot.Write(delegate
			{
				CheckDisposed();
				index = ((index < 0) ? (list.Count + index) : index);
				index.GuardBetween(0, list.Count - 1);
				list[index] = value;
			});
		}
	}

	/// <summary>
	/// 获取基础集合
	/// </summary>
	public List<T> UnderlyingList
	{
		get
		{
			CheckDisposed();
			return list;
		}
	}

	/// <summary>
	/// 初始化集合实例
	/// </summary>
	public ThreadSafeList()
	{
		list = new List<T>();
	}

	/// <summary>
	/// 初始化集合实例，并指定初始容量
	/// </summary>
	/// <param name="capacity">初始容量，应大于等于0</param>
	public ThreadSafeList(int capacity)
	{
		capacity.GuardGreaterThanOrEqualTo(0);
		list = new List<T>(capacity);
	}

	/// <summary>
	/// 初始化集合实例，并用序列中的对象填充
	/// </summary>
	/// <param name="collection">初始化用的对象序列</param>
	public ThreadSafeList(IEnumerable<T> collection)
	{
		collection.GuardNotNull();
		list = new List<T>(collection);
	}

	/// <summary>
	/// 将对象添加到集合结尾
	/// </summary>
	/// <param name="item">待添加的对象</param>
	public void Add(T item)
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			list.Add(item);
		});
	}

	/// <summary>
	/// 将序列中的对象添加到集合结尾
	/// </summary>
	/// <param name="collection">待添加的对象序列</param>
	public void AddRange(IEnumerable<T> collection)
	{
		collection.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			foreach (T current in collection)
			{
				list.Add(current);
			}
		});
	}

	/// <summary>
	/// 从当前集合中移除所有项目
	/// </summary>
	public void Clear()
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			list.Clear();
		});
	}

	/// <summary>
	/// 检测当前集合中是否存在指定的对象值
	/// </summary>
	/// <param name="item">待检测的对象值</param>
	/// <returns>如果存在返回true，否则返回false</returns>
	public bool Contains(T item)
	{
		return base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			return list.Contains(item);
		});
	}

	/// <summary>
	/// 从指定的数组索引处开始，将集合中的元素复制到数组中。
	/// </summary>
	/// <param name="array">复制的目标数组</param>
	/// <param name="arrayIndex">目标数组中开始复制的索引位置</param>
	public void CopyTo(Array array, int arrayIndex)
	{
		array.GuardNotNull();
		base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			arrayIndex.Guard(arrayIndex.Between(0, array.Length - 1) && array.Length - arrayIndex >= Count, typeof(ArgumentOutOfRangeException));
			for (int i = 0; i < list.Count; i++)
			{
				array.SetValue(list[i], i + arrayIndex);
			}
		});
	}

	/// <summary>
	/// 从指定的数组索引处开始，将集合的元素复制到数组中
	/// </summary>
	/// <param name="array">复制的目标数组</param>
	/// <param name="arrayIndex">目标数组中开始复制的索引位置</param>
	public void CopyTo(T[] array, int arrayIndex)
	{
		array.GuardNotNull();
		base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			arrayIndex.Guard(arrayIndex.Between(0, array.Length - 1) && array.Length - arrayIndex >= Count, typeof(ArgumentOutOfRangeException));
			list.CopyTo(array, arrayIndex);
		});
	}

	/// <summary>
	/// 检测当前集合中是否包含与指定条件匹配的元素
	/// </summary>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果包含与指定条件匹配的元素返回true，否则返回false</returns>
	public bool Exists(Func<T, bool> predicate)
	{
		if (predicate.IsNull())
		{
			return false;
		}
		return base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			return list.Exists(predicate);
		});
	}

	/// <summary>
	/// 获取集合的枚举数
	/// </summary>
	/// <returns>线程安全的集合枚举数</returns>
	public IEnumerator<T> GetEnumerator()
	{
		base.SyncRoot.Read();
		try
		{
			CheckDisposed();
			foreach (T item in list)
			{
				yield return item;
			}
		}
		finally
		{
			base.SyncRoot.Release();
		}
	}

	/// <summary>
	/// 获取集合的枚举数
	/// </summary>
	/// <returns>线程安全的集合枚举数</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	/// <summary>
	/// 创建当前集合中指定范围的浅表副本
	/// </summary>
	/// <param name="index">从零开始的元素索引</param>
	/// <param name="count">范围中的元素数</param>
	/// <returns>浅表副本</returns>
	public List<T> GetRange(int index, int count)
	{
		return base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			index.GuardBetween(0, list.Count - 1);
			count.GuardBetween(0, list.Count - index);
			return list.GetRange(index, count);
		});
	}

	/// <summary>
	/// 获取在当前集合中指定项目的位置索引
	/// </summary>
	/// <param name="item">待查找的项目</param>
	/// <returns>指定项目的位置索引，如果未找到返回-1</returns>
	public int IndexOf(T item)
	{
		return base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			return list.IndexOf(item);
		});
	}

	/// <summary>
	/// 获取在当前集合中指定项目的位置索引，从指定的位置开始搜索
	/// </summary>
	/// <param name="item">待搜索项目</param>
	/// <param name="index">开始搜索的位置</param>
	/// <returns>找到的指定项目的位置索引，如果未找到返回-1</returns>
	public int IndexOf(T item, int index)
	{
		return base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			index.GuardBetween(0, list.Count - 1);
			return list.IndexOf(item, index);
		});
	}

	/// <summary>
	/// 获取在当前集合中指定项目的位置索引，从指定的位置开始搜索并检查指定个数的元素
	/// </summary>
	/// <param name="item">待搜索的项目</param>
	/// <param name="index">开始搜索的位置</param>
	/// <param name="count">搜索的元素的数量</param>
	/// <returns>找到的指定项目的位置索引，如果未找到返回-1</returns>
	public int IndexOf(T item, int index, int count)
	{
		return base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			index.GuardBetween(0, list.Count - 1);
			count.GuardBetween(0, list.Count - index);
			return list.IndexOf(item, index, count);
		});
	}

	/// <summary>
	/// 将指定项目插入到当前集合的指定位置
	/// </summary>
	/// <param name="index">指定插入的位置，如果设置为负数则为逆向索引，最后一个元素的索引为-1</param>
	/// <param name="item">待插入的项目</param>
	public void Insert(int index, T item)
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			index = ((index < 0) ? (list.Count + index + 1) : index);
			index.GuardBetween(0, list.Count);
			list.Insert(index, item);
		});
	}

	/// <summary>
	/// 将指定项目插入到当前集合的末尾
	/// </summary>
	/// <param name="item">待插入的项目</param>
	public void InsertLast(T item)
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			list.Insert(list.Count, item);
		});
	}

	/// <summary>
	/// 将指定项目插入到当前集合的开始位置
	/// </summary>
	/// <param name="item">待插入的项目</param>
	public void InsertFirst(T item)
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			list.Insert(0, item);
		});
	}

	/// <summary>
	/// 将指定的项目列表插入到当前集合的指定位置
	/// </summary>
	/// <param name="index">插入指定的位置，如果设置为负数则为逆向索引，最后一个元素的索引为-1</param>
	/// <param name="collection">待插入的项目集合</param>
	public void InsertRange(int index, IEnumerable<T> collection)
	{
		collection.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			index = ((index < 0) ? (list.Count + index + 1) : index);
			index.GuardBetween(0, list.Count);
			list.InsertRange(index, collection);
		});
	}

	/// <summary>
	/// 获取指定索引处的元素，如果没有指定处的索引则抛出异常
	/// </summary>
	/// <param name="index">获取的元素索引，如果设置为负数则为逆向索引，最后一个元素的索引为-1</param>
	public T Peek(int index)
	{
		if (!TryPeek(index, out var result))
		{
			throw new IndexOutOfRangeException(Literals.MSG_IndexOutOfRange_1.FormatValue(index));
		}
		return result;
	}

	/// <summary>
	/// 获取集合中符合条件的第一个项目，如果没有符合条件的项目则抛出异常
	/// </summary>
	/// <param name="predicate">筛选条件</param>
	/// <returns>集合中符合调价的第一个项目</returns>
	public T Peek(Func<T, bool> predicate)
	{
		if (!TryPeek(predicate, out var result))
		{
			throw new InvalidOperationException(Literals.MSG_PredicateNotMatched);
		}
		return result;
	}

	/// <summary>
	/// 获取集合第一个元素，如果集合为空则抛出异常
	/// </summary>
	/// <returns>获取的集合的第一个元素</returns>
	public T PeekFirst()
	{
		if (!TryPeekFirst(out var result))
		{
			throw new InvalidOperationException(Literals.MSG_ListEmpty);
		}
		return result;
	}

	/// <summary>
	/// 获取集合的最后一个元素，如果集合为空则抛出异常
	/// </summary>
	/// <returns>获取的集合的最后一个元素</returns>
	public T PeekLast()
	{
		if (!TryPeekLast(out var result))
		{
			throw new InvalidOperationException(Literals.MSG_ListEmpty);
		}
		return result;
	}

	/// <summary>
	/// 从当前集合中移除与指定对象匹配的第一个项目
	/// </summary>
	/// <param name="item">待移除的目标对象</param>
	/// <returns>如果找匹配项目成功移除返回true，否则false</returns>
	public bool Remove(T item)
	{
		return base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			return list.Remove(item);
		});
	}

	/// <summary>
	/// 从当前集合中移除所有符合条件的项目
	/// </summary>
	/// <param name="predicate">移除筛选条件</param>
	/// <returns>移除的项目的数量</returns>
	public int Remove(Func<T, bool> predicate)
	{
		if (predicate.IsNull())
		{
			return 0;
		}
		return base.SyncRoot.UpgradableRead(delegate
		{
			CheckDisposed();
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (predicate(list[i]))
				{
					list.RemoveAt(i--);
					num++;
				}
			}
			return num;
		});
	}

	/// <summary>
	/// 移除当前集合中指定位置的项目
	/// </summary>
	/// <param name="index">需要移除项目的索引，如果设置为负数则为逆向索引，最后一个元素的索引为-1</param>
	public void RemoveAt(int index)
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			index = ((index < 0) ? (list.Count + index) : index);
			index.GuardBetween(0, list.Count - 1);
			list.RemoveAt(index);
		});
	}

	/// <summary>
	/// 移除当前集合中指定范围内的元素
	/// </summary>
	/// <param name="index">移除范围的起始索引</param>
	/// <param name="count">移除范围内的元素数量</param>
	public void RemoveRange(int index, int count)
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			index.GuardBetween(0, list.Count - 1);
			count.GuardBetween(0, list.Count - index);
			list.RemoveRange(index, count);
		});
	}

	/// <summary>
	/// 将集合中的元素顺序反转
	/// </summary>
	public void Reverse()
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			list.Reverse();
		});
	}

	/// <summary>
	/// 将集合中指定范围内的元素顺序反转
	/// </summary>
	/// <param name="index">待反转的范围的起始位置索引</param>
	/// <param name="count">待反转范围内的元素个数</param>
	public void Reverse(int index, int count)
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			index.GuardBetween(0, list.Count - 1);
			count.GuardBetween(0, list.Count - index);
			list.Reverse(index, count);
		});
	}

	/// <summary>
	/// 对当前集合中的元素进行排序，使用默认比较器
	/// </summary>
	public void Sort()
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			list.Sort();
		});
	}

	/// <summary>
	/// 对当前集合中的元素进行排序，使用指定的比较方法
	/// </summary>
	/// <param name="comparison">集合元素排序比较方法</param>
	public void Sort(Comparison<T> comparison)
	{
		comparison.GuardNotNull();
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			list.Sort(comparison);
		});
	}

	/// <summary>
	/// 对当前集合中的元素进行排序，使用指定的比较器
	/// </summary>
	/// <param name="comparer">集合元素比较器</param>
	public void Sort(IComparer<T> comparer)
	{
		comparer = comparer.IfNull(Comparer<T>.Default);
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			list.Sort(comparer);
		});
	}

	/// <summary>
	/// 使用指定比较器对当前集合中的指定范围内的元素进行排序
	/// </summary>
	/// <param name="index">排序范围从零开始的索引</param>
	/// <param name="count">排序范围内的元素数量</param>
	/// <param name="comparer">元素比较器</param>
	public void Sort(int index, int count, IComparer<T> comparer)
	{
		comparer = comparer.IfNull(Comparer<T>.Default);
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			index.GuardBetween(0, list.Count - 1);
			count.GuardBetween(0, list.Count - index);
			list.Sort(index, count, comparer);
		});
	}

	/// <summary>
	/// 获取并移除指定索引处的元素，如果指定的索引超出范围则抛出异常
	/// </summary>
	/// <param name="index">获取的元素索引，如果设置为负数则为逆向索引，最后一个元素的索引为-1</param>
	/// <returns>获取并移除的元素</returns>
	public T Take(int index)
	{
		if (!TryTake(index, out var result))
		{
			throw new IndexOutOfRangeException(Literals.MSG_IndexOutOfRange_1.FormatValue(index));
		}
		return result;
	}

	/// <summary>
	/// 获取并移除指定索引处的元素，如果没有指定处
	/// </summary>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>获取并移除的元素</returns>
	public T Take(Func<T, bool> predicate)
	{
		if (!TryTake(predicate, out var result))
		{
			throw new InvalidOperationException(Literals.MSG_PredicateNotMatched);
		}
		return result;
	}

	/// <summary>
	/// 获取并移除集合中的第一个元素，如果集合为空则抛出异常
	/// </summary>
	/// <returns>获取并移除的元素</returns>
	public T TakeFirst()
	{
		if (!TryTakeFirst(out var result))
		{
			throw new InvalidOperationException(Literals.MSG_ListEmpty);
		}
		return result;
	}

	/// <summary>
	/// 获取并移除集合中最后一个元素，如果集合为空则抛出异常
	/// </summary>
	/// <returns>获取并移除的元素</returns>
	public T TakeLast()
	{
		if (!TryTakeLast(out var result))
		{
			throw new InvalidOperationException(Literals.MSG_ListEmpty);
		}
		return result;
	}

	/// <summary>
	/// 将当前集合中的元素复制到新数组
	/// </summary>
	/// <returns>复制的新数组</returns>
	public T[] ToArray()
	{
		return base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			return list.ToArray();
		});
	}

	/// <summary>
	/// 将当前集合的容量设置为实际元素数量
	/// </summary>
	public void TrimExcess()
	{
		base.SyncRoot.Write(delegate
		{
			CheckDisposed();
			list.TrimExcess();
		});
	}

	/// <summary>
	/// 尝试获取指定索引处的元素
	/// </summary>
	/// <param name="index">获取的元素索引，如果设置为负数则为逆向索引，最后一个元素的索引为-1</param>
	/// <param name="result">指定索引处的元素，如果获取失败则包含类型的默认值</param>
	/// <returns>如果获取成功返回true，否则返回false</returns>
	public bool TryPeek(int index, out T result)
	{
		T value = default(T);
		bool status = base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			if (list.Count > 0)
			{
				index = ((index < 0) ? (list.Count + index) : index);
				if (0 <= index && index < list.Count)
				{
					value = list[index];
					return true;
				}
				return false;
			}
			return false;
		});
		result = value;
		return status;
	}

	/// <summary>
	/// 尝试获取集合中符合条件的第一个元素
	/// </summary>
	/// <param name="predicate">元素筛选调价</param>
	/// <param name="result">指定索引处的元素，如果获取失败则包含类型的默认值</param>
	/// <returns>如果获取成功返回true，否则返回false</returns>
	public bool TryPeek(Func<T, bool> predicate, out T result)
	{
		T value = default(T);
		if (predicate.IsNull())
		{
			result = value;
			return false;
		}
		bool status = base.SyncRoot.Read(delegate
		{
			CheckDisposed();
			if (list.Count > 0)
			{
				foreach (T current in list)
				{
					if (predicate(current))
					{
						value = current;
						return true;
					}
				}
				return false;
			}
			return false;
		});
		result = value;
		return status;
	}

	/// <summary>
	/// 尝试获取集合中的第一个元素
	/// </summary>
	/// <param name="result">集合的第一个元素，如果获取失败则包含类型的默认值</param>
	/// <returns>如果获取成功返回true，否则返回false</returns>
	public bool TryPeekFirst(out T result)
	{
		return TryPeek(0, out result);
	}

	/// <summary>
	/// 尝试获取集合中的第一个元素
	/// </summary>
	/// <param name="result">集合中的第一个元素，如果获取失败则包含类型的默认值</param>
	/// <returns>如果获取成功返回true，否则返回false</returns>
	public bool TryPeekLast(out T result)
	{
		return TryPeek(-1, out result);
	}

	/// <summary>
	/// 尝试获取并移除指定索引处的元素
	/// </summary>
	/// <param name="index">获取的元素索引，如果设置为负数则为逆向索引，最后一个元素的索引为-1</param>
	/// <param name="result">获取并移除的元素，如果操作失败则包含类型的默认值</param>
	/// <returns>如果获取成功返回true，否则返回false</returns>
	public bool TryTake(int index, out T result)
	{
		T value = default(T);
		bool status = base.SyncRoot.UpgradableRead(delegate
		{
			CheckDisposed();
			if (list.Count > 0)
			{
				index = ((index < 0) ? (list.Count + index) : index);
				if (0 <= index && index < list.Count)
				{
					value = list[index];
					base.SyncRoot.Write(delegate
					{
						list.RemoveAt(index);
					});
					return true;
				}
				return false;
			}
			return false;
		});
		result = value;
		return status;
	}

	/// <summary>
	/// 尝试获取并移除符合条件的一个元素
	/// </summary>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="result">获取并移除的元素，如果操作失败则包含类型的默认值</param>
	/// <returns>如果获取成功返回true，否则返回false</returns>
	public bool TryTake(Func<T, bool> predicate, out T result)
	{
		T value = default(T);
		if (predicate.IsNull())
		{
			result = value;
			return false;
		}
		bool status = base.SyncRoot.UpgradableRead(delegate
		{
			CheckDisposed();
			if (list.Count > 0)
			{
				int i;
				for (i = 0; i < list.Count; i++)
				{
					if (predicate(list[i]))
					{
						value = list[i];
						base.SyncRoot.Write(delegate
						{
							list.RemoveAt(i);
						});
						return true;
					}
				}
				return false;
			}
			return false;
		});
		result = value;
		return status;
	}

	/// <summary>
	/// 尝试获取并移除集合中第一个元素
	/// </summary>
	/// <param name="result">获取并移除的元素，如果操作失败则包含类型的默认值</param>
	/// <returns>如果获取成功返回true，否则返回false</returns>
	public bool TryTakeFirst(out T result)
	{
		return TryTake(0, out result);
	}

	/// <summary>
	/// 尝试获取并移除集合中的最后一个元素
	/// </summary>
	/// <param name="result">获取并移除的元素，如果操作失败则包含类型的默认值</param>
	/// <returns>如果获取成功返回true，否则返回false</returns>
	public bool TryTakeLast(out T result)
	{
		return TryTake(-1, out result);
	}

	/// <summary>
	/// 同步对象清理
	/// </summary>
	/// <param name="disposing"></param>
	protected override void DisposeSync(bool disposing)
	{
		if (list.IsNotNull())
		{
			list.Clear();
		}
		base.DisposeSync(disposing);
	}
}
