using W05.Interfaces;
using W05.Models;

namespace W05.Services
{
    /// <summary>
    /// GameEngine demonstrates the Liskov Substitution Principle (LSP)
    /// and Interface Segregation Principle (ISP) in action.
    ///
    /// KEY LESSON: The 'is' keyword for safe type checking
    ///
    /// Instead of:  ((Ghost)_ghost).Fly();  // UNSAFE - will crash if not a Ghost!
    /// Use:         if (entity is IFlyable flyer) { flyer.Fly(); }  // SAFE
    ///
    /// This pattern:
    /// 1. Checks if the object implements the interface
    /// 2. Creates a typed variable in one step
    /// 3. Only calls the method if it's safe to do so
    /// </summary>
    public class GameEngine
    {
        private readonly IEntity _character;
        private readonly IEntity _goblin;
        private readonly IEntity _ghost;

        public GameEngine(IEntity character, IEntity goblin, IEntity ghost)
        {
            _character = character;
            _goblin = goblin;
            _ghost = ghost;
        }

        public void Run()
        {
            // Set up our entities
            _character.Name = "Hero";
            _goblin.Name = "Goblin";
            _ghost.Name = "Ghost";

            // Process each entity using our safe pattern
            Console.WriteLine("=== Processing Character ===");
            ProcessEntity(_character);

            Console.WriteLine("\n=== Processing Goblin ===");
            ProcessEntity(_goblin);

            Console.WriteLine("\n=== Processing Ghost ===");
            ProcessEntity(_ghost);

            // Combat demonstration
            Console.WriteLine("\n=== Combat ===");
            _character.Attack(_goblin);
            _goblin.Attack(_character);
            _ghost.Attack(_character);
        }

        /// <summary>
        /// Processes an entity using the 'is' keyword pattern.
        ///
        /// THIS IS THE KEY PATTERN FOR LSP AND ISP!
        ///
        /// Notice how we:
        /// 1. Call methods ALL entities have (Move, Attack) directly
        /// 2. Check for optional capabilities (IFlyable) before calling them
        /// 3. Never assume an entity can do something it might not be able to do
        ///
        /// This is LSP in action: we can substitute ANY IEntity here,
        /// whether it's a Character, Goblin, Ghost, or any future type!
        /// </summary>
        /// <param name="entity">Any entity to process</param>
        public void ProcessEntity(IEntity entity)
        {
            // All entities can move - this is safe for any IEntity
            entity.Move();

            // But can this entity fly? Let's check safely!
            // The 'is' keyword checks the type AND creates a variable in one step
            if (entity is IFlyable flyingEntity)
            {
                // Only executes if the entity implements IFlyable
                flyingEntity.Fly();
            }
            else
            {
                Console.WriteLine($"  {entity.Name} cannot fly.");
            }

            // TODO: Add more interface checks here!
            // For example, if you create IShootable:
            // if (entity is IShootable shooter)
            // {
            //     shooter.Shoot();
            // }
        }
    }
}
