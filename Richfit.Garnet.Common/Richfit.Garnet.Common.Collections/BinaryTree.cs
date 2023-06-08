using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Richfit.Garnet.Common.Collections;

/// <summary>
/// 二叉树排序
/// </summary>
/// <typeparam name="T">节点元素类型</typeparam>
public class BinaryTree<T> : ICollection<T>, IEnumerable<T>, IEnumerable where T : IComparable<T>
{
	/// <summary>
	/// 二叉树节点
	/// </summary>
	public class TreeNode
	{
		/// <summary>
		/// Value of the node
		/// </summary>
		public virtual T Value { get; set; }

		/// <summary>
		/// Parent node
		/// </summary>
		public virtual TreeNode Parent { get; set; }

		/// <summary>
		/// Left node
		/// </summary>
		public virtual TreeNode Left { get; set; }

		/// <summary>
		/// Right node
		/// </summary>
		public virtual TreeNode Right { get; set; }

		/// <summary>
		/// Is this the root
		/// </summary>
		public virtual bool IsRoot => Parent == null;

		/// <summary>
		/// Is this a leaf
		/// </summary>
		public virtual bool IsLeaf => Left == null && Right == null;

		/// <summary>
		/// has visited
		/// </summary>
		internal bool Visited { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="value">Value of the node</param>
		/// <param name="parent">Parent node</param>
		/// <param name="left">Left node</param>
		/// <param name="right">Right node</param>
		public TreeNode(T value = default(T), TreeNode parent = null, TreeNode left = null, TreeNode right = null)
		{
			Value = value;
			Right = right;
			Left = left;
			Parent = parent;
		}

		/// <summary>
		/// Convert to string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Value.ToString();
		}
	}

	/// <summary>
	/// 根节点
	/// </summary>
	public virtual TreeNode Root { get; set; }

	/// <summary>
	/// 树中节点数量
	/// </summary>
	protected virtual int NumberOfNodes { get; set; }

	/// <summary>
	/// 是否为空
	/// </summary>
	public virtual bool IsEmpty => Root == null;

	/// <summary>
	/// 获得最小值
	/// </summary>
	public virtual T MinValue
	{
		get
		{
			if (IsEmpty)
			{
				throw new Exception("The tree is empty");
			}
			TreeNode tempNode = Root;
			while (tempNode.Left != null)
			{
				tempNode = tempNode.Left;
			}
			return tempNode.Value;
		}
	}

	/// <summary>
	/// 获得最大值
	/// </summary>
	public virtual T MaxValue
	{
		get
		{
			if (IsEmpty)
			{
				throw new Exception("The tree is empty");
			}
			TreeNode tempNode = Root;
			while (tempNode.Right != null)
			{
				tempNode = tempNode.Right;
			}
			return tempNode.Value;
		}
	}

	/// <summary>
	/// 获取节点数量
	/// </summary>
	public virtual int Count => NumberOfNodes;

	/// <summary>
	/// 获取树是否为只读
	/// </summary>
	public virtual bool IsReadOnly => false;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="root">根节点</param>
	public BinaryTree(TreeNode root = null)
	{
		if (root == null)
		{
			NumberOfNodes = 0;
			return;
		}
		Root = root;
		foreach (TreeNode node in Traversal(root))
		{
			NumberOfNodes++;
		}
	}

	/// <summary>
	/// 获取枚举器
	/// </summary>
	/// <returns></returns>
	public virtual IEnumerator<T> GetEnumerator()
	{
		foreach (TreeNode tempNode in Traversal(Root))
		{
			yield return tempNode.Value;
		}
	}

