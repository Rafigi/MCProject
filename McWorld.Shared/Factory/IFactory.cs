namespace MCAPI.McWorld.Shared.Factory
{
    public interface IFactory<TType> where TType : class
    {
        TType Create(TType type);
        TType Update(TType type);
    }
}
