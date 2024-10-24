using TonicApplication.Entities;

namespace TonicApplication.Repos
{
    public interface ITodoRepo
    {
        public void Insert(string text);

        public void Update(TodoItem item);

        public void Delete(int id);

        public IEnumerable<TodoItem> GetAll();
    }
}
