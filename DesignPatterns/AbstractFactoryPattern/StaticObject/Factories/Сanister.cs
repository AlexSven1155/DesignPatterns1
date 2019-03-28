namespace DesignPatterns.AbstractFactoryPattern.StaticObject.Factories
{
	using Enums;
	using System;
	using BaseClasses;

	/// <summary>
	/// Канистра.
	/// </summary>
	[Serializable]
	public class Сanister : StaticObjectBaseFactory
	{
		public Сanister() { }

		public Сanister(int level = 1)
		{
			Name = "Канистра";
			Price = level * new Random().Next(10, 1000);
			Size = Math.Max(Price / 100, 1);
			Type = StaticObjectType.Petrol;
		}
	}
}
