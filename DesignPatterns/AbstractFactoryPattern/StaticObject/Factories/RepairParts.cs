namespace DesignPatterns.AbstractFactoryPattern.StaticObject.Factories
{
	using System;
	using BaseClasses;
	using Enums;

	/// <summary>
	/// Запчасти.
	/// </summary>
	[Serializable]
	public class RepairParts : StaticObjectBaseFactory
	{
		public RepairParts() { }

		public RepairParts(int level = 1)
		{
			Name = "Запчасти";
			Price = level * new Random().Next(10, 1000);
			Size = Math.Max(Price / 100, 1);
			Type = StaticObjectType.Life;
		}
	}
}
