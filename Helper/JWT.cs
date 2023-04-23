namespace Train_D.Helper
{
    public class JWT
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInDays { get; set; }
        public string GoogleClientId { get; set; }
    }

}
