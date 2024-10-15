﻿using Microsoft.EntityFrameworkCore;
using services_backend.Models;
using services_backend.Services.Interfaces;

namespace services_backend.Services
{
    public class TimeService : ITimeService
    {
        private readonly MyDbContext _context;

        public TimeService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Times> GetTypeServicesById(int Id)
        {
            return await _context.Times.FindAsync(Id);
        }

        public async Task<List<Times>> GetActiveAllTimesByService(int ServiceId)
        {
            try
            {
                var services = await _context.Times.Where(c => c.State == 1 && c.State == 1 && c.ServiceId == ServiceId).ToListAsync();
                if (services == (null))
                {
                    throw new Exception($"No found Times por Service ID {ServiceId}");
                }
                return services;
            }
            catch (Exception ex)
            {
                throw new Exception($"Service NewTypeServices failed: {ex.Message}", ex);
            }
        }

        public async Task<Times> NewTimes(Times times)
        {
            try
            {
                _context.Times.Add(times);
                await _context.SaveChangesAsync();
                return times;
            }
            catch (Exception ex)
            {
                throw new Exception($"Service Times failed: {ex.Message}", ex);
            }
        }

        public async Task<List<Times>> NewFranjaTimes(int ServiceId, int Day, DateTime firstTime, DateTime finishTime )
        {
            List<Times> timesList = new List<Times>();

            
            TimeSpan intervalo = TimeSpan.FromHours(1);

            DateTime currentInitTime = firstTime;

            while (currentInitTime < finishTime)
            {
                
                DateTime currentFinishTime = currentInitTime.Add(intervalo);

                
                if (currentFinishTime > finishTime)
                {
                    currentFinishTime = finishTime;
                }

                
                var newTime = new Times
                {
                    Day = Day,
                    InitTime = currentInitTime,
                    FinishTime = currentFinishTime,
                    State = 1, 
                    ServiceId = ServiceId
                };

                
                timesList.Add(newTime);

                
                currentInitTime = currentFinishTime;
            }

            
            _context.Times.AddRange(timesList);
            await _context.SaveChangesAsync();

            return timesList; 
        }


        public async Task<Times> ChangeTimesState(int TimeId, int newState)
        {
            var Times = await _context.Times.FindAsync(TimeId);
            if (Times == null)
            {
                throw new Exception($"Type Times with ID {TimeId} not found.");
            }
            Times.State = newState;
            await _context.SaveChangesAsync();
            return Times;
        }
    }
}
