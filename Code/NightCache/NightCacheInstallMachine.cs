using System.Collections.Generic;
using NTC.Global.System;

namespace NTC.Global.Cache
{
    public sealed class NightCacheInstallMachine : MonoInstallable
    {
        private readonly List<INightCached> systems = new List<INightCached>(8);

        protected override void OnFirstEnable()
        {
            InstallNewSystems();
        }

        private void InstallNewSystems()
        {
            GetComponents(systems); InitializeSystems();
            foreach (var system in systems) NightCacheCore.AddSystem(system);
        }
        
        private void RemoveSystems()
        {
            foreach (var system in systems) NightCacheCore.RemoveSystem(system);
        }
        
        private void InitializeSystems()
        {
            foreach (var system in systems) if (system is INightInit initSystem) initSystem.Init();
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