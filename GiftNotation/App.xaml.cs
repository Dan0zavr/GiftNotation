using GiftNotation.Commands;
using GiftNotation.Commands.GiftCommands;
using GiftNotation.Data;
using GiftNotation.Services;
using GiftNotation.Services.Mediators;
using GiftNotation.State.Navigators;
using GiftNotation.ViewModels;
using GiftNotation.ViewModels.Factories;
using GiftNotation.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;


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
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) =>
                {
                    // Получение строки подключения
                    string connectionString = context.Configuration.GetConnectionString("default");

                    // Регистрация DbContext с областью Scoped
                    services.AddDbContext<GiftNotationDbContext>(options =>
                        options.UseSqlite(connectionString));

                    // Регистрация ViewModel и фабрик
                    RegisterViewModels(services);

                    // Регистрация Navigator с областью Scoped
                    services.AddScoped<INavigator, Navigator>();

                    // Регистрация DateMediator
                    services.AddSingleton<IDateMediator, DateMediator>();

                    // Регистрация сервисов
                    RegisterServices(services);

                    // Регистрация MainWindow
                    services.AddSingleton<MainWindow>();

                    // Регистрация команд
                    RegisterCommands(services);
                });
        }

        private static void RegisterViewModels(IServiceCollection services)
        {
            services.AddScoped<ContactViewModel>();
            services.AddScoped<AddGiftViewModel>();
            services.AddScoped<ChangeGiftViewModel>();
            services.AddScoped<AddEventViewModel>();
            services.AddScoped<GiftViewModel>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<CalendarViewModel>();
            services.AddScoped<FiltersViewModel>();

            // Регистрация EventViewModel с настройкой зависимостей
            services.AddScoped<EventViewModel>(provider =>
            {
                var giftService = provider.GetRequiredService<GiftService>();
                var eventService = provider.GetRequiredService<EventService>();
                var filtersViewModel = provider.GetRequiredService<FiltersViewModel>();
                var contactService = provider.GetRequiredService<ContactService>();
                var filterWindowService = provider.GetRequiredService<FilterWindowService>();
                var mediator = provider.GetRequiredService<IDateMediator>();

                return new EventViewModel(eventService, contactService, filterWindowService, filtersViewModel, giftService, mediator);
            });

            // Регистрация фабрик
            services.AddScoped<AddEventViewModelFactory>();
            services.AddScoped<IGiftNotationViewModelAbstractFactory, GiftNotationViewModelAbstractFactory>();
            services.AddScoped<IGiftNotationViewModelFactory<CalendarViewModel>, HomeViewModelFactory>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<GiftService>();
            services.AddScoped<ContactService>();
            services.AddScoped<EventService>();
            services.AddScoped<FilterWindowService>();
        }

        private static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<AddGiftCommand>();
            services.AddScoped<UpdateCurrentVMCommand>();
            services.AddScoped<OpenCloseFilterCommand>();
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

                // Добавление дней рождения в события
                var eventService = scope.ServiceProvider.GetRequiredService<EventService>();
                await eventService.AddContactBday();
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
