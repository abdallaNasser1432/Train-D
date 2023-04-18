using Microsoft.EntityFrameworkCore;
using System;
using Train_D.Services;
using Train_D.Models;
using Train_D.Data;
using Train_D.DTO;
using AutoMapper;

namespace Train_D.Services
{
    public class StationsServices : IStationsServices
    {
        private readonly ApplicationDbContext _context;


        public StationsServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Station>> GetAll()
        {
            return await _context.Stations.ToListAsync();
        }

        public async Task<Station> GetByName(string stationName)
        {
            return await _context.Stations.SingleOrDefaultAsync(m => m.StationName == stationName);
        }


        public async Task<Station> Add(Station station)
        {
            await _context.AddAsync(station);
            _context.SaveChanges();
            return station;
        }

        
        public Station Delete(Station station)
        {
            _context.Remove(station);
            _context.SaveChanges();
            return station;
        }


        public Station Update(Station station)
        {
            _context.Update(station);
            _context.SaveChanges();
            return station;
        }

        public bool IsExist(string stationName)
        {
            return _context.Stations.Any(s=>s.StationName == stationName);

        }
    }
}
