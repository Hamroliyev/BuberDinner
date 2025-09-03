using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BuberdinnerDbContext buberdinnerDbContext;

        public MenuRepository(BuberdinnerDbContext buberdinnerDbContext)
        {
            this.buberdinnerDbContext = buberdinnerDbContext;
        }

        public void Add(Menu menu)
        {
            this.buberdinnerDbContext.Menus.Add(menu);

            this.buberdinnerDbContext.SaveChanges();
        }
    }
}