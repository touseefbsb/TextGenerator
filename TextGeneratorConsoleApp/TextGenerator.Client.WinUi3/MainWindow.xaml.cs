using Microsoft.UI.Xaml;
using TextGenerator.Client.WinUi3.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TextGenerator.Client.WinUi3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; } = new();
        public MainWindow() => this.InitializeComponent();
    }
}
