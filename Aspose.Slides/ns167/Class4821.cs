using System;
using System.Collections;
using ns166;

namespace ns167;

internal class Class4821
{
	private class Class4822 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Left, value2.BoundingBox.Left))
					{
						return 0;
					}
					if (value.BoundingBox.Left < value2.BoundingBox.Left)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4823 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Right, value2.BoundingBox.Right))
					{
						return 0;
					}
					if (value.BoundingBox.Right < value2.BoundingBox.Right)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4824 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Right, value2.BoundingBox.Right))
					{
						return 0;
					}
					if (value.BoundingBox.Right < value2.BoundingBox.Right)
					{
						return 1;
					}
					return -1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4825 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.GeometricCenter.X, value2.GeometricCenter.X))
					{
						return 0;
					}
					if (value.GeometricCenter.X < value2.GeometricCenter.X)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4826 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Top, value2.BoundingBox.Top))
					{
						return 0;
					}
					if (value.BoundingBox.Top < value2.BoundingBox.Top)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4827 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Bottom, value2.BoundingBox.Bottom))
					{
						return 0;
					}
					if (value.BoundingBox.Bottom < value2.BoundingBox.Bottom)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4828 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Bottom, value2.BoundingBox.Bottom))
					{
						return 0;
					}
					if (value.BoundingBox.Bottom < value2.BoundingBox.Bottom)
					{
						return 1;
					}
					return -1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4829 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.MassCenter.X, value2.MassCenter.X))
					{
						return 0;
					}
					if (value.MassCenter.X < value2.MassCenter.X)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4830 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.MassCenter.Y, value2.MassCenter.Y))
					{
						return 0;
					}
					if (value.MassCenter.Y < value2.MassCenter.Y)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4831 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					float num = value.BoundingBox.Width * value.BoundingBox.Height;
					float num2 = value2.BoundingBox.Width * value2.BoundingBox.Height;
					if (Class4778.smethod_0(num, num2))
					{
						return 0;
					}
					if (num < num2)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4832 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					float num = value.BoundingBox.Width * value.BoundingBox.Height;
					float num2 = value2.BoundingBox.Width * value2.BoundingBox.Height;
					if (Class4778.smethod_0(num, num2))
					{
						return 0;
					}
					if (num < num2)
					{
						return 1;
					}
					return -1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4833 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Height, value2.BoundingBox.Height))
					{
						return 0;
					}
					if (value.BoundingBox.Height < value2.BoundingBox.Height)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4834 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Height, value2.BoundingBox.Height))
					{
						return 0;
					}
					if (value.BoundingBox.Height < value2.BoundingBox.Height)
					{
						return 1;
					}
					return -1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4835 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Width, value2.BoundingBox.Width))
					{
						return 0;
					}
					if (value.BoundingBox.Width < value2.BoundingBox.Width)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4836 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.BoundingBox.Width, value2.BoundingBox.Width))
					{
						return 0;
					}
					if (value.BoundingBox.Width < value2.BoundingBox.Width)
					{
						return 1;
					}
					return -1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4837 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (!value.BoundingBox.IsEmpty && !value2.BoundingBox.IsEmpty)
					{
						float num = value.BoundingBox.Width / value.BoundingBox.Height;
						float num2 = value2.BoundingBox.Width / value2.BoundingBox.Height;
						if (Class4778.smethod_0(num, num2))
						{
							return 0;
						}
						if (num < num2)
						{
							return 1;
						}
						return -1;
					}
					throw new ArgumentException("Please report exception. Empty bounding box found for PageElement instance.");
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4838 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (!value.BoundingBox.IsEmpty && !value2.BoundingBox.IsEmpty)
					{
						float num = value.BoundingBox.Width / value.BoundingBox.Height;
						float num2 = value2.BoundingBox.Width / value2.BoundingBox.Height;
						if (Class4778.smethod_0(num, num2))
						{
							return 0;
						}
						if (num < num2)
						{
							return -1;
						}
						return 1;
					}
					throw new ArgumentException("Please report exception. Empty bounding box found for PageElement instance.");
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4839 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.Origin.Y, value2.Origin.Y))
					{
						if (Class4778.smethod_0(value.Origin.X, value2.Origin.X))
						{
							return 0;
						}
						float num = value.Origin.X - value2.Origin.X;
						if (num < 0f)
						{
							return -1;
						}
						return 1;
					}
					float num2 = value.Origin.Y - value2.Origin.Y;
					if (num2 < 0f)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4840 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.Compactness, value2.Compactness))
					{
						return 0;
					}
					if (value.Compactness < value2.Compactness)
					{
						return -1;
					}
					return 1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	private class Class4841 : IComparer
	{
		public int Compare(object a, object b)
		{
			Class4845 @class = a as Class4845;
			Class4845 class2 = b as Class4845;
			if (!(@class == null) && !(class2 == null))
			{
				Class4779 value = @class.Value;
				Class4779 value2 = class2.Value;
				if (!(value is Class4789) && !(value2 is Class4789))
				{
					if (Class4778.smethod_0(value.Compactness, value2.Compactness))
					{
						return 0;
					}
					if (value.Compactness < value2.Compactness)
					{
						return 1;
					}
					return -1;
				}
				return 0;
			}
			throw new ArgumentException("Please report exception. Could not sort PlanePointerCollection.");
		}
	}

	internal static IComparer smethod_0(Enum673 dimension)
	{
		return dimension switch
		{
			Enum673.const_0 => new Class4839(), 
			Enum673.const_1 => new Class4826(), 
			Enum673.const_2 => new Class4827(), 
			Enum673.const_3 => new Class4822(), 
			Enum673.const_4 => new Class4823(), 
			Enum673.const_5 => new Class4825(), 
			Enum673.const_6 => new Class4829(), 
			Enum673.const_7 => new Class4830(), 
			Enum673.const_8 => new Class4833(), 
			Enum673.const_9 => new Class4835(), 
			Enum673.const_10 => new Class4831(), 
			Enum673.const_11 => new Class4837(), 
			Enum673.const_12 => new Class4840(), 
			_ => throw new InvalidOperationException("Please report exception. Comparer not implemented."), 
		};
	}

	internal static IComparer smethod_1(Enum673 dimension)
	{
		return dimension switch
		{
			Enum673.const_2 => new Class4828(), 
			Enum673.const_4 => new Class4824(), 
			Enum673.const_8 => new Class4834(), 
			Enum673.const_9 => new Class4836(), 
			Enum673.const_10 => new Class4832(), 
			Enum673.const_11 => new Class4838(), 
			Enum673.const_12 => new Class4841(), 
			_ => throw new InvalidOperationException("Please report exception. Reverse order comparer not implemented."), 
		};
	}
}
