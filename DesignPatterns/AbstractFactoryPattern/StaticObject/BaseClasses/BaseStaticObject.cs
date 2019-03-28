namespace DesignPatterns.AbstractFactoryPattern.StaticObject.BaseClasses
{
	using Enums;
	using Interfaces;
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Cтатичный объект.
	/// </summary>
	[Serializable]
	public abstract class BaseStaticObject : IBaseStaticObject
	{
		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Ценность.
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		/// Тип объекта.
		/// </summary>
		public StaticObjectType Type { get; set; }

		/// <summary>
		/// Размер объекта.
		/// </summary>
		public int Size { get; set; }

		protected BaseStaticObject() { }

		/// <summary>
		/// Использовать.
		/// </summary>
		/// <param name="quantity">Сколько ресурсов использовать.</param>
		/// <returns>Успешность использования.</returns>
		public bool Use(int quantity = 0)
		{
			if (quantity < 0)
			{
				throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(quantity));
			}

			if (Type == StaticObjectType.Trash || quantity > Price)
			{
				return false;
			}

			Price -= quantity;

			return true;
		}

		/// <summary>
		/// Реализация сериализации данных класса.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Name", Name);
			info.AddValue("Price", Price);
			info.AddValue("Size", Size);
			info.AddValue("Type", Type);
		}

		/// <summary>
		/// Конструктор для сериализатора.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected BaseStaticObject(SerializationInfo info, StreamingContext context)
		{
			Name = (string)info.GetValue("Name", typeof(string));
			Price = (int)info.GetValue("Price", typeof(int));
			Size = (int)info.GetValue("Size", typeof(int));
			Type = (StaticObjectType)info.GetValue("Type", typeof(StaticObjectType));
		}
	}
}