	/// <summary>
	/// 获取枚举器
	/// </summary>
	/// <returns></returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		foreach (TreeNode tempNode in Traversal(Root))
		{
			yield return tempNode.Value;
		}
	}

	/// <summary>
	/// 添加某值
	/// </summary>
	/// <param name="item"></param>
	public virtual void Add(T item)
	{
		if (Root == null)
		{
			Root = new TreeNode(item);
			NumberOfNodes++;
		}
		else
		{
			Insert(item);
		}
	}

	/// <summary>
	/// 清除所有值
	/// </summary>
	public virtual void Clear()
	{
		Root = null;
		NumberOfNodes = 0;
	}

	/// <summary>
	/// 是否包含某值
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	public virtual bool Contains(T item)
	{
		if (IsEmpty)
		{
			return false;
		}
		TreeNode tempNode = Root;
		while (tempNode != null)
		{
			int comparedValue = tempNode.Value.CompareTo(item);
			if (comparedValue == 0)
			{
				return true;
			}
			tempNode = ((comparedValue >= 0) ? tempNode.Right : tempNode.Left);
		}
		return false;
	}

	/// <summary>
	/// 拷贝到值数组中
	/// </summary>
	/// <param name="array"></param>
	/// <param name="arrayIndex"></param>
	public virtual void CopyTo(T[] array, int arrayIndex)
	{
		T[] tempArray = new T[NumberOfNodes];
		int counter = 0;
		using (IEnumerator<T> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T value = enumerator.Current;
				tempArray[counter] = value;
				counter++;
			}
		}
		Array.Copy(tempArray, 0, array, arrayIndex, NumberOfNodes);
	}

	/// <summary>
	/// 移除某值
	/// </summary>
	/// <param name="item"></param>
	/// <returns></returns>
	public virtual bool Remove(T item)
	{
		TreeNode node = Find(item);
		if (node == null)
		{
			return false;
		}
		NumberOfNodes--;
		List<T> values = new List<T>();
		foreach (TreeNode tempNode in Traversal(node.Left))
		{
			values.Add(tempNode.Value);
		}
		foreach (TreeNode tempNode in Traversal(node.Right))
		{
			values.Add(tempNode.Value);
		}
		if (node.Parent != null)
		{
			if (node.Parent.Left == node)
			{
				node.Parent.Left = null;
			}
			else
			{
				node.Parent.Right = null;
			}
			node.Parent = null;
		}
		else
		{
			Root = null;
		}
		foreach (T value in values)
		{
			Add(value);
		}
		return true;
	}

	/// <summary>
	/// 查询特定的值
	/// </summary>
	/// <param name="item">The item to find</param>
	/// <returns>The node if it is found</returns>
	protected virtual TreeNode Find(T item)
	{
		foreach (TreeNode node in Traversal(Root))
		{
			if (node.Value.Equals(item))
			{
				return node;
			}
		}
		return null;
	}

	/// <summary>
	/// 遍历节点
	/// </summary>
	/// <param name="node">检索起始节点</param>
	/// <returns>树中节点的集合</returns>
	protected virtual IEnumerable<TreeNode> Traversal(TreeNode node)
	{
		if (node == null)
		{
			yield break;
		}
		if (node.Left != null)
		{
			foreach (TreeNode item in Traversal(node.Left))
			{
				yield return item;
			}
		}
		yield return node;
		if (node.Right == null)
		{
			yield break;
		}
		foreach (TreeNode item2 in Traversal(node.Right))
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 二叉树中插入一个值
	/// </summary>
	/// <param name="item">item to insert</param>
	protected virtual void Insert(T item)
	{
		TreeNode tempNode = Root;
		bool hasFound = false;
		while (!hasFound)
		{
			int comparedValue = tempNode.Value.CompareTo(item);
			if (comparedValue > 0)
			{
				if (tempNode.Left == null)
				{
					tempNode.Left = new TreeNode(item, tempNode);
					NumberOfNodes++;
					break;
				}
				tempNode = tempNode.Left;
			}
			else if (comparedValue < 0)
			{
				if (tempNode.Right == null)
				{
					tempNode.Right = new TreeNode(item, tempNode);
					NumberOfNodes++;
					break;
				}
				tempNode = tempNode.Right;
			}
			else
			{
				tempNode = tempNode.Right;
			}
		}
	}

	/// <summary>
	/// 转化为字符串，每一项中间用" "分割
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		StringBuilder buff = new StringBuilder();
		using (IEnumerator<T> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				buff.Append(enumerator.Current.ToString() + " ");
			}
		}
		return buff.ToString();
	}
}
