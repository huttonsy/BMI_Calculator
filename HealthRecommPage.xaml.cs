using Microsoft.Maui.Controls;

namespace BMICalculatorMobileApp
{
    [QueryProperty(nameof(Recommendation), "recommendation")]
    public partial class HealthRecommendationsPage : ContentPage
    {
        public string Recommendation
        {
            set => RecommendationLabel.Text = $"{Uri.UnescapeDataString(value)}";
        }

        public HealthRecommendationsPage()
        {
            InitializeComponent();
        }

        private async void OnGoBackToResults(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnGoBackToHome(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
