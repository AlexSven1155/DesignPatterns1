using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DesignPatterns.ProcessingData
{
	using UserContext;
	using AbstractFactoryPattern.Machines.BaseClasses;

	/// <summary>
	/// Класс данных игры.
	/// </summary>
	public static class Repository<T> where T : ISerializable
	{
		private static readonly Dictionary<string, IRepositoryTable<T>> DataCollection = new Dictionary<string, IRepositoryTable<T>>();

		public static IRepositoryTable<T> GetTable(string path)
		{
			if (DataCollection.Keys.Any(e => e == path))
			{
				return DataCollection[path];
			}

			AddData(path);

			if (DataCollection.Keys.Any(e => e == path))
			{
				return DataCollection[path];
			}

			return null;
		}

		public static void AddData(string path)
		{
			if (DataCollection.Keys.Any(e => e == path))
			{
				return;
			}

			try
			{
				DataCollection.Add(path, new RepositoryTable<T>(path));
			}
			catch
			{
				// ignored
			}
		}
	}
}
