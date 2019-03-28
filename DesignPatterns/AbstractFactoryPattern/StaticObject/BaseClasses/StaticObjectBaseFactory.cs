namespace DesignPatterns.AbstractFactoryPattern.StaticObject.BaseClasses
{
	using Enums;

	/// <summary>
	/// Базовый класс статичного объекта.
	/// </summary>
	public abstract class StaticObjectBaseFactory
	{
		/// <summary>
		/// Имя.
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// Ценность.
		/// </summary>
		public int Price { get; protected set; }

		/// <summary>
		/// Тип лута.
		/// </summary>
		public StaticObjectType Type { get; protected set; }

		/// <summary>
		/// Размер объекта.
		/// </summary>
		public int Size { get; protected set; }
	}
}
