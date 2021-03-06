﻿using System;

namespace Doog
{
  	/// <summary>
	/// An InElastic easing: accelerating from zero velocity.
	/// </summary>
	public class InElasticEasing : IEasing
    {
        /// <summary>
        /// Calculate the easing to the specified time.
        /// </summary>
        /// <param name="time">Time.</param>
        /// <returns>
        /// The easing to the time.
        /// </returns>
        public float Calculate(float time)
        {
            return (float) (Math.Sin(13 * EasingConstants.HalfPI * time) * Math.Pow(2, 10 * (time - 1)));
		}
    }

	/// <summary>
	/// An OutElastic easing: decelerating to zero velocity.
	/// </summary>
	public class OutElasticEasing : IEasing
	{
        /// <summary>
        /// Calculate the easing to the specified time.
        /// </summary>
        /// <param name="time">Time.</param>
        /// <returns>
        /// The easing to the time.
        /// </returns>
        public float Calculate(float time)
		{
            return (float)(Math.Sin(-13 * EasingConstants.HalfPI * (time + 1)) * Math.Pow(2, -10 * time) + 1);
		}
	}

	/// <summary>
	/// An InOutElastic easing.
	/// </summary>
	public class InOutElasticEasing : IEasing
	{
        /// <summary>
        /// Calculate the easing to the specified time.
        /// </summary>
        /// <param name="time">Time.</param>
        /// <returns>
        /// The easing to the time.
        /// </returns>
        public float Calculate(float time)
        {
			if (time < 0.5f)
			{
                return (float) (0.5f * Math.Sin(13 * EasingConstants.HalfPI * (2 * time)) * Math.Pow(2, 10 * ((2 * time) - 1)));
			}
			else
			{
                return (float) (0.5f * (Math.Sin(-13 * EasingConstants.HalfPI * ((2 * time - 1) + 1)) * Math.Pow(2, -10 * (2 * time - 1)) + 2));
			}
		}
	}
}
