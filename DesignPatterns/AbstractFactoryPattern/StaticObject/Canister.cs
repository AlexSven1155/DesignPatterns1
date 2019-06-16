namespace DesignPatterns.AbstractFactoryPattern.StaticObject
{
	using BaseClasses;
	using Enums;
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Канистра.
	/// </summary>
	[Serializable]
	public class Canister : BaseStaticObject
	{

		public Canister(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Создать канистру.
		/// </summary>
		/// <param name="userLevel">Текущий уровень игрока.</param>
		public Canister(int userLevel)
		{
			if (userLevel <= 0)
			{
				throw new NullReferenceException(string.Format(StringHelper.IncorrectNumericValue, nameof(userLevel)));
			}

			Name = "Канистра";
			Price = userLevel * new Random().Next(10, 1000);
			Size = Math.Max(Price / 100, 1);
			Type = StaticObjectType.Petrol;
		}

	}
}