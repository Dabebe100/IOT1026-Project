namespace MinotaurLabyrinth
{
    public interface IMoveable
    {
        bool DisplaySense(Hero hero, int heroDistance);
        void Activate(Hero hero, Map map);
        void Move(Hero hero, Map map);
    }
}
