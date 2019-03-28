namespace DesignPatterns.AbstractFactoryPattern.StaticObject
{
	using Enums;
	using System;
	using BaseClasses;
	using System.Xml.Serialization;

	/// <summary>
	/// Создать статичный объект.
	/// </summary>
	[Serializable]
	public class StaticObject
	{
		/// <summary>
		/// Имя.
		/// </summary>
		[XmlAttribute("Name")]
		public string Name { get; set; }

		/// <summary>
		/// Ценность.
		/// </summary>
		[XmlAttribute("Price")]
		public int Price { get; set; }

		/// <summary>
		/// Тип лута.
		/// </summary>
		[XmlAttribute("Type")]
		public StaticObjectType Type { get; set; }

		/// <summary>
		/// Размер объекта.
		/// </summary>
		[XmlAttribute("Size")]
		public int Size { get; set; }

		public StaticObject() { }

		/// <summary>
		/// Конструктор лута.
		/// </summary>
		/// <param name="factory">Фабрика.</param>
		public StaticObject(StaticObjectBaseFactory factory)
		{
			if (factory == null)
			{
				throw new NullReferenceException("Фабрика лута не может NULL!");
			}

			Name = factory.Name;
			Price = factory.Price;
			Size = factory.Size;
			Type = factory.Type;
		}

		/// <summary>
		/// Использовать.
		/// </summary>
		/// <param name="quantity">Сколько ресурсов использовать.</param>
		public bool Use(int quantity = 0)
		{
			if (Type == StaticObjectType.Trash || quantity > Price)
			{
				return false;
			}

			Price -= quantity;

			return true;
		}
	}
}
