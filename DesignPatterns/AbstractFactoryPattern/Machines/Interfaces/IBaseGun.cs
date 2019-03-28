namespace DesignPatterns.AbstractFactoryPattern.Machines.Interfaces
{
	/// <summary>
	/// Интерфейс базового оружия.
	/// </summary>
	public interface IBaseGun
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
		/// Минимальный урон.
		/// </summary>
		int MinDamage { get; }

		/// <summary>
		/// Максимальный урон.
		/// </summary>
		int MaxDamage { get; }

		/// <summary>
		/// Выстрелить.
		/// </summary>
		/// <returns>Урон.</returns>
		int Shoot();
	}
}
