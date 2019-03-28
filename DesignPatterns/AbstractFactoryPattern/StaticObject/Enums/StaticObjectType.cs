namespace DesignPatterns.AbstractFactoryPattern.StaticObject.Enums
{
	using System;

	/// <summary>
	/// Типы лута.
	/// </summary>
	[Serializable]
	public enum StaticObjectType
	{
		/// <summary>
		/// Бензин.
		/// </summary>
		Petrol = 0,

		/// <summary>
		/// Броня.
		/// </summary>
		Armor = 1,

		/// <summary>
		/// Жизни.
		/// </summary>
		Life = 2,

		/// <summary>
		/// Мусор.
		/// </summary>
		Trash = 3
	}
}
