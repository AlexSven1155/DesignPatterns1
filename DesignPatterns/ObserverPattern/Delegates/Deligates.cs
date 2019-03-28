namespace DesignPatterns.ObserverPattern.Delegates
{
	using AbstractFactoryPattern.Machines.Interfaces;
	using AbstractFactoryPattern.StaticObject.Interfaces;

	/// <summary>
	/// Делегат для спауна лута во время движения машины.
	/// </summary>
	/// <returns>Объект.</returns>
	public delegate IBaseStaticObject DelegateOnMoveLoot();

	/// <summary>
	/// Делегат для спауна врагов во время движения машины.
	/// </summary>
	/// <returns>Враг</returns>
	public delegate IBaseMachine DelegateOnMoveEnemy();
}
