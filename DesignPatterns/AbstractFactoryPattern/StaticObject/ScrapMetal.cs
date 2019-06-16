namespace DesignPatterns.AbstractFactoryPattern.StaticObject
{
	using BaseClasses;
	using Enums;
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Металлолом.
	/// </summary>
	[Serializable]
	public class ScrapMetal : BaseStaticObject
	{
		public ScrapMetal(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Создать металлолом.
		/// </summary>
		public ScrapMetal(int userLevel)
		{
			if (userLevel <= 0)
			{
				throw new NullReferenceException(string.Format(StringHelper.IncorrectNumericValue, nameof(userLevel)));
			}

			Name = "Металлолом";
			Price = userLevel * new Random().Next(10, 1000);
			Size = Math.Max(Price / 100, 1);
			Type = StaticObjectType.Armor;
		}
	}
}