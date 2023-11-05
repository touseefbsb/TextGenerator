using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using TextGenerator.Client.Swag;

namespace TextGenerator.Client.WinUi3.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IClient _client = new TextGenerator.Client.Swag.Client();

    [ObservableProperty] private string template1;
    [ObservableProperty] private string template2;
    [ObservableProperty] private string output1;
    [ObservableProperty] private string output2;
    [ObservableProperty] private DataModel dataModel1 = new() { Address = new() };
    [ObservableProperty] private DataModel2 dataModel2 = new() { Department = new() { Section = new() } };

    [RelayCommand]
    private async Task Form1Submitted() => Output1 = (await _client.GenerateTextAsync(new TextGenerationRequest
    {
        DataModel = DataModel1,
        Template = Template1
    })).Result;

    [RelayCommand]
    private async Task Form2Submitted() => Output2 = (await _client.GenerateText2Async(new TextGenerationRequest2
    {
        DataModel = DataModel2,
        Template = Template2
    })).Result;
}
