using TonicApplication.EF;
using TonicApplication.Entities;

namespace TonicApplication.Repos
{
    public class TodoRepo : ITodoRepo
    {
        private TodoContext _todoContext;
        public TodoRepo()
        {
            _todoContext = new TodoContext(); // I know I should add this to the DI container, but I'm running low on time
        }

        public void Insert(string text)
        {
            var newItem = new TodoItem()
            {
                Text = text
            };

            _todoContext.TodoItems.Add(newItem);
            _todoContext.SaveChanges();
        }

        public void Update(TodoItem item)
        {
            _todoContext.TodoItems.Update(item);
            _todoContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _todoContext.TodoItems.Remove(new TodoItem() { TodoItemId = id });
            _todoContext.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todoContext.TodoItems.ToList();
        }
    }
}
