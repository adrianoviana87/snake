using System;

namespace Snake.Framework.Geometry
{
	/// <summary>
	/// IntRectangle extension methods.
	/// </summary>
	public static class RectangleExtensions
	{
		private static readonly Random rnd = new Random(DateTime.UtcNow.Millisecond);

		public static Point RandomPoint(this Rectangle rect)
		{
			return new Point(
                   (float) rnd.NextDouble() * (rect.Right - rect.Left),
                (float) rnd.NextDouble() * (rect.Bottom - rect.Top)
				);
		}

        public static Point LeftTopPoint(this Rectangle rect)
        {
            return new Point(rect.Left, rect.Top);
        }

		public static Point RightTopPoint(this Rectangle rect)
		{
			return new Point(rect.Right, rect.Top);
		}

		public static Point RightBottomPoint(this Rectangle rect)
        {
            return new Point(rect.Right, rect.Bottom);

        }

        public static Point LeftBottomPoint(this Rectangle rect)
		{
			return new Point(rect.Left, rect.Bottom);

		}
	
        public static bool Contains(this Rectangle rect, Point point)
		{
			return rect.Contains(point.X, point.Y);
		}

        public static bool IsXBorder(this Rectangle rect, float x)
        {
            return x.EqualsTo(rect.Left) || (x >= (rect.Right -1) && x <= rect.Right);    
        }

		public static bool IsYBorder(this Rectangle rect, float y)
		{
			return y.EqualsTo(rect.Top) || (y >= (rect.Bottom - 1) && y <= rect.Bottom);
		}

        public static void Iterate(this Rectangle rect, Action<float, float> step, float stepSize = 1f)
        {
            for (var x = rect.Left; x < rect.Right; x += stepSize)
            {
				for (var y = rect.Top; y < rect.Bottom; y += stepSize)
				{
                    step(x, y);
				}
            }
        }
	}
}
