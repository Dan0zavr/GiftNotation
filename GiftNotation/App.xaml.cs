using System.Configuration;
using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GiftNotation.ViewModels;
using GiftNotation.Services;
using GiftNotation.Data;
using GiftNotation;
using GiftNotation.Commands;
using GiftNotation.State.Navigators;



namespace GiftNotation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Получение экземпляра MainWindow через DI-контейнер
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = ServiceProvider.GetRequiredService<MainViewModel>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрация DbContext и других сервисов
            services.AddDbContext<GiftNotationDbContext>();
            services.AddTransient<IMyFriendsService, MyFriendsService>();
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<UpdateCurrentVMCommand>();

            // Регистрация ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddTransient<MyFriendsViewModel>();

            // Регистрация MainWindow
            services.AddTransient<MainWindow>(); // Регистрация MainWindow как службы
        }
    }

}
