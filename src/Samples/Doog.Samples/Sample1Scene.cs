﻿namespace Doog.Samples
{
    public class Sample1Scene : SceneBase
    {
        private Rectangle moveToSampleArea = new Rectangle(1, 10, 11, 21);
        private float numberSample1;
        private float numberSample2;
        private IAnimationPipelineController controller1;
        private IAnimationPipelineController controller2;

        public Sample1Scene(IWorldContext context)
            : base(context)
        {
        }

        public override void Initialize()
        {
            Context.RemoveAllComponents();
            var bounds = Context.Bounds;

            var moveToFood1 = new RectangleComponent(Point.Zero, Context);
            moveToFood1.Transform.Position = moveToSampleArea.LeftTopPoint();
            moveToFood1.Transform
                       .MoveTo(moveToSampleArea.RightBottomPoint(), 2, Easing.InBack)
                       .Delay(1)
                       .MoveTo(moveToSampleArea.RightTopPoint(), 2, Easing.Linear)
                       .PingPong();

            var moveToFood2 = new RectangleComponent(Point.Zero, Context);
            moveToFood2.Transform.Position = moveToSampleArea.RightBottomPoint();
            moveToFood2.Transform
                       .MoveTo(moveToSampleArea.LeftTopPoint(), 2, Easing.InBack)
                       .Delay(1)
                       .MoveTo(moveToSampleArea.LeftBottomPoint(), 2, Easing.Linear)
                       .PingPong();

            var blinkFood = new RectangleComponent(Point.Zero, Context);
            blinkFood.Transform.Position = new Point(30, 11);
            blinkFood
                .Enable(1f)
                .Loop();

            controller1 = blinkFood
                .To(0, 100, 19, Easing.Linear, v => numberSample1 = v)
                .Loop();


            controller2 = blinkFood
                    .To(0, 10, 10, Easing.Linear, v => numberSample2 = v)
                    .Delay(5)
                    .To(10, 30, 10, Easing.Linear, v => numberSample2 = v)
                    .Delay(5)
                    .To(30, 100, 10, Easing.Linear, v => numberSample2 = v)
                    .Delay(5)
                    .PingPong();


            // Once blink
            for (var i = 0; i < 100; i++)
            {
                var b = new RectangleComponent(Point.Zero, Context);
                b.Transform.Position = new Point(31 + i, 11);
                b
                    .Delay(i * 0.05f)
                    .Enable(1f)
                    .Enable(0.5f)
                    .Enable(0.5f)
                       .Once();
            }

            // Ping-pong move
            var length = 100;
            var speed = 0.1f;
            var maxTime = (length - 1) * speed;

            for (var i = 0; i < length; i++)
            {
                var b = new RectangleComponent(Point.Zero, Context);
                b.Transform.Position = new Point(31 + i, 13);
                b
                    .Disable(i * speed).OnlyForward()
                    .Delay(maxTime - (i * speed)).OnlyForward()

                    .Delay(maxTime - ((length - 1 - i) * speed)).OnlyBackward()
                    .Enable(((length - 1) - i) * speed).OnlyBackward()

                    .PingPong();
            }

            // ScaleTo, MoveTo and PingPong
            new RectangleComponent(140, 1, Context) { Filled = true }.Transform
                .ScaleTo(new Point(20, 10), 1, Easing.InExpo)
                .MoveTo(new Point(140, bounds.Bottom - 10), 2, Easing.InBounce)
                .PingPong();

            // Circle and rectangle
            var circle = new CircleComponent(new Point(12, 20), 1, Context)
            {
                Filled = false
            };

            circle.Transform
                .Do(() => circle.Filled = false).OnlyForward()
                .ScaleTo(30, 3, Easing.InOutQuint)
                .Do(() => circle.Filled = true).OnlyBackward()
                .PingPong();

            var rect = new RectangleComponent(circle.Transform.Position, Context)
            {
                Filled = false
            };

            rect.Transform
                .ScaleTo(30, 3, Easing.InOutQuint)
                .Delay(3)
                .PingPong();


            // Circle and rectangle with pivot centralized.
            var circleCentralized = new CircleComponent(bounds.GetCenter(), 1, Context)
            {
                Filled = false
            };

            circleCentralized.Transform.CentralizePivot()
                .Do(() => circleCentralized.Filled = false).OnlyForward()
                .ScaleTo(30, 3, Easing.InOutQuint)
                .Do(() => circleCentralized.Filled = true).OnlyBackward()
                .PingPong();


            var rectCentralized = new RectangleComponent(circleCentralized.Transform.Position, Context)
            {
                Filled = false
            };

            rectCentralized.Transform.CentralizePivot()
                .ScaleTo(30, 3, Easing.InOutQuint)
                .Delay(3)
                .PingPong();
        }

        public override void Update()
        {
            Context.InputSystem
                   .IsKeyDown(Keys.D1, () => ToogleAnimation(controller1))
                   .IsKeyDown(Keys.D2, () => ToogleAnimation(controller2))
                   .IsKeyDown(Keys.D3, () =>
                   {
                       ToogleAnimation(controller1);
                       ToogleAnimation(controller2);
                   })
                   .IsKeyDown(Keys.D0, () =>
                   {
                       controller1.Destroy();
                       controller2.Destroy();
                   })
                   .IsKeyDown(Keys.D7, () => AnimationPipelineController.PauseAll())
                   .IsKeyDown(Keys.D8, () => AnimationPipelineController.ResumeAll())
                   .IsKeyDown(Keys.D9, () => AnimationPipelineController.DestroyAll());
        }

        private void ToogleAnimation(IAnimationPipelineController controller)
        {
            if (controller.State == AnimationState.Playing)
            {
                controller.Pause();
            }
            else
            {
                controller.Resume();
            }
        }

        public override void Draw(IDrawContext drawContext)
        {
            drawContext.Canvas
                   .Draw(moveToSampleArea, false, Pixel.Default);

            drawContext.TextSystem
                .DrawCenter(0, -10, numberSample1.ToString("N0"))
                .DrawCenter(0, 0, numberSample2.ToString("N0"));

        }
    }
}
