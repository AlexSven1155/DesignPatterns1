using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DesignPatterns.ProcessingData
{
	/// <summary>
	/// Класс работы с файлами данных игры.
	/// </summary>
	public static class Serializer
	{
		/// <summary>
		/// Путь к основной папке.
		/// </summary>
		private static readonly string MainFolderPath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
			"DesignPatterns"
		);

		static Serializer()
		{
			if (!Directory.Exists(MainFolderPath))
			{
				Directory.CreateDirectory(MainFolderPath);
			}
		}

		/// <summary>
		/// Сериализация данных в файл.
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
				return null;
			}

			using (var fileStream = File.Open(Path.Combine(MainFolderPath, fileName), FileMode.Open))
			{
				var bf = new BinaryFormatter();
				return (List<T>)bf.Deserialize(fileStream);
			}
		}
	}
}
