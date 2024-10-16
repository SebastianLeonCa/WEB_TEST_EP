using RepasoPC1SebitasJoaco.Data;

namespace RepasoPC1SebitasJoaco.Interfaces
{
    public interface IAttendeesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Attendees>> GetAll();
        Task<Attendees> GetOne(int id);
        Task<int> Insert(Attendees attendees);
        Task<bool> Update(Attendees attendees);
    }
}