namespace DesignPatterns.AbstractFactoryPattern.StaticObject
{
	using BaseClasses;
	using Enums;
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Запчасти.
	/// </summary>
	[Serializable]
	public class RepairParts : BaseStaticObject
	{
		public RepairParts(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Создать запчасти.
		/// </summary>
		public RepairParts(int userLevel)
		{
			if (userLevel <= 0)
			{
				throw new NullReferenceException(string.Format(StringHelper.IncorrectNumericValue, nameof(userLevel)));
			}

			Name = "Запчасти";
			Price = userLevel * new Random().Next(10, 1000);
			Size = Math.Max(Price / 100, 1);
			Type = StaticObjectType.Life;
		}
	}
}