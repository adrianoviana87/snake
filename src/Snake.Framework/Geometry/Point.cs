using System;
using System.Diagnostics;
using Snake.Framework.Animations;

namespace Snake.Framework.Geometry
{
    /// <summary>
    /// An immutable 2D point.
    /// </summary>
	[DebuggerDisplay("{X}, {Y}")]
    public struct Point
    {
        public static readonly Point Zero = new Point(0, 0);
        public static readonly Point HalfOne = new Point(0.5f, 0.5f);
        public static readonly Point One = new Point(1, 1);
        public static readonly Point Two = new Point(2, 2);

        private readonly float x;
        private readonly float y;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

		public Point(float xy)
		{
			this.x = xy;
			this.y = xy;
		}

        public float X
        {
            get
            {
                return x;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
        }

        public double DistanceFrom(Point other)
        {
            return Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Point))
            {
                return false;
            }

            return ((Point)obj) == this;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + x.GetHashCode();
                hash = hash * 23 + y.GetHashCode();

                return hash;
            }
        }

        public override string ToString()
        {
            return string.Format("X={0}, Y={1}", X, Y);
        }

        public static Point Lerp(Point from, Point to, float time)
        {
            return new Point(
                Easing.Linear.Calculate(from.x, to.x, time),
                Easing.Linear.Calculate(from.y, to.y, time));
        }

        public static bool operator == (Point a, Point b)
        {
            return a.x.EqualsTo(b.x) && a.y.EqualsTo(b.y);
        }

		public static bool operator !=(Point a, Point b)
		{
            return !(a == b);
		}

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);   
        }

		public static Point operator -(Point a, Point b)
		{
			return new Point(a.x - b.x, a.y - b.y);
		}

		public static Point operator *(Point a, Point b)
		{
			return new Point(a.x * b.x, a.y * b.y);
		}
	}
}