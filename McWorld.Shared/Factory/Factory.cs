namespace McWorld.Shared.Factory
{
    using System;
    public class Factory : IFactory<Type>
    {
        public Type Create(Type type)
        {
            throw new NotImplementedException();
        }

        public Type Update(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
