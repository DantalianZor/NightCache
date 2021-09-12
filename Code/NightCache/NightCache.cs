using UnityEngine;

namespace NTC.Global.Cache
{
    [RequireComponent(typeof(NightCacheInstallMachine))]
    public abstract class NightCache : MonoBehaviour, INightCached
    {
        public GameObject CachedGameObject { get; private set; }
        public Transform CachedTransform { get; private set; }

        private bool systemIsActiveInScene;
        private bool componentsAlreadyCached;
        
        public bool IsActive()
        {
            return systemIsActiveInScene;
        }

        public void SetNightCacheSystemActive(bool status)
        {
            systemIsActiveInScene = status;
        }

        public void CacheBaseComponents()
        {
            if (componentsAlreadyCached) return;
            CachedGameObject = gameObject;
            CachedTransform = transform;
            componentsAlreadyCached = true;
        }
    }
}