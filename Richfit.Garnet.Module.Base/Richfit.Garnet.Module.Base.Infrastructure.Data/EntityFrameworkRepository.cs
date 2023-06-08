#define TRACE
#define DEBUG
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;

namespace Richfit.Garnet.Module.Base.Infrastructure.Data;

/// <summary>
/// EntityFramework仓储实现
/// </summary>
/// <typeparam name="TEntity">仓储操作的数据实体类型；数据实体类型都继承于 <see cref="T:Richfit.Garnet.Module.Base.Domain.Entity" />。</typeparam>
public class EntityFrameworkRepository<TEntity> : Repository<TEntity> where TEntity : Entity
{
	/// <summary>
	/// 异常日志对象
	/// </summary>
	private static readonly ILogger exceptionLogger = LoggerManager.GetLogger("Exception");

	/// <summary>
	/// 当前数据库上下文对象
	/// </summary>
	private DBContextBase dbContext;

	/// <summary>
	/// 构造 Entity Framework 仓储实例
	/// </summary>
	/// <param name="efUnitOfWork">仓储使用的数据库上下文</param>
	/// <remarks>
	/// 参数 <paramref name="efUnitOfWork" /> 是固定的，在IOC容器中使用该参数名称注入配置的数据库上下文对象。
	/// </remarks>
	public EntityFrameworkRepository(DBContextBase efUnitOfWork)
		: base((IDBContext)efUnitOfWork)
	{
		efUnitOfWork.GuardNotNull("Database Context");
		dbContext = efUnitOfWork;
		Repository<TEntity>.logger.Debug(typeof(TEntity).ToString() + "-EntityFrameworkRepository实例化成功！");
	}

	/// <inheritdoc />
	protected override void DoAdd(TEntity entity, EntitySchema schema)
	{
		if (entity.IsNotNull())
		{
			schema.GuardNotNull("Entity Schema");
			DoBeforeAdd(entity, schema);
			GetSet().Add(entity);
		}
	}

	/// <inheritdoc />
	protected override void DoAdd(IEnumerable<TEntity> entities, EntitySchema schema)
	{
		if (!entities.IsNotNull() || !entities.Any())
		{
			return;
		}
		schema.GuardNotNull("Entity Schema");
		try
		{
			dbContext.Configuration.AutoDetectChangesEnabled = false;
			foreach (TEntity entity in entities)
			{
				DoAdd(entity, schema);
			}
		}
		finally
		{
			dbContext.Configuration.AutoDetectChangesEnabled = true;
		}
	}

	/// <inheritdoc />
	protected override void DoAddCommit(TEntity entity, EntitySchema schema)
	{
		if (entity.IsNotNull())
		{
			schema.GuardNotNull("Entity Schema");
			DoAdd(entity, schema);
			dbContext.Commit();
		}
	}

	/// <inheritdoc />
	protected override void DoAddCommit(IEnumerable<TEntity> entities, EntitySchema schema)
	{
		if (!entities.IsNotNull() || !entities.Any())
		{
			return;
		}
		schema.GuardNotNull("Entity Schema");
		try
		{
			dbContext.Configuration.AutoDetectChangesEnabled = false;
			foreach (TEntity entity in entities)
			{
				DoAdd(entity, schema);
			}
		}
		finally
		{
			dbContext.Configuration.AutoDetectChangesEnabled = true;
		}
		dbContext.Commit();
	}

	/// <inheritdoc />
	protected override void DoBulkAddCommit(IEnumerable<TEntity> entities, EntitySchema schema = null)
	{
		if (!entities.IsNotNull() || !entities.Any())
		{
			return;
		}
		schema.GuardNotNull("Entity Schema");
		foreach (TEntity entity in entities)
		{
			DoBeforeAdd(entity, schema);
		}
		string sql = GetInsertSql(entities);
		if (dbContext.IsOracle())
		{
			sql = "begin " + sql + " end;";
		}
		ExecuteCommand(sql);
	}

