using System.Threading.Tasks;
using Thrush.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using LiteDB;


namespace Thrush.Core
{
    public class AppStart : MvxAppStart
    {
        public AppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {

            //public LocalDatabase(IPlatform platform) : base(Path.Combine(platform.AppData.FullName, "dcms.db"))
            //using (var ldb = new LiteDB.LiteDatabase("Filename=" + System.IO.Path.Combine(platform.AppData.FullName, "HDDSLite.db") + "; Upgrade=true")) ;
        }

        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            await NavigationService.Navigate<RootViewModel>();
        }
    }
}
