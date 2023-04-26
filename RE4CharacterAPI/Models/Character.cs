using System;
namespace RE4CharacterAPI.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Organization? Organization { get; set; }
    }
}