## команды миграции

- добавить миграцию InitialCreate в проект
dotnet ef migrations add InitialCreate --project Pomodoro.DAL.Postgres --startup-project Pomodoro.API --context PomodoroDbContext --verbose

- удалить последнюю миграцию из проекта
dotnet ef migrations remove --project Pomodoro.DAL.Postgres --startup-project Pomodoro.API --context PomodoroDbContext --verbose

- применить миграции к бд
dotnet ef database update --project Pomodoro.DAL.Postgres --startup-project Pomodoro.API --context PomodoroDbContext --verbose

- удалить бд
dotnet ef database drop --project Pomodoro.DAL.Postgres --startup-project Pomodoro.API --context PomodoroDbContext --verbose

#Seq web интерфейс доступен по адресу:
http://localhost:5340

#Jaeger web ui
http://localhost:16686