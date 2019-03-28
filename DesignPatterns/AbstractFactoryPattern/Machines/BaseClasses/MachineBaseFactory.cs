namespace DesignPatterns.AbstractFactoryPattern.Machines.BaseClasses
{
	using Interfaces;

	/// <summary>
	/// Абстрактная фабрика машин.
	/// </summary>
	public abstract class MachineBaseFactory : IBaseMachinePart
	{
		/// <summary>
		/// Название машины.
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// Уровень машины.
		/// </summary>
		public int Level { get; protected set; }

		/// <summary>
		/// Количество прочности машины.
		/// </summary>
		public int LifePoints { get; protected set; }

		/// <summary>
		/// Максимальное количество очков жизней.
		/// </summary>
		public int MaxLifePoints { get; protected set; }

		/// <summary>
		/// Количество брони машины.
		/// </summary>
		public int ArmorPoints { get; protected set; }

		/// <summary>
		/// Максимальное количество очков брони.
		/// </summary>
		public int MaxArmorPoints { get; protected set; }

		/// <summary>
		/// Степень защиты брони.
		/// </summary>
		public int ArmorResistance { get; protected set; }

		/// <summary>
		/// Создать тип машины.
		/// </summary>
		/// <returns>Тип машины.</returns>
		public abstract BodyMachineBase GetBody();

		/// <summary>
		/// Создать способ передвижения машины.
		/// </summary>
		/// <returns>Способ передвижения.</returns>
		public abstract SuspensionBase GetSuspension();

		/// <summary>
		/// Создать оружие.
		/// </summary>
		/// <returns>Оружие.</returns>
		public abstract GunBase GetGun();
	}
}
