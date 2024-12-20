using services_backend.Models;

namespace services_backend.Services.Interfaces
{
    public interface ITimeService
    {
        Task<Times> GetTypeServicesById(int Id);
        Task<List<Times>> GetActiveAllTimesByService(int ServiceId);
        Task<Dictionary<string, int>> GetActiveAllTimesByTypeService(int TypeServiceId);
        Task<Times> NewTimes(Times times);
        Task<List<Times>> NewFranjaTimes(int ServiceId, int Day, DateTime firstTime, DateTime finishTime);
        Task<Times> ChangeTimesState(int TimeId, int newState);
        
    }
}
