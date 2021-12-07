using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemalabBackend.DAL.EF;
//using TemalabBackend.Model;


namespace TemalabBackend.DAL
{

    public class ToDoItemRepository : IToDoItemRepository
    {


        private readonly ToDoDbContext db;

        public ToDoItemRepository(ToDoDbContext db)
            => this.db = db;

        public async Task<ToDoItem> GetToDoOrNull(int todoId)
        {
            //throw new System.NotImplementedException();
            return await db.ToDoItem.FindAsync(todoId);
        }

        public async Task<IReadOnlyCollection<ToDoItem>> ListToDos()
        {
            //throw new System.NotImplementedException();
            return await db.ToDoItem.ToListAsync();
        }

        public async Task<bool> DeleteToDo(int todoId)
        {
            //throw new System.NotImplementedException();
            ToDoItem item = await GetToDoOrNull(todoId);
            if(item == null)
            {
                return false;
            }

            db.ToDoItem.Remove(item);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task AddToDo(ToDoItem item)
        {
            db.ToDoItem.Add(item);
            await db.SaveChangesAsync();
            return;
        }




        public async Task<bool> ModifyToDo(ToDoItem newItem)
        {
            //throw new System.NotImplementedException();
            db.Entry(newItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! ToDoItemExists(newItem.ID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        private bool ToDoItemExists(int todoID)
        {
            return  db.ToDoItem.Any(e => e.ID == todoID);
        }
    }
    
}

