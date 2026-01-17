namespace GastritisTracker.Components.Pages
{
    public partial class Home
    {
        private string DailyTip = " ";

        protected override void OnInitialized()
        {
            var tips = new List<string>
            {
                "Remember to sleep on your left side to reduce acid reflux at night.",
                "Manuka honey is best taken on an empty stomach for maximum coating effect.",
                "Collagen needs time to work. Consistency is key for mucosal repair.",
                "Avoid drinking water during meals; try to drink 30 mins before or after.",
                "Stress is a major trigger. Take 5 minutes to breathe deeply today.",
                "Chew your food thoroughly. Digestion starts in the mouth!",
                "Aloe Vera (without Aloin) can soothe inflammation naturally."
            };

            // Seleccina una al azar uno de los consejos cada vez que se inicializa la página
            var ramdom = new Random();
            DailyTip = tips[ramdom.Next(tips.Count)];
        }
    }
}