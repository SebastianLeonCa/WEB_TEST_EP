namespace RepasoPC1SebitasJoaco.DTO
{
    public class AttendeesDTO
    {
        public int Id { get; set; }

        public string? AttendeeName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? RegisteredAt { get; set; }
    }

    public class AttendeeNameDTO
    {
        public string? AttendeeName { get; set; }
    }
}
