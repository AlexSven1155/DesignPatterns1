namespace DesignPatterns.AbstractFactoryPattern.StaticObject.Factories
{
	using Interfaces;

	/// <summary>
	/// Фабрика запчастей.
	/// </summary>
	public class RepairPartsFactory : IBaseStaticObjectFactory
	{
		/// <summary>
		/// Получить запчасти.
		/// </summary>
		/// <returns>Экземпляр класса запчастей.</returns>
		public IBaseStaticObject GetStaticObject(int level)
		{
			return new RepairParts(level);
		}
	}
}
