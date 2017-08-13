using System.Collections.Generic;

namespace Snake.Framework.Physics
{
    /// <summary>
    /// Defines an interface for a physic system.
    /// </summary>
	public interface IPhysicSystem
	{
		void AddCollidable(ICollidable collidable);
		void RemoveCollidable(ICollidable collidable);
		IList<Collision> GetCollisions(ICollidable collidable);
		bool AnyCollision(ICollidable collidable);
		void Update();
	}
}