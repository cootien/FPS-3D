using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectManager : Singleton<HitEffectManager>
{
    public HitEffectMapper[] effectMap;
}

[System.Serializable]
public class HitEffectMapper
{
    public HitSurfaceType surfaceType;
    public GameObject effectPrefab;
}

public enum HitSurfaceType
{
    Blood = 0
}