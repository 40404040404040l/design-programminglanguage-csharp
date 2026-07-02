# design-programminglanguage-csharp

Репозиторий с лабораторными работами по проектированию и программированию на C#. Все работы построены вокруг одного домена: каталога песен, который можно просматривать, пополнять, искать и очищать от записей.

Проект показывает постепенное развитие решения: от простой консольной программы с JSON-файлом до приложения с паттерном Chain of Responsibility и Web API на ASP.NET Core.

## Состав репозитория

```text
.
├── Lab1Design/   # Консольный каталог песен + тесты
├── Lab2Design/   # Консольная версия с Chain of Responsibility и PostgreSQL
└── Lab3Design/   # ASP.NET Core Web API для каталога песен
```

## Стек

- C#;
- .NET 8;
- xUnit;
- Entity Framework Core;
- PostgreSQL;
- ASP.NET Core Web API;
- Swagger;
- Docker Compose для PostgreSQL.

## Lab1Design

Первая версия каталога песен в виде консольного приложения.

Возможности:

- вывести все песни;
- найти песню по названию или автору;
- добавить новую песню;
- удалить песню;
- сохранить изменения в JSON-файл.

Ключевые файлы:

```text
Lab1Design/Lab1Design/Program.cs
Lab1Design/Lab1Design/SongDirectory/Song.cs
Lab1Design/Lab1Design/SongCatalogDirectory/SongCatalog.cs
Lab1Design/Lab1Design/songs.json
Lab1Design/Lab1DesignTests/SongTests.cs
```

Запуск:

```bash
cd Lab1Design
dotnet run --project Lab1Design/Lab1Design.csproj
```

Тесты:

```bash
cd Lab1Design
dotnet test
```

## Lab2Design

Вторая версия консольного приложения. Основной акцент сделан на обработке пользовательских команд через паттерн **Chain of Responsibility**.

Команды обрабатываются отдельными handler-классами:

- `AddRequestHandler`;
- `ListRequestHandler`;
- `SearchRequestHandler`;
- `DelRequestHandler`;
- `QuitRequestHandler`.

Ключевые файлы:

```text
Lab2Design/Lab2Design/Program.cs
Lab2Design/Lab2Design/ResponsibilityChain/
Lab2Design/Lab2Design/SongCatalogDirectory/
Lab2Design/Lab2Design/DbContext.cs
Lab2Design/docker-compose.yml
```

Запуск PostgreSQL:

```bash
cd Lab2Design
docker compose up -d
```

Запуск приложения:

```bash
cd Lab2Design
dotnet run --project Lab2Design/Lab2Design.csproj
```

## Lab3Design

Третья версия реализована как ASP.NET Core Web API. Приложение работает с каталогом песен через HTTP endpoints и хранит данные в PostgreSQL через Entity Framework Core.

Ключевые файлы:

```text
Lab3Design/Lab3Design/Program.cs
Lab3Design/Lab3Design/Controllers/songController.cs
Lab3Design/Lab3Design/Models/
Lab3Design/Lab3Design/Configurations/
Lab3Design/docker-compose.yml
```

Запуск PostgreSQL:

```bash
cd Lab3Design
docker compose up -d
```

Запуск API:

```bash
cd Lab3Design
dotnet run --project Lab3Design/Lab3Design.csproj
```

Swagger UI в development-режиме будет доступен по адресу, который выведет `dotnet run`, обычно:

```text
https://localhost:7xxx/swagger
```

## API Lab3Design

Контроллер использует маршрут:

```text
api/Songs/{action}
```

Основные endpoints:

| Метод | Endpoint | Назначение |
| --- | --- | --- |
| `GET` | `/api/Songs/GetSongs` | Получить все песни |
| `GET` | `/api/Songs/GetSongsByCriteria?criteria=value` | Найти песни по названию или автору |
| `POST` | `/api/Songs/AddSong?name=...&author=...` | Добавить песню |
| `DELETE` | `/api/Songs/DeleteSongContent?name=...&author=...` | Удалить песню |

## Настройка базы данных

В `Lab3Design/Lab3Design/appsettings.json` используется строка подключения:

```json
"DbConnectionString": "User ID=myuser;Password=123123;Host=localhost;Port=5432;Database=postgres;"
```

Docker Compose поднимает PostgreSQL с такими же учетными данными:

```yaml
POSTGRES_USER: myuser
POSTGRES_PASSWORD: 123123
POSTGRES_DB: mydatabase
```

При необходимости измените строку подключения под свою локальную базу.

## Полезные команды

Сборка всех решений:

```bash
dotnet build Lab1Design/Lab1Design.sln
dotnet build Lab2Design/Lab2Design.sln
dotnet build Lab3Design/Lab3Design.sln
```

Запуск тестов первой лабораторной:

```bash
dotnet test Lab1Design/Lab1Design.sln
```

Остановка PostgreSQL:

```bash
cd Lab3Design
docker compose down
```

## Учебная цель

Репозиторий демонстрирует несколько подходов к разработке одного и того же домена:

- работа с моделями и интерфейсами;
- хранение данных в файле и базе данных;
- разбиение консольных команд на обработчики;
- подключение Entity Framework Core;
- создание простого REST API на ASP.NET Core;
- покрытие базовой логики тестами.
