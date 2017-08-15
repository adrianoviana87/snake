﻿using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
	public class Wall : ComponentBase, IDrawable, ICollidable
	{
        private Wall(float x, float y, IWorldContext context)
            : base(context)
        {
            Transform = new TransformComponent(x, y, context);

            var bounds = context.Bounds;
            var offsetX = 0;

            if (y % 2 == 0)
            {
                if (x == bounds.Left)
                {
                    offsetX = -1;
                }
                else if (x == bounds.Right - 1)
                {
                    offsetX = 1;
                }
            }

            var offsetY = 0;

			if (x % 2 == 0)
			{
				if (y == bounds.Top)
				{
					offsetY = -1;
				}
				else if (y == bounds.Bottom - 1)
				{
					offsetY = 1;
				}
			}

            var pos = new Point(x + offsetX, y + offsetY);
            var tween = new PositionTween(Transform, pos, 1);
            tween.Ease = Easing.InBack;
            tween.Loop();
            AddChild(tween);
		}

        public static Wall Create(float x, float y, IWorldContext context)
        {
            return new Wall(x, y, context);
        }

        public TransformComponent Transform { get; private set; }

		public void Draw(IDrawContext context)
		{
			context.Canvas.Draw(Transform, '#');
		}

		public void OnCollision(Collision collision)
		{
		}
	}
}