	/// <inheritdoc />
	protected override void DoUpdate(TEntity entity, string[] modifiedChildren, EntitySchema schema)
	{
		if (entity.IsNotNull())
		{
			schema.GuardNotNull("Entity Schema");
			DoBeforeUpdate(entity, modifiedChildren, schema);
			if (Exists(entity))
			{
				dbContext.SetModified(entity);
			}
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = $"类型为{typeof(TEntity)}，主键为{dbContext.GetKeyValue(entity)}的实体被修改！";
			Repository<TEntity>.logger.Info(logEntry.ToJson());
		}
	}

	/// <inheritdoc />
	protected override void DoUpdate(IEnumerable<TEntity> entities, string[] modifiedChildren, EntitySchema schema)
	{
		if (!entities.IsNotNull() || !entities.Any())
		{
			return;
		}
		schema.GuardNotNull("Entity Schema");
		foreach (TEntity entity in entities)
		{
			DoUpdate(entity, modifiedChildren, schema);
		}
	}

	/// <inheritdoc />
	protected override void DoUpdateCommit(TEntity entity, string[] modifiedChildren, EntitySchema schema)
	{
		if (entity.IsNotNull())
		{
			schema.GuardNotNull("Entity Schema");
			DoUpdate(entity, modifiedChildren, schema);
			dbContext.Commit();
		}
	}

	/// <inheritdoc />
	protected override void DoUpdateCommit(IEnumerable<TEntity> entities, string[] modifiedChildren, EntitySchema schema)
	{
		if (!entities.IsNotNull() || !entities.Any())
		{
			return;
		}
		schema.GuardNotNull("Entity Schema");
		foreach (TEntity entity in entities)
		{
			DoUpdate(entity, modifiedChildren, schema);
		}
		dbContext.Commit();
	}

	/// <inheritdoc />
	protected override void DoRemove(TEntity entity)
	{
		if (entity.IsNotNull())
		{
			dbContext.Attach(entity);
			GetSet().Remove(entity);
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = $"类型为{typeof(TEntity)}，主键为{dbContext.GetKeyValue(entity)}的实体被删除！";
			Repository<TEntity>.logger.Info(logEntry.ToJson());
		}
	}

	/// <inheritdoc />
	protected override void DoRemove(IEnumerable<TEntity> entities)
	{
		if (!entities.IsNotNull() || !entities.Any())
		{
			return;
		}
		try
		{
			dbContext.Configuration.AutoDetectChangesEnabled = false;
			foreach (TEntity entity in entities)
			{
				DoRemove(entity);
			}
		}
		finally
		{
			dbContext.Configuration.AutoDetectChangesEnabled = true;
		}
	}

	/// <inheritdoc />
	protected override void DoRemove(string ids, string spliter)
	{
		if (string.IsNullOrWhiteSpace(ids))
		{
			return;
		}
		spliter.GuardNotNull("spliter");
		string[] idList = ids.Split(spliter, removeEmptyEntries: true);
		if (!idList.IsNotNull() || idList.Length <= 0)
		{
			return;
		}
		try
		{
			dbContext.Configuration.AutoDetectChangesEnabled = false;
			string[] array = idList;
			foreach (string id in array)
			{
				Guid guid = Guid.Parse(id);
				TEntity entity = GetSet().Find(guid);
				if (entity.IsNotNull())
				{
					dbContext.Attach(entity);
					GetSet().Remove(entity);
					SystemLogEntry logEntry = new SystemLogEntry();
					logEntry.Data = $"类型为{typeof(TEntity)}，主键为{id}的实体被删除！";
					Repository<TEntity>.logger.Info(logEntry.ToJson());
				}
			}
		}
		finally
		{
			dbContext.Configuration.AutoDetectChangesEnabled = true;
		}
	}

	/// <inheritdoc />
	protected override void DoRemoveCommit(TEntity entity)
	{
		if (entity.IsNotNull())
		{
			DoRemove(entity);
			dbContext.Commit();
		}
	}

