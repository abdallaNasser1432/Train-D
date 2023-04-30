using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Train_D.Data;
using Train_D.DTO.ProfileDtos;
using Train_D.Models;
using Train_D.Services.Contract;

namespace Train_D.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProfileService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProfileReadDto> GetData(string UserName)
        {
            try
            {
                var User = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.NormalizedUserName == UserName);
                var userData = _mapper.Map<ProfileReadDto>(User);
                return userData;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ProfileWriteDto> UpdateUserData(string UserName, ProfileWriteDto data)
        {
            try
            {
                var User = await _context.Users.SingleOrDefaultAsync(u => u.NormalizedUserName == UserName);
                _mapper.Map(data, User);
                await _context.SaveChangesAsync();
                return data;
            }
            catch
            {
                return null;
            }

        }

        public async Task<byte[]> Upload(byte[] Image, string UserName)
        {
            try
            {
                var User = await _context.Users.SingleOrDefaultAsync(u => u.NormalizedUserName == UserName);
                User.Image = Image;
                await _context.SaveChangesAsync();
                return Image;
            }
            catch
            {
                return Array.Empty<byte>();
            }

        }
    }
}
