using MVVM.Core;
using UnityEngine;

namespace MVVM.Starters
{
    public class StarterInitializer : MonoBehaviour
    {
        private MvvmStarter[] _starters;
        private void Start()
        {
            InitializeMvvm();
        }

        private void InitializeMvvm()
        {
            _starters = GetComponentsInChildren<MvvmStarter>();

            foreach (var starter in _starters)
            {
                starter.InitializeStarter();
            }
        }
    }
}