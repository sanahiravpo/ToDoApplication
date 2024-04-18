using ToDoApplication.Context;
using ToDoApplication.Interfaces;
using ToDoApplication.Models;

namespace ToDoApplication.Services
{
    public class ToDoServices: ITodo

    {
        
        private readonly ToDoDbContext _context;
        public ToDoServices( ToDoDbContext context)
        {
     
            _context = context;

        }
        public IEnumerable<ToDo> GetAllTasks()
        {
            return _context.Todos.ToList();
        }

        public void DeleteTask(int id)
        {
            var employeetodelete = _context.Todos.Find(id);

            if (employeetodelete != null)
            {
                _context.Todos.Remove(employeetodelete);
                _context.SaveChanges();
            }
        }
        public ToDo GetTaskById(int id)
        {
            var task= _context.Todos.FirstOrDefault(x=>x.Id == id);
            if(task== null)
            {
                return null;
            }
            else
            {
                return task;
            }
        }
        public  void AddTask(ToDo toDo)
        {
            var newitem=_context.Todos.Add(toDo);
           

            _context.Todos.Add(toDo);
             _context.SaveChanges();
        }
        public void UpdateTask(ToDo toDo, int id)
        {
            var existingitem = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (existingitem!= null)
            {
                existingitem.Id= id;
                existingitem.Name= toDo.Name;   
                existingitem.Description= toDo.Description;
            }
            
             _context.SaveChanges();
        }
       
    }
}