	/// <inheritdoc />
	protected override void DoRemoveCommit(IEnumerable<TEntity> entities)
	{
		if (!entities.IsNotNull() || !entities.Any())
		{
			return;
		}
		try
		{
			dbContext.Configuration.AutoDetectChangesEnabled = false;
			foreach (TEntity entity in entities)
			{
				DoRemove(entity);
			}
		}
		finally
		{
			dbContext.Configuration.AutoDetectChangesEnabled = true;
		}
		dbContext.Commit();
	}

	/// <inheritdoc />
	protected override void DoRemoveCommit(string ids, string spliter)
	{
		if (!string.IsNullOrWhiteSpace(ids))
		{
			spliter.GuardNotNull("spliter");
			try
			{
				dbContext.Configuration.AutoDetectChangesEnabled = false;
				DoRemove(ids, spliter);
			}
			finally
			{
				dbContext.Configuration.AutoDetectChangesEnabled = true;
			}
			dbContext.Commit();
		}
	}

	/// <inheritdoc />
	protected override void DoLogicRemove(string ids, string spliter, EntitySchema schema)
	{
		if (string.IsNullOrWhiteSpace(ids))
		{
			return;
		}
		spliter.GuardNotNull("spliter");
		schema.GuardNotNull("Entity Schema");
		string[] idList = ids.Split(spliter, removeEmptyEntries: true);
		if (!idList.IsNotNull() || idList.Length <= 0)
		{
			return;
		}
		try
		{
			dbContext.Configuration.AutoDetectChangesEnabled = false;
			string[] array = idList;
			foreach (string id in array)
			{
				Guid guid = Guid.Parse(id);
				TEntity entity = GetSet().Find(guid);
				if (entity != null)
				{
					entity.SetPropertyValue(schema.IsDel.PropertyName, 1, ignoreCase: false, ignoreMissing: true);
					dbContext.SetModified(entity);
					SystemLogEntry logEntry = new SystemLogEntry();
					logEntry.Data = $"类型为{typeof(TEntity)}，主键为{id}的实体被逻辑删除！";
					Repository<TEntity>.logger.Info(logEntry.ToJson());
				}
			}
		}
		finally
		{
			dbContext.Configuration.AutoDetectChangesEnabled = true;
		}
	}

	/// <inheritdoc />
	protected override void DoLogicRemoveCommit(string ids, string spliter, EntitySchema schema)
	{
		DoLogicRemove(ids, spliter, schema);
		dbContext.Commit();
	}

	/// <inheritdoc />
	protected override TEntity DoGetByKey(object key)
	{
		if (key.IsNotNull())
		{
			return GetLocalTimeEntity(GetSet().Find(key));
		}
		return null;
	}

	/// <inheritdoc />
	protected override bool DoExists(ISpecification<TEntity> specification)
	{
		int count = GetSet().Count(specification.GetExpression());
		return count != 0;
	}

	/// <inheritdoc />
	protected override void DoMerge(TEntity persisted, TEntity current)
	{
		dbContext.ApplyCurrentValues(persisted, current);
	}

	/// <inheritdoc />
	protected override void DoMerge<TObject>(TObject sourceEntity, TObject currentEntity)
	{
		dbContext.ApplyCurrentValues(sourceEntity, currentEntity);
	}

	/// <inheritdoc />
	protected override TEntity DoFind(ISpecification<TEntity> specification)
	{
		IQueryable<TEntity> queryable = GetSet().Where(specification.GetExpression());
		try
		{
			TEntity entity = queryable.FirstOrDefault();
			TraceSql(queryable);
			return GetLocalTimeEntity(entity);
		}
		catch (Exception e)
		{
			LogSql(queryable, e);
			throw;
		}
	}

