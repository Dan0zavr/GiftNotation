using System.Configuration;
using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GiftNotation.ViewModels;
using GiftNotation.Services;
using GiftNotation.Data;
using GiftNotation.Views;
using GiftNotation.Commands;
using GiftNotation.State.Navigators;
using Microsoft.Extensions.Hosting;
using GiftNotation.ViewModels.Factories;
using Microsoft.Extensions.Configuration;
using GiftNotation.Commands.GiftCommands;


namespace GiftNotation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) =>
                {
                    string connectionString = context.Configuration.GetConnectionString("default");

                    // Регистрация DbContext
                    services.AddDbContext<GiftNotationDbContext>(options =>
                        options.UseSqlite(connectionString));

                    // Регистрация ViewModels
                    services.AddScoped<ContactViewModel>();
                    services.AddScoped<AddGiftViewModel>();
                    services.AddScoped<ChangeGiftViewModel>();
                    services.AddScoped<EventViewModel>();
                    services.AddScoped<AddEventViewModel>();
                    services.AddScoped<GiftViewModel>();
                    services.AddScoped<MainViewModel>();
                    services.AddScoped<CalendarViewModel>();
                    services.AddScoped<FiltersViewModel>();

                    // Регистрация Navigator как Singleton
                    services.AddSingleton<INavigator, Navigator>();

                    // Регистрация сервисов
                    services.AddScoped<GiftService>();
                    services.AddScoped<ContactService>();
                    services.AddScoped<EventService>();
                    services.AddScoped<FilterWindowService>();
                    services.AddScoped<FilterService>();

                    services.AddScoped<AddGiftCommand>();

                    services.AddSingleton<OpenCloseFilterCommand>();

                    // Регистрация фабрик как Scoped
                    services.AddScoped<IGiftNotationViewModelAbstractFactory, GiftNotationViewModelAbstractFactory>();
                    services.AddScoped<IGiftNotationViewModelFactory<CalendarViewModel>, HomeViewModelFactory>();

                    // Регистрация MainWindow
                    services.AddSingleton<MainWindow>();

                    // Регистрация команды
                    services.AddScoped<UpdateCurrentVMCommand>();

                    // Регистрация команды OpenCloseFilterCommand
                    services.AddSingleton<OpenCloseFilterCommand>();


                });
        }

        private NotificationService _notificationService;


        private async Task CheckEventsOnStartup()
        {
            // Получаем все предстоящие события
            var upcomingEvents = await _notificationService.GetAllUpcomingEventsAsync();

            // Проверяем, если есть события, которые нужно напомнить
            _notificationService.CheckNextEvents(upcomingEvents);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            // Запускаем хост
            _host.Start();

            // Создаем scope для работы с сервисами
            using (var scope = _host.Services.CreateScope())
            {
                // Получаем DbContext
                var context = scope.ServiceProvider.GetRequiredService<GiftNotationDbContext>();

                // Применяем миграции
                context.Database.Migrate();

                // Создаем экземпляр NotificationService
                _notificationService = new NotificationService(context);

                // Проверяем праздники при запуске приложения
                await CheckEventsOnStartup();
            }

            // Запуск главного окна
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = _host.Services.GetRequiredService<MainViewModel>();
            mainWindow.Show();

            base.OnStartup(e);
        }


        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }



}
