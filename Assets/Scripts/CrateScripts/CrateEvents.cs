using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CrateEvents
{
    //default void delegate type.
    public delegate void VoidDelegate();
    public delegate void GameObjectDelegate(GameObject crate);

    public static VoidDelegate SpawnEvent;
    public static VoidDelegate DespawnEvent;
    public static GameObjectDelegate OnSpawnEvent;
    public static GameObjectDelegate OnDespawnEvent;

}
