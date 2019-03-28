namespace DesignPatterns.AbstractFactoryPattern.Machines.Interfaces
{
	using BaseClasses;

	/// <summary>
	/// Базовая машина.
	/// </summary>
	public interface IBaseMachine : IBaseMachinePart
	{
		/// <summary>
		/// Очки жизней.
		/// </summary>
		int LifePoints { get; }

		/// <summary>
		/// Очки брони.
		/// </summary>
		int ArmorPoints { get; }

		/// <summary>
		/// Подвеска.
		/// </summary>
		/// <returns>Экземпляр подвески</returns>
		Suspension Suspension { get; }

		/// <summary>
		/// Кузов.
		/// </summary>
		/// <returns>Экземпляр кузова.</returns>
		BodyMachine Body { get; }

		/// <summary>
		/// Оружие.
		/// </summary>
		/// <returns>Экземпляр оружия.</returns>
		Gun Gun { get; }

		/// <summary>
		/// Получить урон.
		/// </summary>
		/// <param name="damage">Количество урона.</param>
		/// <returns>Полученный урон.</returns>
		int GetDamage(int damage);

		/// <summary>
		/// Передвижение.
		/// Во время движения тратится бензин.
		/// </summary>
		/// <param name="distance">Дистанция.</param>
		/// <returns>
		/// Результат движения.
		/// Может возвращать объекты типа StaticObject, Machine или string, int.
		/// </returns>
		int Move(int distance);

		/// <summary>
		/// Заправить бак.
		/// </summary>
		/// <param name="amountFuel">Количество бензина для заправки.</param>
		/// <returns>Количество бензина после заправки.</returns>
		int TankUp(int amountFuel);
	}
}
