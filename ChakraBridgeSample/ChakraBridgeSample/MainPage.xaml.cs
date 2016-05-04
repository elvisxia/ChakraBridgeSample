using ChakraBridge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ChakraBridgeSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ChakraHost host = new ChakraHost();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void myBtn_Click(object sender, RoutedEventArgs e)
        {
            GetBridge();
        }

        private async void GetBridge()
        {
            
            string filename = "main.js";

            CommunicationManager.RegisterType(typeof(double));
            CommunicationManager.OnObjectReceived = (data) =>
            {
                var a = data;
            };
            string url = @"http://cdnjs.cloudflare.com/ajax/libs/mathjs/3.2.1/math.js";
            await ReadAndExecute("math.js");
            await ReadAndExecute("main.js");
            await DownloadAndExecute(url);
        }

        async Task ReadAndExecute(string filename)
        {
            var script = await CoreTools.GetPackagedFileContentAsync("js", filename);
            host.RunScript(script);
        }

        async Task DownloadAndExecute(string url)
        {
            var script = await CoreTools.DownloadStringAsync(url);
            host.RunScript(script);
        }


    }
    
}
