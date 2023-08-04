using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

namespace BusServiceApplication.HelperMethods
{
    public class RefreshPage
    {
        private readonly NavigationManager _navigationManager;

        public RefreshPage(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public void refreshApplication()
        {
            _navigationManager.NavigateTo(_navigationManager.Uri, forceLoad: true);
        }

    }
}

