using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepasoPC1SebitasJoaco.Data;
using RepasoPC1SebitasJoaco.Interfaces;

namespace RepasoPC1SebitasJoaco.Repositories
{
    public class AttendeesRepository : IAttendeesRepository
    {
        private readonly EventosDbContext _dbContext;

        public AttendeesRepository(EventosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Select Attendees
        public async Task<IEnumerable<Attendees>> GetAll()
        {
            var attendees = await _dbContext.Attendees.ToListAsync();
            return attendees;
        }

        // Select Attendees by id
        public async Task<Attendees> GetOne(int id)
        {
            var attendees = await _dbContext
                            .Attendees
                            .FirstOrDefaultAsync(a => a.Id == id);

            return attendees;
        }

        //Create Attendees
        public async Task<int> Insert(Attendees attendees)
        {
            await _dbContext.Attendees.AddAsync(attendees);
            int rows = await _dbContext.SaveChangesAsync();

            return rows > 0 ? attendees.Id : -1;
        }

        //Update Attendees
        public async Task<bool> Update(Attendees attendees)
        {
            _dbContext.Attendees.Update(attendees);
            int rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }


        //Delete Attendees
        public async Task<bool> Delete(int id)
        {
            var attendees = await _dbContext
                            .Attendees
                            .FirstOrDefaultAsync(a => a.Id == id);

            if (attendees == null) return false;
          
            _dbContext.Attendees.Remove(attendees);
            int rows = await _dbContext.SaveChangesAsync();
            return (rows > 0);
        }
    }
}
