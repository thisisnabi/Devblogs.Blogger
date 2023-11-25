namespace Devblogs.Blogger.Domain.Common;

public abstract class EntityBase<TKey>
    where TKey : struct 
{
    public TKey Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        var entity = obj as EntityBase<TKey>;

        if(entity is null) return false;

        return GetType() == entity.GetType() &&
               EqualityComparer<TKey>.Default.Equals(Id, entity.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
    }

    public static bool operator ==(EntityBase<TKey> leftEntity, EntityBase<TKey> rightEntity)
    {
        return EqualityComparer<EntityBase<TKey>>.Default.Equals(leftEntity, rightEntity);
    }

    public static bool operator !=(EntityBase<TKey> leftEntity, EntityBase<TKey> rightEntity)
    {
        return !(leftEntity == rightEntity);
    }
}