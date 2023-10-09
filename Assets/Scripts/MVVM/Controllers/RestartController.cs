using UniRx;

namespace MVVM.Controllers
{
    public class RestartController : ModelsController
    {
        public ReactiveCommand OnRestart = new();

        public void Restart()
        {
            OnRestart.Execute();
        }
    }
}