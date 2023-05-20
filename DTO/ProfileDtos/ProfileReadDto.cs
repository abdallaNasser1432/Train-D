namespace Train_D.DTO.ProfileDtos
{
    public record ProfileReadDto : ProfileWriteDto
    {
        public string Email { get; init; }
        public string UserName { get; init; }
    }
}
