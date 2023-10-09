using UniRx;
using UnityEngine;

namespace MVVM.Controllers
{
    public abstract class ModelsController
    {
        public ReactiveCommand OnRestart = new();
        public ReactiveCommand OnRoundEnd = new();

        public virtual void OnInitialize()
        {
        }
        
        public virtual void Restart()
        {
            Debug.Log($"Restart controller {GetType().Name}");
        }
        
        public virtual void RoundEnd()
        {
        }
    }
}