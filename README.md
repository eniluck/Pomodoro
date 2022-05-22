## команды миграции

- добавить миграцию InitialCreate в проект
dotnet ef migrations add InitialCreate --project Pomodoro.DAL.Postgres --startup-project Pomodoro.API --context PomodoroDbContext --verbose

- удалить последнюю миграцию из проекта
dotnet ef migrations remove --project Pomodoro.DAL.Postgres --startup-project Pomodoro.API --context PomodoroDbContext --verbose

- применить миграции к бд
dotnet ef database update --project Pomodoro.DAL.Postgres --startup-project Pomodoro.API --context PomodoroDbContext --connection "Host=localhost;Port=5432;Database=Pomodoro;Username=postgres;Password=postgres" --verbose

- применить выбранную миграцию к бд
dotnet ef database update <previous-migration-name>

- удалить бд
dotnet ef database drop --project Pomodoro.DAL.Postgres --startup-project Pomodoro.API --context PomodoroDbContext --verbose

## Seq web интерфейс доступен по адресу:
http://localhost:5340

## Jaeger web ui
http://localhost:16686

## Настройка пароля к бд
1. В командной строке перейти в папку с проектом Pomodoro.Api
2. Выполнить команду: dotnet user-secrets init
3. Выполнить команду: dotnet user-secrets set "Password" "postgres"