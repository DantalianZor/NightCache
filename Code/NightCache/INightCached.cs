namespace NTC.Global.Cache
{
    public interface INightCached
    {
        public bool IsActive();
        public void SetNightComponentActive(NightCacheInstallMachine machine, bool status);
    }

    public interface INightRun : INightCached
    {
        public void Run();
    }

    public interface INightFixedRun : INightCached
    {
        public void FixedRun();
    }

    public interface INightLateRun : INightCached
    {
        public void LateRun();
    }
}