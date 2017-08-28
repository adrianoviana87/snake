﻿using System;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game.Scenes.Samples
{
    public class Sample4Scene : SceneBase
    {
        public Sample4Scene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            DeployX();
            DeployY();
        }

        public override void Update()
        {
            if(Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                switch(key)
                {
                    case ConsoleKey.X:
                        DeployX();
                        break;

					case ConsoleKey.Y:
						DeployY();
						break;
                }
            }
        }

        private void DeployY()
        {
			var bounds = Context.Bounds;
			var minDuration = 1f;
			var timeScale = 0.1f;

			for (float y = bounds.Top; y < bounds.Bottom; y++)
			{
				new SampleComponent(bounds.Left, y, Context)
					.Transform
					.MoveTo(bounds.Right, y, minDuration + y * timeScale)
                    .Disable(1f)
					.Once();

				new SampleComponent(bounds.Right, y, Context)
					.Transform
					.MoveTo(bounds.Left, y, minDuration + y * timeScale)
                    .Disable(1f)
					.Once();
			}
		}

        private void DeployX()
        {
			var bounds = Context.Bounds;
			var minDuration = 1f;
			var timeScale = 0.2f;

			for (float x = bounds.Left; x < bounds.Right; x++)
			{
				new SampleComponent(x, bounds.Top, Context)
					.Transform
					.MoveTo(x, bounds.Bottom, minDuration + x * timeScale)
                    .Disable(1f)
					.Once();

				new SampleComponent(x, bounds.Bottom, Context)
					.Transform
					.MoveTo(x, bounds.Top, minDuration + x * timeScale)
                    .Disable(1f)
					.Once();
			}
        }

        public override void Draw(IDrawContext context)
        {
            Context.TextSystem.Draw(0, 0, "Type X or Y to deploy the animations", "Default");
        }
    }
}
