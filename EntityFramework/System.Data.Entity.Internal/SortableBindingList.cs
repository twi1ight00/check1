using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Linq;

namespace System.Data.Entity.Internal;

/// <summary>
///     An extended BindingList implementation that implements sorting.
///     This class was adapted from the LINQ to SQL class of the same name.
/// </summary>
/// <typeparam name="T">The element type.</typeparam>
internal class SortableBindingList<T> : BindingList<T>
{
	/// <summary>
	///     Implements comparing for the <see cref="T:System.Data.Entity.Internal.SortableBindingList`1" /> implementation.
	/// </summary>
	internal class PropertyComparer : Comparer<T>
	{
		private readonly IComparer _comparer;

		private readonly ListSortDirection _direction;

		private readonly PropertyDescriptor _prop;

		private readonly bool _useToString;

		/// <summary>
		///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.SortableBindingList`1.PropertyComparer" /> class
		///     for sorting the list.
		/// </summary>
		/// <param name="prop">The property to sort by.</param>
		/// <param name="direction">The sort direction.</param>
		public PropertyComparer(PropertyDescriptor prop, ListSortDirection direction)
		{
			if (!prop.ComponentType.IsAssignableFrom(typeof(T)))
			{
				throw new MissingMemberException(typeof(T).Name, prop.Name);
			}
			_prop = prop;
			_direction = direction;
			if (CanSortWithIComparable(prop.PropertyType))
			{
				PropertyInfo property = typeof(Comparer<>).MakeGenericType(prop.PropertyType).GetProperty("Default");
				_comparer = (IComparer)property.GetValue(null, null);
				_useToString = false;
			}
			else
			{
				_comparer = StringComparer.CurrentCultureIgnoreCase;
				_useToString = true;
			}
		}

		/// <summary>
		///     Compares two instances of items in the list.
		/// </summary>
		/// <param name="left">The left item to compare.</param>
		/// <param name="right">The right item to compare.</param>
		/// <returns></returns>
		public override int Compare(T left, T right)
		{
			object obj = _prop.GetValue(left);
			object obj2 = _prop.GetValue(right);
			if (_useToString)
			{
				obj = obj?.ToString();
				obj2 = obj2?.ToString();
			}
			if (_direction != 0)
			{
				return _comparer.Compare(obj2, obj);
			}
			return _comparer.Compare(obj, obj2);
		}

		/// <summary>
		///     Determines whether this instance can sort for the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>
		///     <c>true</c> if this instance can sort for the specified type; otherwise, <c>false</c>.
		/// </returns>
		public static bool CanSort(Type type)
		{
			if (!CanSortWithToString(type))
			{
				return CanSortWithIComparable(type);
			}
			return true;
		}

		/// <summary>
		///     Determines whether this instance can sort for the specified type using IComparable.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>
		///     <c>true</c> if this instance can sort for the specified type; otherwise, <c>false</c>.
		/// </returns>
		private static bool CanSortWithIComparable(Type type)
		{
			if (!(type.GetInterface("IComparable") != null))
			{
				if (type.IsGenericType)
				{
					return type.GetGenericTypeDefinition() == typeof(Nullable<>);
				}
				return false;
			}
			return true;
		}

		/// <summary>
		///     Determines whether this instance can sort for the specified type using ToString.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>
		///     <c>true</c> if this instance can sort for the specified type; otherwise, <c>false</c>.
		/// </returns>
		private static bool CanSortWithToString(Type type)
		{
			if (!type.Equals(typeof(XNode)))
			{
				return type.IsSubclassOf(typeof(XNode));
			}
			return true;
		}
	}

	private bool _isSorted;

	private ListSortDirection _sortDirection;

	private PropertyDescriptor _sortProperty;

	/// <summary>
	///     Gets a value indicating whether this list is sorted.
	/// </summary>
	/// <value>
	///     <c>true</c> if this instance is sorted; otherwise, <c>false</c>.
	/// </value>
	protected override bool IsSortedCore => _isSorted;

	/// <summary>
	///     Gets the sort direction.
	/// </summary>
	/// <value>The sort direction.</value>
	protected override ListSortDirection SortDirectionCore => _sortDirection;

	/// <summary>
	///     Gets the sort property being used to sort.
	/// </summary>
	/// <value>The sort property.</value>
	protected override PropertyDescriptor SortPropertyCore => _sortProperty;

	/// <summary>
	///     Returns <c>true</c> indicating that this list supports sorting.
	/// </summary>
	/// <value><c>true</c>.</value>
	protected override bool SupportsSortingCore => true;

	/// <summary>
	///     Initializes a new instance of the <see cref="T:System.Data.Entity.Internal.SortableBindingList`1" /> class with the
	///     the given underlying list.  Note that sorting is dependent on having an actual <see cref="T:System.Collections.Generic.List`1" />
	///     rather than some other ICollection implementation.
	/// </summary>
	/// <param name="list">The list.</param>
	public SortableBindingList(List<T> list)
		: base((IList<T>)list)
	{
	}

	/// <summary>
	///     Applies sorting to the list.
	/// </summary>
	/// <param name="prop">The property to sort by.</param>
	/// <param name="direction">The sort direction.</param>
	protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
	{
		if (PropertyComparer.CanSort(prop.PropertyType))
		{
			((List<T>)base.Items).Sort(new PropertyComparer(prop, direction));
			_sortDirection = direction;
			_sortProperty = prop;
			_isSorted = true;
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}
	}

	/// <summary>
	///     Stops sorting.
	/// </summary>
	protected override void RemoveSortCore()
	{
		_isSorted = false;
		_sortProperty = null;
	}
}
