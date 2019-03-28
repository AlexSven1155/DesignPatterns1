namespace DesignPatterns.AbstractFactoryPattern.StaticObject.Factories
{
	using System;
	using BaseClasses;
	using Enums;

	/// <summary>
	/// Металлолом.
	/// </summary>
	[Serializable]
	public class ScrapMetal : StaticObjectBaseFactory
	{
		public ScrapMetal() { }

		public ScrapMetal(int level = 1)
		{
			Name = "Металлолом";
			Price = level * new Random().Next(10, 1000);
			Size = Math.Max(Price / 100, 1);
			Type = StaticObjectType.Armor;
		}
	}
}
