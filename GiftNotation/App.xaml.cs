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
using Microsoft.Extensions.Hosting;
using GiftNotation.ViewModels.Factories;


namespace GiftNotation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; }

        //private readonly IHost _host;

        //public App()
        //{
        //    _host = CreateHostBuilder().Build();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args = null)
        //{
        //    return Host.CreateDefaultBuilder(args)
        //        .ConfigureServices(s => { });
        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = new MainWindow();

            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();

            
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            // Регистрация ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddScoped<INavigator, Navigator>();

            // Регистрация DbContext и других сервисов
            services.AddDbContext<GiftNotationDbContext>();
            services.AddSingleton<GiftNotationDbContextFactory>();
            services.AddSingleton<IMyFriendsService, MyFriendsService>();
            services.AddSingleton<IContactService, ContactService>();
            services.AddSingleton<UpdateCurrentVMCommand>();

            //Регистрация фабрик
            services.AddSingleton<IGiftNotationViewModelAbstractFactory, GiftNotationViewModelAbstractFactory>();
            services.AddSingleton<IGiftNotationViewModelFactory<CalendarViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IGiftNotationViewModelFactory<MyFriendsViewModel>, MyFriendsViewModelFactory>();


            // Регистрация MainWindow
            services.AddScoped<MainWindow>(); // Регистрация MainWindow как службы

            return services.BuildServiceProvider();
        }

    }

}
