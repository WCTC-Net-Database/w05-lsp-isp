using Microsoft.Extensions.DependencyInjection;
using W05.Interfaces;
using W05.Models;
using W05.Services;

namespace W05
{
    class Program
    {
        static void Main(string[] args)
        {
            var character = new Character();
            var goblin = new Goblin();
            var ghost = new Ghost();

            var gameEngine = new GameEngine(character, goblin, ghost);
            gameEngine?.Run();
        }

    }
}
