namespace JasonMediaTracker.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new JasonMediaTracker.App());
        }
    }
}
