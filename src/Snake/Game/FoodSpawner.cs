using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Framework;
using Snake.Framework.Animations;
using Snake.Framework.Behaviors;
using Snake.Framework.Geometry;
using Snake.Framework.Graphics;

namespace Snake.Game
{
    public class FoodSpawner : ComponentBase, IUpdatable
    {
        private Rectangle bounds;
        private Food food;
        private IAnimationPipelineController animContr = AnimationPipelineController.Empty;

        private FoodSpawner(IWorldContext context)
            :base(context)
        {
            this.bounds = Context.Bounds;
            food = new Food(Context) { Enabled = false };
        }

        public void Update()
        {
            if(!food.Enabled)
            {
				do
				{
					food.Transform.Position = bounds.RandomPoint().Round();
				} while (Context.PhysicSystem.AnyCollision(food));

                food.Enabled = true;

                animContr.Destroy();
                food.Transform.Scale = Food.DefaultScale;

                animContr = food.Transform
                    .ScaleTo(Food.DefaultScale.X * 2f, 0.2f, Easing.InBack)
                    .PingPong(1);
            }
        }

        public static FoodSpawner Create(IWorldContext context)
        {
            return new FoodSpawner(context);
        }
    }
}