	/// <inheritdoc />
	protected override TEntity DoFind(ISpecification<TEntity> specification, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		IDbSet<TEntity> dbset = GetSet();
		IQueryable<TEntity> queryable = null;
		if (eagerLoadingProperties != null && eagerLoadingProperties.Length > 0)
		{
			Expression<Func<TEntity, object>> eagerLoadingProperty = eagerLoadingProperties[0];
			string eagerLoadingPath = GetEagerLoadingPath(eagerLoadingProperty);
			IQueryable<TEntity> dbquery = dbset.Include(eagerLoadingPath);
			for (int i = 1; i < eagerLoadingProperties.Length; i++)
			{
				eagerLoadingProperty = eagerLoadingProperties[i];
				eagerLoadingPath = GetEagerLoadingPath(eagerLoadingProperty);
				dbquery = dbquery.Include(eagerLoadingPath);
			}
			queryable = dbquery.Where(specification.GetExpression());
		}
		else
		{
			queryable = dbset.Where(specification.GetExpression());
		}
		try
		{
			TEntity entity = queryable.FirstOrDefault();
			TraceSql(queryable);
			return GetLocalTimeEntity(entity);
		}
		catch (Exception e)
		{
			LogSql(queryable, e);
			throw;
		}
	}

	/// <inheritdoc />
	protected override IList<TEntity> DoFindAll(ISpecification<TEntity> specification, string sortExpress, int pageIndex, int pageSize)
	{
		pageIndex.GuardGreaterThanOrEqualTo(0, "Page Number", "The pageNumber is one-based and should be larger than zero.");
		pageSize.GuardGreaterThan(0, "Page Size", "The pageSize is one-based and should be larger than zero.");
		if (string.IsNullOrWhiteSpace(sortExpress))
		{
			sortExpress = dbContext.GetKeyName<TEntity>();
		}
		IQueryable<TEntity> queryable = GetSet().Where(specification.GetExpression());
		int skip = pageIndex * pageSize;
		if (!string.IsNullOrWhiteSpace(sortExpress))
		{
			queryable = queryable.OrderBy(sortExpress);
		}
		queryable = queryable.Skip(skip).Take(pageSize);
		TraceSql(queryable);
		try
		{
			return GetLocalTimeEntity(queryable.ToList());
		}
		catch (Exception e)
		{
			LogSql(queryable, e);
			throw;
		}
	}

	/// <inheritdoc />
	protected override IList<TEntity> DoFindAll(ISpecification<TEntity> specification, string sortExpress, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		IDbSet<TEntity> dbset = GetSet();
		IQueryable<TEntity> queryable = null;
		if (eagerLoadingProperties.IsNotNull() && eagerLoadingProperties.Length > 0)
		{
			Expression<Func<TEntity, object>> eagerLoadingProperty = eagerLoadingProperties[0];
			string eagerLoadingPath = GetEagerLoadingPath(eagerLoadingProperty);
			IQueryable<TEntity> dbquery = dbset.Include(eagerLoadingPath);
			for (int i = 1; i < eagerLoadingProperties.Length; i++)
			{
				eagerLoadingProperty = eagerLoadingProperties[i];
				eagerLoadingPath = GetEagerLoadingPath(eagerLoadingProperty);
				dbquery = dbquery.Include(eagerLoadingPath);
			}
			queryable = dbquery.Where(specification.GetExpression());
		}
		else
		{
			queryable = dbset.Where(specification.GetExpression());
		}
		if (!string.IsNullOrWhiteSpace(sortExpress))
		{
			queryable = queryable.OrderBy(sortExpress);
		}
		TraceSql(queryable);
		try
		{
			return GetLocalTimeEntity(queryable.ToList());
		}
		catch (Exception e)
		{
			LogSql(queryable, e);
			throw;
		}
	}

