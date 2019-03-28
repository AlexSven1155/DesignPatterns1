namespace DesignPatterns.AbstractFactoryPattern.StaticObject.Interfaces
{
	/// <summary>
	/// Интерфейс базовой абстрактной фабрики Статичных объектов.
	/// </summary>
	public interface IBaseStaticObjectFactory
	{
		/// <summary>
		/// Получить экземпляр статичного объекта.
		/// </summary>
		/// <returns>Экземпляр статичного объекта.</returns>
		IBaseStaticObject GetStaticObject(int level);
	}
}
