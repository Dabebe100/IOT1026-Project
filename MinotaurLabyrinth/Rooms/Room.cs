﻿namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a generic room in the labyrinth.
    /// </summary>
    public class Room : IActivatable
    {
        static Room()
        {
            RoomFactory.Instance.Register(RoomType.Room, () => new Room());
        }

        private Monster? _monster;

        /// <summary>
        /// Gets the room type.
        /// </summary>
        public virtual RoomType Type { get; } = RoomType.Room;

        /// <summary>
        /// Gets a value indicating whether the room is currently contains a monster or an event.
        /// </summary>
        public virtual bool IsActive { get; protected set; }

        /// <summary>
        /// Adds a monster to the room.
        /// </summary>
        /// <param name="monster">The monster to be added.</param>
        public void AddMonster(Monster monster)
        {
            IsActive = true;
            _monster = monster;
        }

        /// <summary>
        /// Removes a monster from the room.
        /// </summary>
        public void RemoveMonster()
        {
            IsActive = false;
            _monster = null;
        }

        /// <summary>
        /// Displays sensory information about the room, based on the hero's distance from it.
        /// </summary>
        /// <param name="hero">The hero sensing the room.</param>
        /// <param name="heroDistance">The distance between the hero and the room.</param>
        /// <returns>Returns true if a message was displayed; otherwise, false.</returns>
        public virtual bool DisplaySense(Hero hero, int heroDistance)
        {
            if (_monster != null)
            {
                return _monster.DisplaySense(hero, heroDistance);
            }
            return false;
        }

        public void Activate(Hero hero, Map map)
        {

        }
        /// <summary>
        /// Activates the room, triggering interactions with the hero.
        /// </summary>
        /// <param name="hero">The hero entering the room.</param>
        /// <param name="map">The current game map.</param>
        public virtual void Activates(Hero hero, Map map)
        {
            _monster?.Activate(hero, map);
        }

        /// <summary>
        /// Displays the current state of the room.
        /// </summary>
        /// <returns>Returns a DisplayDetails object containing the room's display information.</returns>
        public virtual DisplayDetails Display()
        {
            if (_monster != null)
                return _monster.Display();
            else
                return new DisplayDetails("[ ]", ConsoleColor.Gray);
        }


    }
}