	/// <inheritdoc />
	protected override IList<TEntity> DoFindAll(ISpecification<TEntity> specification, string sortExpress, int pageIndex, int pageSize, params Expression<Func<TEntity, dynamic>>[] eagerLoadingProperties)
	{
		pageIndex.GuardGreaterThanOrEqualTo(0, "Page Number", "The pageNumber is one-based and should be larger than zero.");
		pageSize.GuardGreaterThan(0, "Page Size", "The pageSize is one-based and should be larger than zero.");
		if (string.IsNullOrWhiteSpace(sortExpress))
		{
			sortExpress = dbContext.GetKeyName<TEntity>();
		}
		int skip = pageIndex * pageSize;
		IDbSet<TEntity> dbset = GetSet();
		IQueryable<TEntity> queryable = null;
		if (eagerLoadingProperties.IsNotNull() && eagerLoadingProperties.Length > 0)
		{
			Expression<Func<TEntity, object>> eagerLoadingProperty = eagerLoadingProperties[0];
			string eagerLoadingPath = GetEagerLoadingPath(eagerLoadingProperty);
			IQueryable<TEntity> dbquery = dbset.Include(eagerLoadingPath);
			for (int i = 1; i < eagerLoadingProperties.Length; i++)
			{
				eagerLoadingProperty = eagerLoadingProperties[i];
				eagerLoadingPath = GetEagerLoadingPath(eagerLoadingProperty);
				dbquery = dbquery.Include(eagerLoadingPath);
			}
			queryable = dbquery.Where(specification.GetExpression());
		}
		else
		{
			queryable = dbset.Where(specification.GetExpression());
		}
		if (!string.IsNullOrWhiteSpace(sortExpress))
		{
			queryable = queryable.OrderBy(sortExpress);
		}
		queryable = queryable.Skip(skip).Take(pageSize);
		TraceSql(queryable);
		try
		{
			return GetLocalTimeEntity(queryable.ToList());
		}
		catch (Exception e)
		{
			LogSql(queryable, e);
			throw;
		}
	}

	/// <inheritdoc />
	protected override int DoGetCount(ISpecification<TEntity> specification)
	{
		return GetSet().Count(specification.GetExpression());
	}

	/// <inheritdoc />
	protected override void DoAddChild<TChildEntity>(TChildEntity entity)
	{
		dbContext.GetObjectContext().CreateObjectSet<TChildEntity>().AddObject(entity);
	}

	/// <inheritdoc />
	protected override void DoAddChild<TChildEntity>(IEnumerable<TChildEntity> entities)
	{
		entities.GuardNotNull("Entities");
		foreach (TChildEntity entity in entities)
		{
			dbContext.GetObjectContext().CreateObjectSet<TChildEntity>().AddObject(entity);
		}
	}

	/// <inheritdoc />
	protected override void DoRemoveChild<TChildEntity>(TChildEntity entity)
	{
		dbContext.GetObjectContext().DeleteObject(entity);
	}

	/// <inheritdoc />
	protected override void DoRemoveChild<TChildEntity>(IEnumerable<TChildEntity> entities)
	{
		entities = entities.Reverse();
		foreach (TChildEntity entity in entities)
		{
			dbContext.GetObjectContext().DeleteObject(entity);
		}
	}

	/// <inheritdoc />
	protected override void DoReload<TObject>(TObject sourceEntity)
	{
		dbContext.Entry(sourceEntity).Reload();
	}

	/// <summary>
	/// 修改前处理实体
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="modifiedChildren"></param>
	/// <param name="schema"></param>
	private void DoBeforeUpdate(Entity entity, string[] modifiedChildren, EntitySchema schema)
	{
		schema.GuardNotNull("Entity Schema");
		entity.DateTimeToUtc();
		entity.SetUpdateStatus(schema);
		if (!modifiedChildren.IsNotNull() || modifiedChildren.Length <= 0)
		{
			return;
		}
		IEnumerable<PropertyInfo> result = from x in entity.GetType().GetProperties()
			where x.PropertyType.IsType(typeof(IEnumerable<Entity>)) && modifiedChildren.Contains(x.Name)
			select x;
		if (!result.IsNotNull() || !result.Any())
		{
			return;
		}
		result.ForEach(delegate(PropertyInfo r)
		{
			object value = r.GetValue(entity, null);
			if (value.IsNotNull())
			{
				IEnumerable<Entity> source = value as IEnumerable<Entity>;
				source.ForEach(delegate(Entity x)
				{
					if (dbContext.Entry(x).State == EntityState.Modified)
					{
						DoBeforeUpdate(x, modifiedChildren, schema);
					}
					else if (dbContext.Entry(x).State == EntityState.Added)
					{
						DoBeforeAdd(x, schema);
					}
				});
			}
		});
	}

