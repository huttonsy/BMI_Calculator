namespace BMICalculatorMobileApp {

    public partial class MainPage : ContentPage
    {
        private string selectedGender = "";
        public MainPage()
        {
            InitializeComponent();
            Title = "BMI Calculator";
        }

        private void OnMaleSelected(object sender, EventArgs e)
        {
            selectedGender = "Male";
            MaleFrame.BorderColor = Colors.Blue;
            MaleFrame.BackgroundColor = Colors.LightBlue; 
            FemaleFrame.BorderColor = Colors.Transparent;
            FemaleFrame.BackgroundColor = Colors.White; 
        }

        private void OnFemaleSelected(object sender, EventArgs e)
        {
            selectedGender = "Female";
            FemaleFrame.BorderColor = Colors.Pink;
            FemaleFrame.BackgroundColor = Colors.LightPink; 
            MaleFrame.BorderColor = Colors.Transparent;
            MaleFrame.BackgroundColor = Colors.White; 
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == WeightSlider)
            {
                WeightLabel.Text = $"{e.NewValue:F1} lbs";
            }
            else if (sender == HeightSlider)
            {
                HeightLabel.Text = $"{e.NewValue:F1} in";
            }
        }

        private async void OnCalculateBMI(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedGender))
            {
                await DisplayAlert("Error", "Please select a gender.", "OK");
                return;
            }

            double weight = WeightSlider.Value;
            double height = HeightSlider.Value;

            if (height == 0)
            {
                await DisplayAlert("Error", "Height cannot be zero.", "OK");
                return;
            }

            double bmi = (weight / (height * height)) * 703; 
            string healthStatus;
            string recommendation;

            if (bmi < 18.5)
            {
                healthStatus = "Underweight";
                recommendation = "Increase calorie intake and consider strength training.";
            }
            else if (bmi < 24.9)
            {
                healthStatus = "Normal";
                recommendation = "Maintain a balanced diet and regular exercise.";
            }
            else if (bmi < 29.9)
            {
                healthStatus = "Overweight";
                recommendation = "Reduce processed foods and focus on protein control.";
            }
            else
            {
                healthStatus = "Obese";
                recommendation = "Consult a healthcare provider for a tailored plan.";
            }

            await DisplayAlert("Your calculated BMI results are:",
                $"Gender: {selectedGender}\nBMI: {bmi:F1}\nHealth Status: {healthStatus}\n\nRecommendations:\n{recommendation}",
                "OK");
        }

    }
}