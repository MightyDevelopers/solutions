namespace SolutionsAI.Response.DTOs
{
    public abstract class BaseDTO<TEntity>
    {
        internal abstract void FillFromEntity(TEntity entity);
    }
}