	/// <summary>
	/// 新增之前处理实体
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="schema"></param>
	private void DoBeforeAdd(Entity entity, EntitySchema schema)
	{
		schema.GuardNotNull("Entity Schema");
		entity.DateTimeToUtc();
		GenerateNewIdentity(entity);
		entity.SetAdditionStatus(schema);
		IEnumerable<PropertyInfo> result = from x in entity.GetType().GetProperties()
			where x.PropertyType.IsType(typeof(IEnumerable<Entity>))
			select x;
		if (!result.IsNotNull() || !result.Any())
		{
			return;
		}
		result.ForEach(delegate(PropertyInfo r)
		{
			object value = r.GetValue(entity, null);
			if (value.IsNotNull())
			{
				IEnumerable<Entity> source = value as IEnumerable<Entity>;
				source.ForEach(delegate(Entity x)
				{
					DoBeforeAdd(x, schema);
				});
			}
		});
	}

	/// <inheritdoc />
	protected override void Dispose(bool disposing)
	{
		dbContext = null;
		base.Dispose(disposing);
	}

	private MemberExpression GetMemberInfo(LambdaExpression lambda)
	{
		lambda.GuardNotNull("method");
		MemberExpression memberExpr = null;
		if (lambda.Body.NodeType == ExpressionType.Convert)
		{
			memberExpr = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
		}
		else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
		{
			memberExpr = lambda.Body as MemberExpression;
		}
		memberExpr.GuardNotNull("method");
		return memberExpr;
	}

	private string GetEagerLoadingPath(Expression<Func<TEntity, dynamic>> eagerLoadingProperty)
	{
		MemberExpression memberExpression = GetMemberInfo(eagerLoadingProperty);
		string parameterName = eagerLoadingProperty.Parameters.First().Name;
		string memberExpressionStr = memberExpression.ToString();
		return memberExpressionStr.Replace(parameterName + ".", "");
	}

	/// <summary>
	/// Generate identity for this entity
	/// </summary>
	private void GenerateNewIdentity(Entity entity)
	{
		if (dbContext.IsNewEntity(entity) && dbContext.GetKeyTypeName<TEntity>().IndexOf("Guid") >= 0)
		{
			dbContext.SetKeyValue(entity, IdentityGenerator.NewSequentialGuid());
		}
	}

	private IDbSet<TEntity> GetSet()
	{
		return dbContext.CreateSet<TEntity>();
	}

	/// <summary>
	/// 实体中将DateTime字段的时间从UTC转化为本地时间
	/// </summary>
	/// <param name="entity"></param>
	/// <returns></returns>
	private TEntity GetLocalTimeEntity(TEntity entity)
	{
		if (entity.IsNotNull())
		{
			entity.DateTimeToLocal();
		}
		return entity;
	}

	/// <summary>
	/// 实体中将DateTime字段的时间从UTC转化为本地时间
	/// </summary>
	/// <param name="entitys"></param>
	/// <returns></returns>
	private IList<TEntity> GetLocalTimeEntity(IList<TEntity> entitys)
	{
		if (entitys.IsNotNull() && entitys.Any())
		{
			entitys.ForEachParallel(delegate(TEntity x)
			{
				x.DateTimeToLocal();
			});
		}
		return entitys;
	}

	[Conditional("DEBUG")]
	private void TraceSql(IQueryable<TEntity> queryable)
	{
		if (queryable.IsNotNull())
		{
			string sql = queryable.ToString();
			Trace.WriteLine(sql);
		}
	}

