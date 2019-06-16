namespace DesignPatterns.ProcessingData
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;

	/// <summary>
	/// Класс-сереализатор для работы с файлами данных игры.
	/// </summary>
	public static class Serializer
	{
		/// <summary>
		/// Путь к папке с сохранениями.
		/// </summary>
		private static readonly string MainFolderPath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
			"DesignPatterns"
		);

		/// <summary>
		/// При инициализации создаёт каталог для данных.
		/// </summary>
		static Serializer()
		{
			if (!Directory.Exists(MainFolderPath))
			{
				Directory.CreateDirectory(MainFolderPath);
			}
		}

		/// <summary>
		/// Сериализация данных в файл.
		/// Если файла нет, то он создаётся.
		/// </summary>
		public static void SerializeUserData<T>(List<T> userData, string fileName)
		{
			using (var fileStream = File.Open(Path.Combine(MainFolderPath, fileName), FileMode.Create))
			{
				var bf = new BinaryFormatter();
				bf.Serialize(fileStream, userData);
			}
		}

		/// <summary>
		/// Десериализация данных из файла.
		/// </summary>
		public static List<T> DeserializeUserData<T>(string fileName)
		{
			if (!File.Exists(Path.Combine(MainFolderPath, fileName)))
			{
				return new List<T>();
			}

			using (var fileStream = File.Open(Path.Combine(MainFolderPath, fileName), FileMode.Open))
			{
				var bf = new BinaryFormatter();
				return (List<T>)bf.Deserialize(fileStream);
			}
		}
	}
}