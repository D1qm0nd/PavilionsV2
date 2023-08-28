# PavilionsV2
Практика C#

# Требуется
MS SQL Server 2019+
- OS Windows 10+
- .NET CORE 6+
- .NET CORE RUNTIME 6+
# Установка и настрока базы данных 
1. Создать переменную в переменной среде
- Название переменной: PAVILIONS_CONNECTION
- Значение переменной: Server=LOCALHOST; Initial Catalog=PavilionsDB; Integrated Security=True; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=true
2. Запустите UNIT тесты "Tests"
3. Запустите планировщик заданий 
3.1 Создайте простую задачу на выполнение файла Backup.bat лежащий в папке решения, задав аргументы через пробел
# Стандартные аргументы для строки подключения 
- LOCALHOST <путь к месту хранения бэкапов>

Пользуйтесь
