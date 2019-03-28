namespace DesignPatterns.AbstractFactoryPattern.Machines.Interfaces
{
	/// <summary>
	/// Базовая часть машины.
	/// </summary>
	public interface IBaseMachinePart
	{
		/// <summary>
		/// Название.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Уровень.
		/// </summary>
		int Level { get; }

		/// <summary>
		/// Максимальное количество очков жизней.
		/// </summary>
		int MaxLifePoints { get; }

		/// <summary>
		/// Максимальное количество очков брони.
		/// </summary>
		int MaxArmorPoints { get; }

		/// <summary>
		/// Сопротивление брони.
		/// </summary>
		int ArmorResistance { get; }
	}
}
