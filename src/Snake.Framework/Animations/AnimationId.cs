﻿using System;

namespace Snake.Framework.Animations
{
    /// <summary>
    /// Represents an animation id that is composed by the owner and the animation name.
    /// </summary>
    public class AnimationId
    {
        private readonly string id;

        public AnimationId(IComponent owner, string name)
        {
            id = BuildId(owner, name);
        }

		private static string BuildId(IComponent owner, string name)
		{
			return "{0}({1}):{2}".With(owner.GetType().FullName, owner.GetHashCode(), name);
		}

        public override bool Equals(object obj)
        {
            var other = obj as AnimationId;

            if(other == null)
            {
                return false;
            }

            return id.Equals(other.id, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return id;
        }
    }
}
