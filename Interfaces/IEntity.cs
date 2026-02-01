namespace W05.Interfaces
{
    public interface IEntity
    {
        void Attack(IEntity target);
        void Move();
        string Name { get; set; }
    }

}
