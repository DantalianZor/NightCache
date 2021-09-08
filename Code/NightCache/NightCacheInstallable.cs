namespace NTC.Global.Cache
{
    public abstract class NightCacheInstallable : NightCache
    {
        private bool installedOnEnable;
        
        private void OnEnable()
        {
            OnPreEnable();
            if (!installedOnEnable)
            {
                OnInstall();
                installedOnEnable = true;
            }
            OnLateEnable();
        }
        
        protected virtual void OnPreEnable() { }
        protected virtual void OnLateEnable() { }
        protected abstract void OnInstall();
    }
}