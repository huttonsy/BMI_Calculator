namespace BMICalculatorMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(BMIResultPage), typeof(BMIResultPage));
            Routing.RegisterRoute(nameof(HealthRecommendationsPage), typeof(HealthRecommendationsPage));
        }
    }
}
