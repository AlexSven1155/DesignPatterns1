namespace DesignPatterns
{
	/// <summary>
	/// Набор строковых констант игры.
	/// </summary>
	public static class StringHelper
	{
		/// <summary>
		/// Строка ошибки для некорректных численных параметров.
		/// </summary>
		public static string IncorrectNumericValue => "Аргумент {0} не может быть равен или меньше нуля.";

		/// <summary>
		/// Строка ошибки для некорректных параметров перечислений.
		/// </summary>
		public static string IncorrectEnumValue => "Неожиданное значение перечисления {0}.";

		/// <summary>
		/// Имена файлов для репозитория.
		/// </summary>
		public static class NameFiles
		{
			/// <summary>
			/// название файла для репозитория оружия.
			/// </summary>
			public static string GunData => "GunData.dat";

			/// <summary>
			/// Название файла для репозитория подвесок.
			/// </summary>
			public static string SuspensionData => "SuspensionData.dat";

			/// <summary>
			/// Название файла для репозитория кузовов.
			/// </summary>
			public static string BodyMachineData => "BodyMachineData.dat";

			/// <summary>
			/// Название файла для репозитория данных игроков.
			/// </summary>
			public static string SavedUserData => "SavedUserData.dat";
		}
	}
}