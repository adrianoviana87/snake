using System.Collections.Generic;

namespace Snake.Framework
{
    public interface IWorld : IWorldContext
    {
		IScene CurrentScene { get; }
        void Update();
        void Draw(); 
    }
}