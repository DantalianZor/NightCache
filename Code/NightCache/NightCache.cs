using UnityEngine;

namespace NTC.Global.Cache
{
    [RequireComponent(typeof(NightCacheInstallMachine))]
    public abstract class NightCache : MonoBehaviour, INightCached
    {
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