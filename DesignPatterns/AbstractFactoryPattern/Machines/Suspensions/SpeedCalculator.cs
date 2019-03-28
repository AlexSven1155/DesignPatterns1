namespace DesignPatterns.AbstractFactoryPattern.Machines.Suspensions
{
	using System;
	using Enums;

	/// <summary>
	/// Вычислитель скорости.
	/// </summary>
	public static class SpeedCalculator
	{
		/// <summary>
		/// Вычислить скорость.
		/// </summary>
		/// <returns>Скорость.</returns>
		public static int GetSpeed(MovementSuspension movementSuspension, int enginePower)
		{
			switch (movementSuspension)
			{
				case MovementSuspension.Flying:
					return enginePower * 80/100;
				case MovementSuspension.Walker:
					return enginePower * 25 / 100;
				case MovementSuspension.Wheeled:
					return enginePower * 50 / 100;
				default:
					throw new Exception($"Неожиданное значение перечисления: {nameof(MovementSuspension)}");
			}
		}
	}
}