	private void LogSql(IQueryable<TEntity> queryable, Exception e)
	{
		if (queryable.IsNotNull())
		{
			string sql = queryable.ToString();
			SystemLogEntry logEntry = new SystemLogEntry();
			logEntry.Data = sql + "Error:" + e.Message;
			exceptionLogger.Error(logEntry.ToJson());
		}
	}

	/// <summary>
	/// 判断实体在DbContext中是否存在，用于解决更新冲突问题
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	private bool Exists<T>(T entity) where T : Entity
	{
		ObjectContext objContext = dbContext.GetObjectContext();
		ObjectSet<T> objSet = objContext.CreateObjectSet<T>();
		EntityKey entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);
		object foundEntity;
		bool exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
		if (exists && dbContext.Entry(foundEntity).State != EntityState.Modified)
		{
			objContext.Detach(foundEntity);
		}
		return exists;
	}

	/// <summary>
	/// 获取多个实体插入的SQL语句
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="list"></param>
	/// <param name="sqlType"></param>
	/// <returns></returns>
	private string GetInsertSql<TEntity>(IEnumerable<TEntity> entitys) where TEntity : Entity
	{
		StringBuilder sbSql = new StringBuilder();
		entitys.ForEach(delegate(TEntity entity)
		{
			Tuple<string, object[]> tuple = CreateInsertSQL(entity);
			sbSql.AppendFormat(tuple.Item1, tuple.Item2);
		});
		return sbSql.ToString();
	}

	/// <summary>
	/// 构建Insert语句串
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="entity"></param>
	/// <returns></returns>
	private Tuple<string, object[]> CreateInsertSQL<TEntity>(TEntity entity) where TEntity : Entity
	{
		if (entity == null)
		{
			throw new ArgumentException("The database entity can not be null.");
		}
		Type entityType = entity.GetType();
		IEnumerable<PropertyInfo> table = from i in entityType.GetProperties()
			where i.PropertyType != typeof(EntityKey) && i.PropertyType != typeof(EntityState) && i.GetValue(entity, null) != null && (i.PropertyType.IsValueType || i.PropertyType == typeof(string))
			select i;
		string pkName = dbContext.GetKeyName<TEntity>();
		IList<object> arguments = new List<object>();
		StringBuilder fieldbuilder = new StringBuilder();
		StringBuilder valuebuilder = new StringBuilder();
		fieldbuilder.Append(" INSERT INTO " + $"{entityType.Name}" + " (");
		foreach (PropertyInfo member in table)
		{
			object value = member.GetValue(entity, null);
			if (value == null)
			{
				continue;
			}
			if (arguments.Count != 0)
			{
				fieldbuilder.Append(", ");
				valuebuilder.Append(", ");
			}
			fieldbuilder.Append(member.Name);
			if (member.PropertyType == typeof(string) || member.PropertyType == typeof(Guid) || member.PropertyType == typeof(Guid?))
			{
				valuebuilder.Append("'{" + arguments.Count + "}'");
			}
			else if (member.PropertyType == typeof(DateTime))
			{
				if (dbContext.IsOracle())
				{
					valuebuilder.Append("timestamp'{" + arguments.Count + "}'");
				}
				else
				{
					valuebuilder.Append("'{" + arguments.Count + "}'");
				}
			}
			else
			{
				valuebuilder.Append("{" + arguments.Count + "}");
			}
			if (value.GetType() == typeof(string))
			{
				value = value.ToString().Replace("'", "char(39)");
			}
			else if ((member.PropertyType == typeof(Guid) || member.PropertyType == typeof(Guid?)) && dbContext.IsOracle())
			{
				value = ((Guid)value).ToOracleHex();
			}
			arguments.Add(value);
		}
		fieldbuilder.Append(") Values (");
		fieldbuilder.Append(valuebuilder.ToString());
		fieldbuilder.Append(");");
		return new Tuple<string, object[]>(fieldbuilder.ToString(), arguments.ToArray());
	}
}
