using ToDoApplication.Models;

namespace ToDoApplication.Interfaces
{
    public interface ITodo
    {
        public IEnumerable<ToDo>GetAllTasks();
        
        public ToDo GetTaskById(int id);
        public  void AddTask(ToDo toDo);
        public void DeleteTask(int id);
        public void UpdateTask(ToDo toDo,int id);



    }
}
