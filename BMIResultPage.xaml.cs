using Microsoft.Maui.Controls;

namespace BMICalculatorMobileApp
{
    [QueryProperty(nameof(BMI), "bmi")]
    [QueryProperty(nameof(Category), "category")]
    [QueryProperty(nameof(Recommendation), "recommendation")] 
    public partial class BMIResultPage : ContentPage
    {
        public string BMI
        {
            set => BMIResultLabel.Text = $"Your BMI: {value}";
        }

        public string Category
        {
            set => CategoryLabel.Text = $"Category: {value}";
        }

        public string Recommendation { get; set; } 

        public BMIResultPage()
        {
            InitializeComponent();
        }

        private async void OnGoToRecommendations(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"HealthRecommendationsPage?recommendation={Uri.EscapeDataString(Recommendation)}");
        }

        private async void OnGoBackToHome(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}

