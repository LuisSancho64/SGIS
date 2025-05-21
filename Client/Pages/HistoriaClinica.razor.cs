using Microsoft.AspNetCore.Components;
using SMI.Client.Shared.Components;

namespace SMI.Client.Pages
{
    public partial class HistoriaClinica : ComponentBase
    {
        private List<TabContainer.TabItem> Tabs = new()
        {
            new() { Title = "Generales", Route = "/historia-clinica/generales" },
            new() { Title = "Obstétrico", Route = "/historia-clinica/obstetrico" },
            new() { Title = "Ginecológico", Route = "/historia-clinica/ginecologico" },
            new() { Title = "Nutrición", Route = "/historia-clinica/nutricion" },
            new() { Title = "Psicológico", Route = "/historia-clinica/psicologico" }
        };

        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            // Si la URL contiene "generales", activamos esa pestaña por defecto
            var currentUri = NavigationManager.Uri;
            if (currentUri.Contains("generales", StringComparison.OrdinalIgnoreCase))
            {
                Tabs[0] = new TabContainer.TabItem
                {
                    Title = "Generales",
                    Route = "/historia-clinica/generales",
                    IsActive = true
                };
            }
        }
    }
}
