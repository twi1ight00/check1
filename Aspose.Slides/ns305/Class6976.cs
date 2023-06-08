using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using ns304;

namespace ns305;

internal abstract class Class6976 : Interface362
{
	protected class Class7055
	{
		private readonly string string_0;

		private object object_0;

		private Interface374 interface374_0;

		public string Key => string_0;

		public object UserData
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		public Interface374 Handler
		{
			get
			{
				return interface374_0;
			}
			set
			{
				interface374_0 = value;
			}
		}

		public Class7055(string key, object userData, Interface374 handler)
		{
			string_0 = key;
			object_0 = userData;
			interface374_0 = handler;
		}
	}

	[CompilerGenerated]
	private sealed class Class7056
	{
		public string string_0;

		public bool method_0(Class7055 entry)
		{
			return entry.Key == string_0;
		}
	}

	private Class6976 class6976_0;

	private Class6976 class6976_1;

	private List<Class7055> list_0;

	private readonly object object_0 = new object();

	private readonly Collection<Class7061> collection_0;

	private readonly object object_1 = new object();

	public abstract string NodeName { get; }

	public virtual string NodeValue
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public abstract Enum969 NodeType { get; }

	public Class6976 ParentNode => class6976_0;

	public Class7075 ChildNodes => new Class7085(this);

	public Class6976 FirstChild => LastNode?.class6976_1;

	public Class6976 LastChild => LastNode;

	public Class6976 PreviousSibling
	{
		get
		{
			Class6976 parentNode = ParentNode;
			if (parentNode == null)
			{
				return null;
			}
			Class6976 @class = parentNode.FirstChild;
			while (true)
			{
				if (@class != null)
				{
					Class6976 nextSibling = @class.NextSibling;
					if (nextSibling == this)
					{
						break;
					}
					@class = nextSibling;
					continue;
				}
				return @class;
			}
			return @class;
		}
	}

	public Class6976 NextSibling
	{
		get
		{
			Class6976 parentNode = ParentNode;
			if (parentNode != null && class6976_1 != parentNode.FirstChild)
			{
				return class6976_1;
			}
			return null;
		}
	}

	public virtual Class7063 Attributes => null;

	public Class7046 OwnerDocument
	{
		get
		{
			if (NodeType == Enum969.const_8)
			{
				return (Class7046)this;
			}
			return ParentNode.OwnerDocument;
		}
	}

	public virtual string NamespaceURI => null;

	public virtual string Prefix
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual string LocalName => null;

	public virtual string BaseURI => OwnerDocument.BaseURI;

	public virtual string TextContent
	{
		get
		{
			if (NodeType != Enum969.const_7 && NodeType != Enum969.const_6)
			{
				if (NodeType != Enum969.const_8 && NodeType != Enum969.const_9 && NodeType != Enum969.const_11)
				{
					Class6976 @class = FirstChild;
					if (@class == null)
					{
						return string.Empty;
					}
					StringBuilder stringBuilder = new StringBuilder();
					while (@class != null)
					{
						if (@class.NodeType == Enum969.const_3 || @class.NodeType == Enum969.const_2 || @class.NodeType == Enum969.const_0)
						{
							stringBuilder.Append(@class.TextContent);
						}
						@class = @class.NextSibling;
					}
					return stringBuilder.ToString();
				}
				return null;
			}
			return NodeValue;
		}
		set
		{
			Class6976 firstChild = FirstChild;
			if (firstChild != null && firstChild.NextSibling == null && firstChild.NodeType == Enum969.const_2)
			{
				firstChild.TextContent = value;
				return;
			}
			method_16();
			vmethod_1(OwnerDocument.method_21(value));
		}
	}

	internal virtual Class6976 LastNode
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	protected List<Class7055> UserData
	{
		get
		{
			if (list_0 == null)
			{
				lock (object_0)
				{
					if (list_0 == null)
					{
						list_0 = new List<Class7055>();
					}
				}
			}
			return list_0;
		}
	}

	internal Class6976()
	{
		collection_0 = new Collection<Class7061>();
	}

	internal Class6976(Class7046 document)
	{
		if (document == null)
		{
			throw new ArgumentException();
		}
		collection_0 = new Collection<Class7061>();
		class6976_0 = document;
	}

