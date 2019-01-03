using MvvmCross.Platform.IoC;
using MvvmCross.Platform;

namespace SquareRt.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            Mvx.ConstructAndRegisterSingleton<ISquareRtCalculator, SquareRtCalculator>();
            //RegisterNavigationServiceAppStart<ViewModels.FirstViewModel>();
            RegisterNavigationServiceAppStart<ViewModels.SquareRtViewModel>();
        }
    }
}
