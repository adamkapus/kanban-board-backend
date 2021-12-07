using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TemalabBackend.DAL;
using TemalabBackend.DAL.EF;

namespace TemalabBackend.BL
{

    public interface IToDoManager
    {


        Task<IReadOnlyCollection<ToDoItem>> ListToDos();
         Task<ToDoItem> GetToDoOrNull(int todoId);// => await toDoItemRepository.GetToDoOrNull(todoId);

        Task<bool> ModifyToDo(ToDoItem newItem);// => await toDoItemRepository.ModifyToDo(newItem);

         Task AddToDo(ToDoItem item);// => await toDoItemRepository.AddToDo(item);

        Task<bool> DeleteToDo(int todoId);// => await toDoItemRepository.DeleteToDo(todoId);

    }

}