	public Class6976 method_0(Class6976 newChild, Class6976 refChild)
	{
		if (this != newChild && !method_15(newChild))
		{
			if (refChild == null)
			{
				return vmethod_1(newChild);
			}
			if (refChild.ParentNode != this)
			{
				throw new ArgumentException();
			}
			if (newChild == refChild)
			{
				return newChild;
			}
			Class7046 ownerDocument = newChild.OwnerDocument;
			Class7046 ownerDocument2 = OwnerDocument;
			if (ownerDocument != null && ownerDocument != ownerDocument2)
			{
				throw new ArgumentException();
			}
			if (newChild.ParentNode != null)
			{
				newChild.ParentNode.method_2(newChild);
			}
			if (refChild == FirstChild)
			{
				newChild.class6976_1 = refChild;
				LastNode.class6976_1 = newChild;
				newChild.vmethod_4(this);
			}
			else
			{
				Class6976 previousSibling = refChild.PreviousSibling;
				newChild.class6976_1 = refChild;
				previousSibling.class6976_1 = newChild;
				newChild.vmethod_4(this);
			}
			return newChild;
		}
		throw new ArgumentException();
	}

	public virtual Class6976 vmethod_0(Class6976 newChild, Class6976 refChild)
	{
		if (this != newChild && !method_15(newChild))
		{
			if (refChild == null)
			{
				return vmethod_1(newChild);
			}
			if (refChild.ParentNode != this)
			{
				throw new ArgumentException();
			}
			if (newChild == refChild)
			{
				return newChild;
			}
			Class7046 ownerDocument = newChild.OwnerDocument;
			Class7046 ownerDocument2 = OwnerDocument;
			if (ownerDocument != null && ownerDocument != ownerDocument2)
			{
				throw new ArgumentException();
			}
			if (newChild.ParentNode != null)
			{
				newChild.ParentNode.method_2(newChild);
			}
			if (refChild == LastNode)
			{
				Class6976 firstChild = FirstChild;
				refChild.class6976_1 = newChild;
				newChild.class6976_1 = firstChild;
				LastNode = newChild;
				newChild.vmethod_4(this);
			}
			else
			{
				Class6976 @class = refChild.class6976_1;
				refChild.class6976_1 = newChild;
				newChild.class6976_1 = @class;
				newChild.vmethod_4(this);
			}
			return newChild;
		}
		throw new ArgumentException();
	}

	public Class6976 method_1(Class6976 newChild, Class6976 oldChild)
	{
		Class6976 nextSibling = oldChild.NextSibling;
		method_2(oldChild);
		method_0(newChild, nextSibling);
		return oldChild;
	}

	public Class6976 method_2(Class6976 oldChild)
	{
		if (oldChild.ParentNode != this)
		{
			throw new ArgumentException();
		}
		if (oldChild == FirstChild)
		{
			if (oldChild == LastNode)
			{
				LastNode = null;
			}
			else
			{
				LastNode.class6976_1 = oldChild.class6976_1;
			}
		}
		else if (oldChild == LastNode)
		{
			Class6976 previousSibling = oldChild.PreviousSibling;
			previousSibling.class6976_1 = oldChild.class6976_1;
			LastNode = previousSibling;
		}
		else if (oldChild.PreviousSibling != null)
		{
			Class6976 previousSibling2 = oldChild.PreviousSibling;
			previousSibling2.class6976_1 = oldChild.class6976_1;
		}
		oldChild.class6976_1 = null;
		oldChild.vmethod_4(null);
		return oldChild;
	}

	public virtual Class6976 vmethod_1(Class6976 newChild)
	{
		if (this != newChild && !method_15(newChild))
		{
			if (newChild.ParentNode != null)
			{
				newChild.ParentNode.method_2(newChild);
			}
			Class7046 @class = newChild as Class7046;
			Class7046 ownerDocument = OwnerDocument;
			if (@class != null && @class != ownerDocument)
			{
				throw new ArgumentException();
			}
			Class6976 lastNode = LastNode;
			if (lastNode == null)
			{
				newChild.class6976_1 = newChild;
				LastNode = newChild;
				newChild.vmethod_4(this);
			}
			else
			{
				newChild.class6976_1 = lastNode.class6976_1;
				lastNode.class6976_1 = newChild;
				LastNode = newChild;
				newChild.vmethod_4(this);
			}
			return newChild;
		}
		throw new ArgumentException();
	}

	public bool method_3()
	{
		return LastNode != null;
	}

	public abstract Class6976 vmethod_2(bool deep);

