using MVVM.Core;
using UnityEngine;

namespace MVVM.Starters
{
    public class StarterInitializer : MonoBehaviour
    {
        private void Awake()
        {
            InitializeMvvm();
        }

        private void InitializeMvvm()
        {
            var holders = GetComponentsInChildren<MvvmStarter>();

            foreach (var starter in holders)
            {
                starter.InitializeStarter();
            }
        }
    }
}