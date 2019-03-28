namespace DesignPatterns.AbstractFactoryPattern.StaticObject.Interfaces
{
	using Enums;
	using System.Runtime.Serialization;

	/// <summary>
	/// Интерфейс объекта.
	/// </summary>
	public interface IBaseStaticObject : ISerializable
	{
		/// <summary>
		/// Имя.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Ценность.
		/// </summary>
		int Price { get; }

		/// <summary>
		/// Тип объекта.
		/// </summary>
		StaticObjectType Type { get; }

		/// <summary>
		/// Размер объекта.
		/// </summary>
		int Size { get; }

		/// <summary>
		/// Использовать объект.
		/// </summary>
		/// <param name="quantity">Количество ценности, потраченной для использования.</param>
		/// <returns>Успешность действия.</returns>
		bool Use(int quantity);
	}
}
