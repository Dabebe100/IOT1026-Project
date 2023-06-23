namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a Slimy gel in the game.
    /// </summary>
    public class GelatinousCube : Monster, IMoveable
    {
        private Location _location;

        public int Y { get; private set; }
        public int X { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hero">The hero encountering the minotaur.</param>
        /// <param name="map">The current game map.</param>

        public GelatinousCube(Location location)
        {
            _location = location;
        }

        public Location GetLocation()
        {
            return _location;
        }
        public override void Activate(Hero hero, Map map)
        {

            Console.WriteLine("Oh no! You've been caught in slime!");
            Console.WriteLine("You need to find a way to escape!");


        }

        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            return false;
        }

        /// <summary>
        /// Displays the current state of the monster.
        /// </summary>
        /// <returns>Returns a DisplayDetails object containing the monster's display information.</returns>
        public override DisplayDetails Display()
        {
            return new DisplayDetails("[C]", ConsoleColor.DarkYellow);
        }

        public void Move(Hero hero, Map map)
        {
            map.GetRoomAtLocation(_location).RemoveMonster();
            _location = new Location(_location.Row + 1, _location.Column);
            map.GetRoomAtLocation(_location).AddMonster(this);
        }
    }
}





