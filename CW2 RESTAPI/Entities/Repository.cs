namespace CW2_RESTAPI.Entities
{
        public interface IRepository<T>
        {
            T Get(string email);
            void Add(T entityToAdd);
            void Delete(T entityToDelete);
            void Update(T entityToUpdate, T entity);
        }
}
