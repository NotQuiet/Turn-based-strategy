using UnityEngine;

namespace MVVM.Controllers
{
    public abstract class ModelsController
    {
        public virtual void OnInitialize()
        {
        }
        
        public virtual void Restart()
        {
            Debug.Log($"Restart controller {GetType().Name}");
        }
    }
}