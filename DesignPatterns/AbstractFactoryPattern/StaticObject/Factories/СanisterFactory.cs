namespace DesignPatterns.AbstractFactoryPattern.StaticObject.Factories
{
	using Interfaces;

	/// <summary>
	/// Фабрика канистр.
	/// </summary>
	public class СanisterFactory : IBaseStaticObjectFactory
	{
		/// <summary>
		/// Получить канистру.
		/// </summary>
		/// <returns>Экземпляр класса канистры.</returns>
		public IBaseStaticObject GetStaticObject(int level)
		{
			return new Canister(level);
		}
	}
}
