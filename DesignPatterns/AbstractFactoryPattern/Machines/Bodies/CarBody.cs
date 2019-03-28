namespace DesignPatterns.AbstractFactoryPattern.Machines.Bodies
{
	using System;
	using BaseClasses;

	/// <summary>
	/// Кузов от легковушки.
	/// </summary>
	[Serializable]
	public class CarBody : BodyMachineBase
	{
		public CarBody()
		{
			MaxArmorPoints = 200;
			ArmorPoints = MaxArmorPoints;
			MaxLifePoints = 500;
			LifePoints = MaxLifePoints;
			ArmorResistance = 30;
			Name = "Кузов от легковушки";
			Level = 1;
			SizeInventory = 50;
		}
	}
}
