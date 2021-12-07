using System.Collections.Generic;
using System.Threading.Tasks;
using TemalabBackend.DAL.EF;


namespace TemalabBackend.DAL
{
    public interface IToDoItemRepository
    {
        Task<IReadOnlyCollection<ToDoItem>> ListToDos();
        Task<ToDoItem> GetToDoOrNull(int todoId);

        Task<bool> ModifyToDo(ToDoItem newItem);

        Task AddToDo(ToDoItem item);

        Task<bool> DeleteToDo(int todoId);

        Task<bool> SwapToDoItems(int firstId, int secondId);


    }
}
