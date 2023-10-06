using System.Collections.Generic;
using System.Linq;
using Factories.Core;
using UnityEngine;

namespace Pools.Core
{
    public class GenericPool<T> where T : MonoBehaviour
    {
        private Queue<T> _cellsPool = new();

        public Queue<T> GetPool => _cellsPool;
    
        private int _poolSize;
        private int _counter;

        public void SetPoolSize(int size, GenericFactory<T> factory)
        {
            if (size < _poolSize)
            {
                foreach (var cell in _cellsPool.ToList())
                {
                    factory.DestroyCell(cell);
                    _cellsPool.Dequeue();

                    _poolSize--;

                    if (_poolSize == size)
                    {
                        _counter = _poolSize;
                        break;
                    }
                }
            }
            else
            {
                _poolSize = size;
            }
        }

        public void SetActiveCellsToFalse()
        {
            foreach (var cell in _cellsPool)
            {
                cell.gameObject.SetActive(false);
            }
        }

        public T GetCell(GenericFactory<T> factory, Transform spawnPoint)
        {
            if (_counter >= _poolSize)
            {
                return ReuseCell();
            }
            else
            {
                _counter++;
                var cell = SpawnCell(factory, spawnPoint);
                return cell;
            }
        }

        private T SpawnCell(GenericFactory<T> factory, Transform spawnPoint)
        {
            var cell = factory.GetNewInstance(spawnPoint);
            _cellsPool.Enqueue(cell);

            return cell;
        }

        private T ReuseCell()
        {
            T cell = _cellsPool.Dequeue();
            _cellsPool.Enqueue(cell);
            cell.gameObject.SetActive(true);

            return cell;
        }
    }
}