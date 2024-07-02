namespace Cdeem.Core.Entities
{
    public class User : EntityBase
    {
        public User(string name, string email, string password, IEnumerable<Skill> skills) : base()
        {
            Name = name;
            Email = email;
            Password = password;
            Skills = skills;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public IEnumerable<Skill> Skills{ get; private set; }
    }
}
