namespace DesignPatterns.AbstractFactoryPattern.StaticObject.Factories
{
	using Interfaces;

	/// <summary>
	/// Фабрика металлолома.
	/// </summary>
	public class ScrapMetalFactory : IBaseStaticObjectFactory
	{
		/// <summary>
		/// Получить запчасти.
		/// </summary>
		/// <returns>Экземпляр класса запчастей.</returns>
		public IBaseStaticObject GetStaticObject(int level)
		{
			return new ScrapMetal(level);
		}
	}
}
