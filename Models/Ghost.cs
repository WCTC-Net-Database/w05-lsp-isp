using W05.Interfaces;

namespace W05.Models
{
    public class Ghost : IEntity, IFlyable
    {
        public string Name { get; set; }

        public void Attack(IEntity target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} with a chilling touch.");
        }

        public void Move()
        {
            Console.WriteLine($"{Name} floats silently.");
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} flies rapidly through the air.");
        }
    }
}
