using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

[assembly: Xamarin.Forms.XmlnsPrefix("http://baseflow.com/thrush", "thrush")]
[assembly: Xamarin.Forms.XmlnsDefinition("http://baseflow.com/thrush", nameof(Thrush.Core))]
[assembly: Xamarin.Forms.XmlnsDefinition("http://baseflow.com/thrush", nameof(Thrush.Core.Views))]
[assembly: Xamarin.Forms.XmlnsDefinition("http://baseflow.com/thrush", nameof(Thrush.Core.ViewModels))]

[assembly: Xamarin.Forms.XmlnsPrefix("http://baseflow.com/mediamanager", "mm")]
[assembly: Xamarin.Forms.XmlnsDefinition("http://baseflow.com/mediamanager", nameof(MediaManager.Forms))]
[assembly: Xamarin.Forms.XmlnsDefinition("http://baseflow.com/mediamanager", nameof(MediaManager.Forms.Xaml))]

[assembly: Xamarin.Forms.XmlnsPrefix("http://mvvmcross.com/bind", "mvx")]
[assembly: Xamarin.Forms.XmlnsDefinition("http://mvvmcross.com/bind", nameof(MvvmCross.Forms.Bindings))]
[assembly: Xamarin.Forms.XmlnsDefinition("http://mvvmcross.com/bind", nameof(MvvmCross.Forms.Converters))]
[assembly: Xamarin.Forms.XmlnsDefinition("http://mvvmcross.com/bind", nameof(MvvmCross.Forms.Views))]
