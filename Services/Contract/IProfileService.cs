using Train_D.DTO.ProfileDtos;

namespace Train_D.Services.Contract
{
    public interface IProfileService
    {
        public Task<byte[]> Upload(byte[] Image, string UserName);
        public Task<ProfileWriteDto> UpdateUserData(string UserName,ProfileWriteDto data);
        public Task<ProfileReadDto> GetData(string UserName);

    }
}
