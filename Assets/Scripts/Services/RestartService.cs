using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Services
{
    public class RestartService : MonoBehaviour
    {
        private List<IRestartReactor> _reactors = new();

        private void Start()
        {
            GetRestartReactors();
        }

        public void Restart()
        {
            foreach (var reactor in _reactors)
            {
                reactor.Restart();
            }
        }

        private void GetRestartReactors()
        {
            _reactors = GetComponentsInChildren<IRestartReactor>().ToList();
        }
    }
}