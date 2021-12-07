using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TemalabBackend.DAL;
using TemalabBackend.DAL.EF;

namespace TemalabBackend.BL
{

    public class ToDoManager : IToDoManager
    {
        private readonly IToDoItemRepository toDoItemRepository;

        public ToDoManager(IToDoItemRepository toDoItemRepository)
        {
            this.toDoItemRepository = toDoItemRepository;
        }

        public async Task<IReadOnlyCollection<ToDoItem>> ListToDos() => await toDoItemRepository.ListToDos();
        public async Task<ToDoItem> GetToDoOrNull(int todoId) => await toDoItemRepository.GetToDoOrNull(todoId);

        public async Task<bool> ModifyToDo(ToDoItem newItem) => await toDoItemRepository.ModifyToDo(newItem);

        public async Task AddToDo(ToDoItem item) => await toDoItemRepository.AddToDo(item);

        public async Task<bool> DeleteToDo(int todoId) => await toDoItemRepository.DeleteToDo(todoId);

    }
    
}
