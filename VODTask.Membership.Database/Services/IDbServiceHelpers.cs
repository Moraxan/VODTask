internal static interface IDbServiceHelpers
{
	string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity;
}