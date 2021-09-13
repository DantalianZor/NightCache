using UnityEngine;

namespace NTC.Global.Cache
{
    [RequireComponent(typeof(NightCacheInstallMachine))]
    public abstract class NightCache : MonoBehaviour, INightCached
    {
        public GameObject CachedGameObject =>
            cachedGameObject ? cachedGameObject : cachedGameObject = gameObject;
        
        public Transform CachedTransform =>
            cachedTransform ? cachedTransform : cachedTransform = transform;

        private GameObject cachedGameObject;
        private Transform cachedTransform;
        
        private bool systemIsActiveInScene;
        
        public bool IsActive()
        {
            return systemIsActiveInScene;
        }

        public void SetNightCacheSystemActive(bool status)
        {
            systemIsActiveInScene = status;
        }
    }
}