	public void method_4()
	{
		throw new NotImplementedException();
	}

	public bool method_5(string feature, string version)
	{
		return OwnerDocument.method_5(feature, version);
	}

	public bool method_6()
	{
		if (Attributes != null)
		{
			return Attributes.Length != 0;
		}
		return false;
	}

	public Enum967 method_7(Class6976 other)
	{
		throw new NotImplementedException();
	}

	public virtual bool vmethod_3(Class6976 other)
	{
		return object.ReferenceEquals(this, other);
	}

	public string method_8(string namespaceURI)
	{
		return OwnerDocument.NamespaceManager.LookupPrefix(namespaceURI);
	}

	public bool method_9(string namespaceURI)
	{
		return OwnerDocument.NamespaceManager.DefaultNamespace == namespaceURI;
	}

	public string method_10(string prefix)
	{
		return OwnerDocument.NamespaceManager.LookupNamespace(prefix);
	}

	public bool method_11(Class6976 arg)
	{
		return vmethod_3(arg);
	}

	public object method_12(string feature, string version)
	{
		return OwnerDocument.method_12(feature, version);
	}

	public object method_13(string key, object data, Interface374 handler)
	{
		int num = method_17(key);
		if (num == -1)
		{
			UserData.Add(new Class7055(key, data, handler));
			return null;
		}
		Class7055 @class = UserData[num];
		UserData[num] = new Class7055(key, data, handler);
		return @class.UserData;
	}

	public object method_14(string key)
	{
		int num = method_17(key);
		if (num != -1)
		{
			return UserData[num].UserData;
		}
		return null;
	}

	internal bool method_15(Class6976 node)
	{
		Class6976 parentNode = ParentNode;
		while (true)
		{
			if (parentNode != null)
			{
				if (parentNode == node)
				{
					break;
				}
				parentNode = parentNode.ParentNode;
				continue;
			}
			return false;
		}
		return true;
	}

	internal virtual void vmethod_4(Class6976 node)
	{
		class6976_0 = node;
	}

	public void method_16()
	{
		Class6976 @class = FirstChild;
		while (@class != null)
		{
			Class6976 nextSibling = @class.NextSibling;
			method_2(@class);
			@class = nextSibling;
		}
	}

	private int method_17(string key)
	{
		return UserData.FindIndex((Class7055 entry) => entry.Key == key);
	}

	internal static void smethod_0(string name, out string prefix, out string localName)
	{
		int num = name.IndexOf(':');
		if (-1 != num && num != 0 && name.Length - 1 != num)
		{
			prefix = name.Substring(0, num);
			localName = name.Substring(num + 1);
		}
		else
		{
			prefix = string.Empty;
			localName = name;
		}
	}

	public override string ToString()
	{
		return $"{NodeName}, Value=\"{NodeValue}\"";
	}

	public virtual void imethod_0(string type, Interface365 listener, bool useCapture)
	{
		lock (object_1)
		{
			Class7061 item = new Class7061(type, listener, useCapture);
			if (!collection_0.Contains(item))
			{
				collection_0.Add(item);
			}
		}
	}

	public virtual bool imethod_1(Interface363 @event)
	{
		Class7060 @class = new Class7060(this, (Class7059)@event, Enum962.const_2);
		@class.method_2();
		return !@class.DefaultActionPrevented;
	}

	public virtual void imethod_2(string type, Interface365 listener, bool useCapture)
	{
		lock (object_1)
		{
			Class7061 item = new Class7061(type, listener, useCapture);
			if (collection_0.Contains(item))
			{
				collection_0.Remove(item);
			}
		}
	}

	internal ICollection<Interface365> method_18(Interface363 @event, Enum962 direction)
	{
		lock (object_1)
		{
			Collection<Interface365> collection = new Collection<Interface365>();
			foreach (Class7061 item in collection_0)
			{
				if (item.EventType.Equals(@event.Type) && (direction == Enum962.const_2 || (item.CaptureProcessingMethod && direction == Enum962.const_1) || (!item.CaptureProcessingMethod && direction == Enum962.const_0)))
				{
					collection.Add(item.Listener);
				}
			}
			return collection;
		}
	}

	internal bool method_19(Interface363 @event)
	{
		lock (object_1)
		{
			foreach (Class7061 item in collection_0)
			{
				if (item.EventType.Equals(@event.Type))
				{
					return true;
				}
			}
		}
		return false;
	}
}
