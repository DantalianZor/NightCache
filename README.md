## NightCache - fast Update optimization System for Unity

Auto-Install void Update() optimization fast system by Night Train Code (UniTask Attached from https://github.com/Cysharp/UniTask)

The system caches all components, that need an void Update() into one list, then a single void Update() calls them all from the list

# How to use

1) Install NightCache components into your Unity project (it will calls all void Run, FixedRun and LateRun in scene)

2) Add component «NightCacheEntry» on any GameObject in scene

3) Inherit any class, which contains void Update / FixedUpdate / LateUpdate from «NightCache»

4) Implement the required interfaces: «INightRun», «INightFixedRun» or «INightLateRun»

5) Move the code from the old method to the new one

6) System will automatically add a new component «NightCacheInstallMachine» on GameObject, which contains a «NightCache» by RequireComponent. 
If for some reason this did not happen, then add it manually.

7) Everything is ready to use :)

# For example:

### Old implementation:

```sh
public class UnitMovement : MonoBehaviour
{
  private void MoveUnit()
  {
    //Movement
  }
  
  private void Update()
  {
    MoveUnit();
  }
}
```

### New implementation:

```sh
public class UnitMovement : NightCache, INightRun
{
  private void MoveUnit()
  {
    //Movement
  }
  
  public void Run()
  {
    MoveUnit();
  }
}
```
# Interfaces

| Interface | Replaces |
| ------ | ------ |
| INightRun : void Run() | void Update() |
| INightFixedRun : void FixedRun() | void FixedUpdate() |
| INightLateRun : void LateRun() | void LateUpdate() |
