using Microsoft.EntityFrameworkCore;
using RunescapeApp.Data;

namespace RunescapeApp.Services
{
    public class EquipmentService
    {
        private readonly RunescapeContext dbContext;

        public EquipmentService(RunescapeContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task<List<Position>> ReturnPositionList()
        {
            return await dbContext.Positions.ToListAsync();
            
        }
        public async Task<List<Equipment>> ReturnEquipmentList()
        {
            return await dbContext.Equipment.ToListAsync();
        }

    }
}
