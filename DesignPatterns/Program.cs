namespace DesignPatterns
{
	using AbstractFactoryPattern.Machines;
	using AbstractFactoryPattern.Machines.Factories;
	using AbstractFactoryPattern.Machines.Interfaces;
	using AbstractFactoryPattern.StaticObject.Interfaces;
	using MediatorPattern;
	using ObserverPattern.SpawnOnMove;
	using System;
	using System.Threading;
	using UserContext;

	class Program
	{
		/// <summary>
		/// Спаунер.
		/// </summary>
		private static Spawner _spawner;

		/// <summary>
		/// Сессия игрока.
		/// </summary>
		private static UserSession _userSession;

		static void Main(string[] args)
		{
			try
			{
				//раскомментировать если есть проблемы с отображением текста
				//Console.OutputEncoding = Encoding.UTF8;
				Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
				Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ!");
				Console.WriteLine("Ваше имя:");

				_userSession = new UserSession(Console.ReadLine());

				Console.WriteLine(_userSession.IsNew
					? $"Привет новичок {_userSession.UserData.UserName}!"
					: $"С возвращением {_userSession.UserData.UserName}!");

				Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
				Console.WriteLine("Enter чтобы продолжить...");
				Console.ReadLine();
				Console.Clear();
				MainMenu();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.ReadLine();
			}
		}

		/// <summary>
		/// Основное меню игры.
		/// </summary>
		static void MainMenu()
		{
			try
			{
				Console.Clear();
				Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
				Console.WriteLine("ГЛАВНОЕ МЕНЮ");
				Console.WriteLine("1.Начать игру\n" +
								  "2.Выйти из игры");
				switch (Console.ReadLine())
				{
					case "1":
						InitializeGame();
						break;
					case "2":
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Что-то ты не то ввёл! Попробуй снова!");
						Console.WriteLine("Enter чтобы продолжить...");
						Console.ReadLine();
						Console.Clear();
						MainMenu();
						break;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.ReadLine();
			}
		}

		/// <summary>
		/// Инициализация игровых данных.
		/// </summary>
		static void InitializeGame()
		{
			try
			{
				Console.Clear();

				if (_userSession.IsNew || _userSession.UserData.UserMachine.IsDead)
				{
					Console.WriteLine("Добро пожаловать в игру!\nВведите имя своей машины:");

					var nameMachine = Console.ReadLine();

					if (string.IsNullOrEmpty(nameMachine))
					{
						Console.WriteLine("Заполни имя машины!");
						Console.WriteLine("Enter чтобы продолжить...");
						Console.ReadLine();
						InitializeGame();
					}

					_userSession.AddMachine(new UserMachine(nameMachine, new MachineFactory(1)));
					_userSession.UserData.UserMachine.TankUp(
						_userSession.UserData.UserMachine.Suspension.CapacityFuelTank);
				}

				//инициализируем спаунер
				_spawner = new Spawner(_userSession.UserData.UserMachine);
				Traveler();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.ReadLine();
			}
		}

		/// <summary>
		/// Игровое меню.
		/// </summary>
		static void GameMenu()
		{
			Console.Clear();
			Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Console.WriteLine("ИГРОВОЕ МЕНЮ");
			Console.WriteLine("1.Продолжить\n" +
							  "2.Сохранить игру\n" +
							  "3.Загрузить игру\n" +
							  "4.Выйти в главное меню");
			switch (Console.ReadLine())
			{
				case "1":
					Traveler();
					break;
				case "2":
					try
					{
						_userSession.SaveGame();
						Console.WriteLine("Игра успешно сохранена!");
						Thread.Sleep(1000);
						GameMenu();
					}
					catch (Exception e)
					{
						Console.WriteLine("Не удалось сохранить игру!!!");
						Console.WriteLine(e.Message);
						Console.WriteLine("Enter чтобы продолжить...");
						Console.ReadLine();
						GameMenu();
					}
					break;
				case "3":
					try
					{
						if (_userSession.LoadGame())
						{
							Console.WriteLine("Игра успешно загружена!");
							Thread.Sleep(1000);
							GameMenu();
						}
						else
						{
							Console.WriteLine("Нет сохранённых данных!!!");
							Console.WriteLine("Enter чтобы продолжить...");
							Console.ReadLine();
							GameMenu();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Не удалось загрузить игру!!!");
						Console.WriteLine(e.Message);
						Console.WriteLine("Enter чтобы продолжить...");
						Console.ReadLine();
						GameMenu();
					}
					break;
				case "4":
					MainMenu();
					break;
				default:
					Console.WriteLine("Что-то ты не то ввёл! Попробуй снова!");
					Console.WriteLine("Enter чтобы продолжить...");
					Console.ReadLine();
					Console.Clear();
					MainMenu();
					break;
			}
		}

		/// <summary>
		/// Метод путешествия.
		/// </summary>
		static void Traveler()
		{
			Console.Clear();

			if (_userSession.UserData.UserMachine.Suspension.QuantityFuel == 0)
			{
				Console.WriteLine("У тебя кончился бензин. Ты пошёл пешком и умер от обезвоживания!!\nИгра окончена...");
				_userSession.UserData.UserMachine.IsDead = true;
				_userSession.UserData.UserStatistics.NumberOfDeaths += 1;
				Console.ReadLine();
				MainMenu();
			}

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Console.WriteLine("Выберите действие:\n");
			Console.WriteLine("1.Статус машины\n" +
							  "2.Ехать\n" +
							  "3.Выйти в меню");
			Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Console.ResetColor();

			var userResp = Console.ReadLine();
			Console.Clear();

			switch (userResp)
			{
				case "1":
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
					ShowUserMaсhineInfo();
					ShowUserInventoryInfo();
					Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
					Console.ResetColor();
					Console.ReadLine();
					Traveler();
					break;
				case "2":
					if (Move())
					{
						Traveler();
					}
					else
					{
						Console.WriteLine("Ты погиб где-то в пустошах.\nИгра окончена...");
						MainMenu();
					}
					break;
				case "3":
					GameMenu();
					break;
				default:
					Console.WriteLine("Что-то ты не то ввёл! Попробуй снова!");
					Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
					Console.ReadLine();
					Traveler();
					break;
			}
		}

		/// <summary>
		/// Движение - жизнь.
		/// </summary>
		/// <returns>true - игрок жив. false - мёртв.</returns>
		static bool Move()
		{
			Console.WriteLine("Как далеко?");
			if (!int.TryParse(Console.ReadLine(), out int distance))
			{
				Console.WriteLine("Нужно ввести целое число!");
				Thread.Sleep(500);
				Console.Clear();
				Move();
			}

			// Начинаем движение.
			var moveResult = _userSession.UserData.UserMachine.Move(distance);

			//Попался лут
			if (moveResult is IBaseStaticObject unboxStaticObject)
			{
				InteractionLoot(unboxStaticObject);
			}

			//Попался противник
			if (moveResult is IBaseMachine unboxEnemy)
			{
				return Battle(unboxEnemy);
			}

			//Движение прошло без находок и приключений
			if (moveResult is int)
			{
				_userSession.UserData.UserStatistics.KilometersCovered += (int)moveResult;
				Console.WriteLine($"Пройдено: {moveResult} км.");
			}

			Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Thread.Sleep(500);
			return true;
		}

		/// <summary>
		/// Взаимодействие с лутом.
		/// </summary>
		/// <param name="loot">Лут.</param>
		static void InteractionLoot(IBaseStaticObject loot)
		{
			Console.Clear();
			Console.WriteLine("Найден предмет:\n"
							  + $"--Имя: {loot.Name}\n"
							  + $"--Ценность: {loot.Price}\n"
							  + $"--Размер: {loot.Size}\n");

			var machineIntermediary = new MachineIntermediary(_userSession.UserData.UserMachine, loot);

			Console.WriteLine("Взять?");
			if (Console.ReadLine() == "1")
			{
				if (machineIntermediary.Take())
				{
					Console.WriteLine($"Предмет {loot.Name} в кузове!!!");
					_userSession.UserData.UserStatistics.ReceivedItems += 1;
				}
				else
				{
					Console.WriteLine("Нет места в кузове!!!\nОткрыть инвентарь?");
					if (Console.ReadLine() == "1")
					{
						ShowUserInventoryInfo();
						InteractionLoot(loot);
					}
				}
			}
		}

		/// <summary>
		/// Бой.
		/// </summary>
		/// <returns>Результат боя.</returns>
		static bool Battle(IBaseMachine enemy)
		{
			Console.Clear();
			Console.WriteLine("Обнаружен враг!:\n"
							  + $"--Жизней: {enemy.LifePoints}\n"
							  + $"--Брони: {enemy.ArmorPoints}\n"
							  + $"--Скорость: {enemy.Suspension.MaxSpeed}\n");
			if (enemy.Suspension.MaxSpeed < _userSession.UserData.UserMachine.Suspension.MaxSpeed)
			{
				Console.WriteLine("Я быстрее чем он, сбежать?");
				if (Console.ReadLine() == "1")
				{
					return true;
				}
			}

			while (true)
			{
				Console.Clear();
				Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
				Console.WriteLine("Состояние твоей машины:");
				ShowUserMaсhineInfo();
				Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
				Console.WriteLine("Состояние машины врага:");
				ShowEnemyInfo(enemy);
				Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
				Console.WriteLine(">>Выстрелить<<");
				Console.ReadLine();

				Console.WriteLine($"Враг получил урон:{Environment.NewLine} {enemy.GetDamage(_userSession.UserData.UserMachine.Gun.Shoot())}{Environment.NewLine}");
				Console.WriteLine($"Враг выстрелил>>{Environment.NewLine}" +
								  $"Вы получили урон:{Environment.NewLine} {_userSession.UserData.UserMachine.GetDamage(enemy.Gun.Shoot())}");
				Console.ReadLine();

				if (_userSession.UserData.UserMachine.LifePoints <= 0)
				{
					Console.WriteLine("Ты мёртв!");
					Thread.Sleep(1000);
					return false;
				}

				if (enemy.LifePoints <= 0)
				{
					_userSession.UserData.UserStatistics.EnemyKill += 1;
					Console.WriteLine("Победа!");
					Thread.Sleep(1000);
					return true;
				}
			}
		}

		/// <summary>
		/// Выводит на экран информацию о машине игрока.
		/// </summary>
		static void ShowUserMaсhineInfo()
		{
			Console.WriteLine($"--Имя: {_userSession.UserData.UserMachine.Name}{Environment.NewLine}"
							  + $"--Очки жизней: {_userSession.UserData.UserMachine.LifePoints}{Environment.NewLine}"
							  + $"--Очки брони: {_userSession.UserData.UserMachine.ArmorPoints}{Environment.NewLine}"
							  + $"--Бензин: {_userSession.UserData.UserMachine.Suspension.QuantityFuel}{Environment.NewLine}"
							  + $"--Скорость: {_userSession.UserData.UserMachine.Suspension.MaxSpeed}{Environment.NewLine}");
		}

		/// <summary>
		/// Выводит на экран информацию о противнике.
		/// </summary>
		/// <param name="enemy">Экземпляр противника.</param>
		static void ShowEnemyInfo(IBaseMachine enemy)
		{
			Console.WriteLine($"--Имя: {enemy.Name}{Environment.NewLine}"
							  + $"--Очки жизней: {enemy.LifePoints}{Environment.NewLine}"
							  + $"--Очки брони: {enemy.ArmorPoints}{Environment.NewLine}"
							  + $"--Бензин: {enemy.Suspension.QuantityFuel}{Environment.NewLine}"
							  + $"--Скорость: {enemy.Suspension.MaxSpeed}{Environment.NewLine}");
		}

		/// <summary>
		/// Выводит информацию о содержимом инвентаря игрока.
		/// </summary>
		static void ShowUserInventoryInfo()
		{
			Console.WriteLine("Инвентарь: свободно места: " + _userSession.UserData.UserMachine.CurrentSizeInventory());
			if (_userSession.UserData.UserMachine.Inventory.Count == 0)
			{
				Console.WriteLine("Пуст!");
			}
			else
			{
				Console.WriteLine("Название; Размер; Ценность");

				foreach (var item in _userSession.UserData.UserMachine.Inventory)
				{
					Console.WriteLine($"{item.Name}; {item.Size}; {item.Price}");
				}

				Console.WriteLine("Выберите предмет:");
				{
					var numberItem = Console.ReadLine();

					if (int.TryParse(numberItem, out int number))
					{
						if (_userSession.UserData.UserMachine.Inventory.Count < number)
						{
							ShowUserInventoryInfo();
						}

						var machineIntermediary = new MachineIntermediary(_userSession.UserData.UserMachine,
								_userSession.UserData.UserMachine.Inventory[number - 1]);

						Console.WriteLine($"Что с ним сделать?{Environment.NewLine}" +
										  $"1.Использовать{Environment.NewLine}" +
										  "2.Выбросить");
						switch (Console.ReadLine())
						{
							case "1":
								Console.WriteLine("Какое количество использовать?");
								if (int.TryParse(Console.ReadLine(), out int quantity))
								{
									if (machineIntermediary.Use(quantity))
									{
										Console.WriteLine("Предмет успешно использован!");
										_userSession.UserData.UserStatistics.UsedItems += 1;
									}
								}
								break;
							case "2":
								if (machineIntermediary.Turf())
								{
									Console.WriteLine("Предмет успешно выброшен!");
								}
								break;
						}
					}
					else
					{
						if (string.IsNullOrEmpty(numberItem))
						{
							return;
						}

						ShowUserInventoryInfo();
					}
				}
			}
		}
	}
}