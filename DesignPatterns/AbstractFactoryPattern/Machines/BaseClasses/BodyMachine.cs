namespace DesignPatterns.AbstractFactoryPattern.Machines.BaseClasses
{
	using DesignPatterns.AbstractFactoryPattern.StaticObject.Interfaces;
	using Interfaces;
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	/// <summary>
	/// Базовый кузов машины.
	/// </summary>
	[Serializable]
	public class BodyMachine : IBaseMachinePart, ISerializable
	{
		/// <summary>
		/// Базовый конструктор.
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="level">Уровень</param>
		/// <param name="maxLifePoints">Максимальное количество жизней</param>
		/// <param name="maxArmorPoints">Максимальное количество брони</param>
		/// <param name="armorResistance">Сопротивление брони</param>
		/// <param name="sizeInventory">Размер инвентаря</param>
		/// <param name="inventory">Содежимое инвентаря</param>
		public BodyMachine(string name,
			int level,
			int maxLifePoints,
			int maxArmorPoints,
			int armorResistance,
			int sizeInventory,
			List<IBaseStaticObject> inventory = null)
		{
			Name = string.IsNullOrEmpty(name)
				? throw new ArgumentNullException(nameof(name))
				: name;

			Level = level <= 0
				? throw new ArgumentNullException(nameof(level))
				: level;

			MaxLifePoints = maxLifePoints <= 0
				? throw new ArgumentNullException(nameof(maxLifePoints))
				: maxLifePoints;

			MaxArmorPoints = maxArmorPoints <= 0
				? throw new ArgumentNullException(nameof(maxArmorPoints))
				: maxArmorPoints;

			ArmorResistance = armorResistance <= 0
				? throw new ArgumentNullException(nameof(armorResistance))
				: armorResistance;

			SizeInventory = sizeInventory <= 0
				? throw new ArgumentNullException(nameof(sizeInventory))
				: sizeInventory;

			Inventory = inventory ?? new List<IBaseStaticObject>();
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Уровень.
		/// </summary>
		public int Level { get; set; }

		/// <summary>
		/// Максимальное количество очков жизней.
		/// </summary>
		public int MaxLifePoints { get; set; }

		/// <summary>
		/// Максимальное количество очков брони.
		/// </summary>
		public int MaxArmorPoints { get; set; }

		/// <summary>
		/// Сопротивление брони.
		/// </summary>
		public int ArmorResistance { get; set; }

		/// <summary>
		/// Размер инвентаря.
		/// </summary>
		public int SizeInventory { get; set; }

		/// <summary>
		/// Инвентарь.
		/// </summary>
		public List<IBaseStaticObject> Inventory { get; set; }

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Name", Name);
			info.AddValue("Level", Level);
			info.AddValue("MaxLifePoints", MaxLifePoints);
			info.AddValue("MaxArmorPoints", MaxArmorPoints);
			info.AddValue("ArmorResistance", ArmorResistance);
			info.AddValue("SizeInventory", SizeInventory);
			info.AddValue("Inventory", Inventory);
		}

		public BodyMachine(SerializationInfo info, StreamingContext context)
		{
			Name = (string)info.GetValue("Name", typeof(string));
			Level = (int)info.GetValue("Level", typeof(int));
			MaxLifePoints = (int)info.GetValue("MaxLifePoints", typeof(int));
			MaxArmorPoints = (int)info.GetValue("MaxArmorPoints", typeof(int));
			ArmorResistance = (int)info.GetValue("ArmorResistance", typeof(int));
			SizeInventory = (int)info.GetValue("SizeInventory", typeof(int));
			Inventory = (List<IBaseStaticObject>)info.GetValue("Inventory", typeof(List<IBaseStaticObject>));
		}

		public override string ToString()
		{
			return $"Название: {Name}{Environment.NewLine}" +
				   $"Макс хп: {MaxLifePoints}{Environment.NewLine}" +
				   $"Макс брони: {MaxArmorPoints}{Environment.NewLine}" +
				   $"Уровень: {Level}{Environment.NewLine}" +
				   $"Защита брони: {ArmorResistance}{Environment.NewLine}" +
				   $"Размер инвентаря: {SizeInventory}";
		}
	}
}