namespace W5_assignment_template.Interfaces
{
    public interface IEntity
    {
        void Attack(IEntity target);
        void Move();
        string Name { get; set; }
    }

}
