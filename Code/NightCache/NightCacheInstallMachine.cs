using System.Collections.Generic;
using NTC.Global.System;

namespace NTC.Global.Cache
{
    public sealed class NightCacheInstallMachine : NightInstallable
    {
        private readonly List<INightCached> systems = new List<INightCached>(8);

        protected override void OnInstall()
        {
            InstallNewSystems();
            InitializeSystems();
        }

        private void InstallNewSystems()
        {
            GetComponents(systems);
            foreach (var system in systems) NightCacheCore.AddSystem(system);
        }
        
        private void RemoveSystems()
        {
            foreach (var system in systems) NightCacheCore.RemoveSystem(system);
        }
        
        private void InitializeSystems()
        {
            foreach (var system in systems)
            {
                system.CacheBaseComponents();
                if (system is INightInit initSystem) initSystem.Init();
            }
        }

        protected override void OnLateEnable()
        {
            foreach (var system in systems) system.SetNightCacheSystemActive(true);
        }

        private void OnDisable()
        {
            foreach (var system in systems) system.SetNightCacheSystemActive(false);
        }

        private void OnDestroy()
        {
            RemoveSystems();
        }
    }
}