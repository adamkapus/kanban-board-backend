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
         Task<ToDoItem> GetToDoOrNull(int todoId);

        Task<bool> ModifyToDo(ToDoItem newItem);

         Task AddToDo(ToDoItem item);

        Task<bool> DeleteToDo(int todoId);

        Task<bool> SwapToDoItems(int firstId, int secondId);

    }

}
