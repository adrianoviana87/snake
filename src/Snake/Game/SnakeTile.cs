﻿using System;
using Snake.Framework;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;
using Snake.Framework.Physics;

namespace Snake.Game
{
	public class SnakeTile : ComponentBase, ICollidable, IDrawable
	{
		private Action onCollisionFood;
		private Action onCollisionTile;
		private Action onCollisionWall;

		public SnakeTile(float x, float y, Action onCollisionFood, Action onCollisionTile, Action onCollisionWall)
		{
			this.onCollisionFood = onCollisionFood;
			this.onCollisionTile = onCollisionTile;
            this.onCollisionWall = onCollisionWall;

			Transform = new TransformComponent
			{
				Position = new Point(x, y)
			};
		}

		public SnakeTile Next { get; set; }

		public TransformComponent Transform { get; private set; }

		public void CopyPosition(SnakeTile other)
		{
			Transform.Position = other.Transform.Position;
		}

		public void Draw(IDrawContext context)
		{
			context.Canvas.Draw(Transform, '@');
		}

		public void OnCollision(Collision collision)
		{
			switch (collision.Other.Tag)
			{
				case "SnakeTile":
					onCollisionTile();
					break;

				case "Wall":
					onCollisionWall();
					break;

				case "Food":
					onCollisionFood();
					break;
			}
		}
	}
}