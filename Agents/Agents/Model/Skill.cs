namespace Agents.Model
{
    public class Skill : Entity
    {
        public string Name { get; private set; }

        public Skill(string name)
        {
            Name = name;
        }
    }
}