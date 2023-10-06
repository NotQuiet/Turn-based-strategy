using UnityEngine;

namespace Factories.Core
{
    public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T prefab;

        public virtual T GetNewInstance(Transform spawnParent)
        {
            return Instantiate(prefab, spawnParent);
        }

        public void DestroyCell(T cell)
        {
            Destroy(cell.gameObject);
        }
    }
}