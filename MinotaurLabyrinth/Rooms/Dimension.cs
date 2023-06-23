namespace MinotaurLabyrinth

{
    /// <summary>
    /// Represents a portal room, which contains portal that can take the sword.
    ///</summary>
    public class Dimension : Room
    {
        static Dimension()
        {
            RoomFactory.Instance.Register(RoomType.Room, () => new Dimension());
        }
        /// <inheritdoc/>
        public override RoomType Type { get; } = RoomType.Room;

        ///<inheritdoc/>
        public override bool IsActive { get; protected set; } = true;

        /// <summary>
        /// Activates the portal, making the user to  automatically lose consequences.
        ///</summary>
        public override void Activates(Hero hero, Map map)
        {
            if (IsActive)
            {
                ConsoleHelper.WriteLine("You walk into the room and feel the prresence of a portal to another dimension .", ConsoleColor.DarkYellow);
                ///Could update the probabilities to be based on the hero abilities
                double chanceOfSuccess = hero.HasSword ? 0.25 : 0.75;


                if (hero.HasSword)
                {
                    ConsoleHelper.WriteLine("You desperately try to run away from the portal and grab the sword firmly.", ConsoleColor.DarkGreen);
                    if (RandomNumberGenerator.NextDouble() < chanceOfSuccess)
                    {
                        IsActive = false;
                        ConsoleHelper.WriteLine("You manage to successufully escape from the portal suddenly the portal dissapear. Now run to the exit.", ConsoleColor.DarkGreen);

                    }
                    else
                    {
                        ConsoleHelper.WriteLine("You manage to successfully escape from the portal but instead, you lost the sword, yo will have to retreive it again.", ConsoleColor.DarkGreen);
                    }
                }



            }
        }
    }
}
