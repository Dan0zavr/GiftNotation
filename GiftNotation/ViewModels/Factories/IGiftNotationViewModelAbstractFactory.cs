using GiftNotation.State.Navigators;

namespace GiftNotation.ViewModels.Factories
{
    public interface IGiftNotationViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
