namespace RE4CharacterAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public List<Character> Characters { get; set; } = new();
    }
}
