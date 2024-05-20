using Microsoft.EntityFrameworkCore;
using System.Linq;
using Todo.Data;
using Todo.Data.Entities;

namespace Todo.Services
{
    public static class ApplicationDbContextConvenience
    {
        public static IQueryable<TodoList> RelevantTodoLists(this ApplicationDbContext dbContext, string userId)
        {
            return dbContext.TodoLists.Include(tl => tl.Owner)
                .Include(tl => tl.Items)
                .Where(tl => tl.Owner.Id == userId || tl.Items.Any(x => x.ResponsiblePartyId == userId));
        }

        public static TodoList SingleTodoList(this ApplicationDbContext dbContext, int todoListId, bool orderBuRank = false)
        {

            if (orderBuRank)
            {
                return dbContext.TodoLists.Include(tl => tl.Owner)
               .Include(tl => tl.Items.OrderBy(it => it.Rank))
               .ThenInclude(ti => ti.ResponsibleParty)
               .Single(tl => tl.TodoListId == todoListId);
            }
            else
            {
                return dbContext.TodoLists.Include(tl => tl.Owner)
               .Include(tl => tl.Items.OrderBy(it => it.Importance))
               .ThenInclude(ti => ti.ResponsibleParty)
               .Single(tl => tl.TodoListId == todoListId);
            }

        }

        public static TodoItem SingleTodoItem(this ApplicationDbContext dbContext, int todoItemId)
        {
            return dbContext.TodoItems.Include(ti => ti.TodoList).Single(ti => ti.TodoItemId == todoItemId);
        }
    }
}