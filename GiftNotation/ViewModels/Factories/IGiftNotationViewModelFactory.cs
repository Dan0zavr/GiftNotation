namespace GiftNotation.ViewModels.Factories
{
    public interface IGiftNotationViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
