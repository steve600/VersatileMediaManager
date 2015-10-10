namespace VersatileMediaManager.Infrastructure.Contracts.Interfaces
{
    public interface IFlyoutService
    {
        void ShowFlyout(string flyoutName);

        bool CanShowFlyout(string flyoutName);
    }
}