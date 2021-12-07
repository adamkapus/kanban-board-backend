using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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
            
            return await db.ToDoItem.FindAsync(todoId);
        }

        public async Task<IReadOnlyCollection<ToDoItem>> ListToDos()
        {
           
            return await db.ToDoItem.ToListAsync();
        }

        public async Task<bool> DeleteToDo(int todoId)
        {
            
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

            int maxCategoryPos = maxCategoryPosInCategory(item.Category);
            item.CategoryPos = maxCategoryPos + 1;

            db.ToDoItem.Add(item);
            await db.SaveChangesAsync();
            return;
        }




        public async Task<bool> ModifyToDo(ToDoItem newItem)
        {

            using (var tran = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.Serializable },
                TransactionScopeAsyncFlowOption.Enabled))
            {
                var currentItem = await GetToDoOrNull(newItem.ID);
                if(currentItem == null)
                {
                    tran.Complete();
                    return false;
                }

                if(currentItem.Category != newItem.Category)
                {
                    newItem.CategoryPos = maxCategoryPosInCategory(newItem.Category) + 1;
                }
                currentItem.Name = newItem.Name;
                currentItem.Category = newItem.Category;
                currentItem.CategoryPos = newItem.CategoryPos;
                currentItem.Description = newItem.Description;
                currentItem.DueDate = newItem.DueDate;

               
             
                    await db.SaveChangesAsync();
              
                tran.Complete();
                return true;
            }

            
        }

        public async Task<bool> SwapToDoItems(int firstId, int secondId){
            using (var tran = new TransactionScope(
               TransactionScopeOption.Required,
               new TransactionOptions() { IsolationLevel = IsolationLevel.Serializable },
               TransactionScopeAsyncFlowOption.Enabled))
            {
                var firstItem = await GetToDoOrNull(firstId);
                if(firstItem == null)
                {
                    tran.Complete();
                    return false;
                }

                var seconditem = await GetToDoOrNull(secondId);
                if (seconditem == null)
                {
                    tran.Complete();
                    return false;
                }

                int firstItemsPos = firstItem.CategoryPos;
                int secondItemsPos = seconditem.CategoryPos;

                firstItem.CategoryPos = secondItemsPos;
                seconditem.CategoryPos = firstItemsPos;
               
                    await db.SaveChangesAsync();

                tran.Complete();
                return true;


            }
            }

        private bool ToDoItemExists(int todoID)
        {
            return  db.ToDoItem.Any(e => e.ID == todoID);
        }

        private int maxCategoryPosInCategory(string categoryName)
        {
            int maxCategoryPos = 0;

            var itemWithLargestPos = db.ToDoItem.Where(item => item.Category == categoryName).OrderByDescending(item => item.CategoryPos).FirstOrDefault();

            if(itemWithLargestPos != null)
            {
                maxCategoryPos = itemWithLargestPos.CategoryPos;
            }

            return maxCategoryPos;
        }
    }
    
}

