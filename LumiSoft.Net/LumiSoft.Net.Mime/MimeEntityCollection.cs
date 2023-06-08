using System;
using System.Collections;

namespace LumiSoft.Net.Mime;

public class MimeEntityCollection : IEnumerable
{
	private MimeEntity m_pOwnerEntity = null;

	private ArrayList m_pEntities = null;

	public MimeEntity this[int index] => (MimeEntity)m_pEntities[index];

	public int Count => m_pEntities.Count;

	internal MimeEntityCollection(MimeEntity ownerEntity)
	{
		m_pOwnerEntity = ownerEntity;
		m_pEntities = new ArrayList();
	}

	public MimeEntity Add()
	{
		MimeEntity mimeEntity = new MimeEntity();
		Add(mimeEntity);
		return mimeEntity;
	}

	public void Add(MimeEntity entity)
	{
		if ((m_pOwnerEntity.ContentType & MediaType_enum.Multipart) == 0)
		{
			throw new Exception("You don't have Content-Type: multipart/xxx. Only Content-Type: multipart/xxx can have nested mime entities !");
		}
		if (m_pOwnerEntity.ContentType_Boundary == null || m_pOwnerEntity.ContentType_Boundary.Length == 0)
		{
			throw new Exception("Please specify Boundary property first !");
		}
		m_pEntities.Add(entity);
	}

	public void Insert(int index, MimeEntity entity)
	{
		if ((m_pOwnerEntity.ContentType & MediaType_enum.Multipart) == 0)
		{
			throw new Exception("You don't have Content-Type: multipart/xxx. Only Content-Type: multipart/xxx can have nested mime entities !");
		}
		if (m_pOwnerEntity.ContentType_Boundary == null || m_pOwnerEntity.ContentType_Boundary.Length == 0)
		{
			throw new Exception("Please specify Boundary property first !");
		}
		m_pEntities.Insert(index, entity);
	}

	public void Remove(int index)
	{
		m_pEntities.RemoveAt(index);
	}

	public void Remove(MimeEntity entity)
	{
		m_pEntities.Remove(entity);
	}

	public void Clear()
	{
		m_pEntities.Clear();
	}

	public bool Contains(MimeEntity entity)
	{
		return m_pEntities.Contains(entity);
	}

	public IEnumerator GetEnumerator()
	{
		return m_pEntities.GetEnumerator();
	}
}
