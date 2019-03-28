namespace DesignPatterns.AbstractFactoryPattern.Machines.Interfaces
{
	using BaseClasses;

	/// <summary>
	/// Интерфейс базовой фабрики машин.
	/// </summary>
	public interface IBasicMachineFactory
	{
		/// <summary>
		/// Создать оружие для машины.
		/// </summary>
		/// <returns>Экземпляр оружия.</returns>
		Gun CreateGun();

		/// <summary>
		/// Создать подвеску.
		/// </summary>
		/// <returns>Экземпляр подвески.</returns>
		Suspension CreateSuspension();

		/// <summary>
		/// Создать кузов.
		/// </summary>
		/// <returns>Экземпляр кузова.</returns>
		BodyMachine CreateBody();
	}
}
