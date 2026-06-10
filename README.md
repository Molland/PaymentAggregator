# Кейсы платежного агрегатора. Тестовое задание / Payment Aggregator Cases. Test Task

[RU](#ru) | [ENG](#eng)

---

<a name="ru"></a>
## [RU] Инструкция по запуску

### Инструкция по развертыванию:
1. **Клонируйте/скачайте репозиторий**
2. **Настройка базы данных:**
   * Откройте файл `database.sql` в MS SQL Server Management Studio (SSMS).
   * Выполните скрипт для автоматического создания структуры таблиц и заполнения базы данных тестовыми данными.
3. **Конфигурация приложения:**
   * Откройте файл `Web.config` в корне проекта.
   * Найдите строку подключения `DefaultConnection`.
   * При необходимости измените `Data Source` на адрес вашего локального экземпляра MS SQL Server.
4. **Запуск:**
   * Откройте файл решения (`.sln`) в Visual Studio.
   * Дождитесь восстановления NuGet-пакетов.
   * Запустите проект на локальном сервере (IIS Express).

### Возможные проблемы и их решение:

#### Ошибка: `DirectoryNotFoundException: Не удалось найти часть пути ... \bin\roslyn\csc.exe`
Если при первом запуске приложения возникает ошибка сервера с упоминанием отсутствия компилятора в папке `bin\roslyn\`(скорее всего она будет), выполните следующие шаги:
1. В Visual Studio откройте **Средства** ➔ **Менеджер пакетов NuGet** ➔ **Консоль менеджера пакетов**.
2. Введите команду для переустановки пакета компилятора и нажмите Enter:
   ```shell
   Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -reinstall
   ```
3. В верхнем меню выберите **Сборка** ➔ **Пересобрать решение**.

---

<a name="eng"></a>
## [ENG] Setup Instructions

### Deployment Steps:
1. **Clone/Download the repository**
2. **Database Setup:**
   * Open the `database.sql` file in MS SQL Server Management Studio (SSMS).
   * Execute the script to automatically create the table structure and populate the database with test data.
3. **Application Configuration:**
   * Open the `Web.config` file in the project root.
   * Locate the `DefaultConnection` connection string.
   * If necessary, change the `Data Source` to the address of your local MS SQL Server instance.
4. **Run the Project:**
   * Open the solution file (`.sln`) in Visual Studio.
   * Wait for NuGet packages to restore automatically.
   * Run the project on the local server (IIS Express).

### Troubleshooting:

#### Error: `DirectoryNotFoundException: Could not find a part of the path ... \bin\roslyn\csc.exe`
If you encounter a server error indicating that the compiler is missing from the `bin\roslyn\` directory upon startup (which is highly likely), follow these steps:
1. In Visual Studio, navigate to **Tools** ➔ **NuGet Package Manager** ➔ **Package Manager Console**.
2. Run the following command to reinstall the compiler platform package and press Enter:
   ```shell
   Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -reinstall
   ```
3. In the top menu, select **Build** ➔ **Rebuild Solution**.
---
