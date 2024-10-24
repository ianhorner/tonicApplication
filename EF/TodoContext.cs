using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using TonicApplication.Entities;

namespace TonicApplication.EF
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public string DbPath { get; } // TODO get configuration

        public TodoContext()
        {
            var folder = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(folder, "todo.db");
        }

        // I've never actually used Sqlite before, but I've heard that it's good for when you need a simple
        // DB that runs within an application, so that's why I'm using it.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
