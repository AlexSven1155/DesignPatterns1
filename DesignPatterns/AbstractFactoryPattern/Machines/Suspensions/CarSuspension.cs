

namespace DesignPatterns.AbstractFactoryPattern.Machines.Suspensions
{
	using Enums;
	using System;
	using BaseClasses;

	/// <summary>
	/// Лёгкая подвеска.
	/// </summary>
	[Serializable]
	public class CarSuspension : SuspensionBase
	{
		public CarSuspension()
		{
			MaxArmorPoints = 100;
			ArmorPoints = MaxArmorPoints;
			MaxLifePoints = 250;
			LifePoints = MaxLifePoints;
			Name = "Лёгкая подвеска";
			EnginePower = 500;
			CapacityFuelTank = 1000;
			FuelConsumption = 10;
			GasolineResidue = 0;
			Movement = MovementSuspension.Wheeled;
			Level = 1;
			SetSpeed();
		}
	}
}
