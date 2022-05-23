using Assets.Data;
using Assets.Scripts.Game.PlatformScripts;
using Helpers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AssetManager : GenericSingleton<AssetManager>
{
    private const string PLATFORM_PATH = "PlatformPrefabs";
    private const string LEVEL_PATH = "Levels/Level";
    private const string BALLPACK_PATH = "BallPacks";

    private List<PlatformBaseScript> _platformBases;
    private List<BallPackBaseScript> _ballPackBases;


    public Material GroundMaterial;
    public Material PickerMaterial;

    public void LoadPlatformPrefabs()
    {
        _platformBases = Resources.LoadAll<PlatformBaseScript>(PLATFORM_PATH).ToList();
        _ballPackBases = Resources.LoadAll<BallPackBaseScript>(BALLPACK_PATH).ToList();
    }

    public PlatformBaseScript GetPlatform(PlatformTypeEnum platformType)
    {
        return _platformBases?.FirstOrDefault(aa => aa.PlatformType == platformType);
    }

    public LevelData LoadLevel(int levelindex)
    {
        return Resources.Load<LevelData>(LEVEL_PATH + levelindex);
    }

    public BallPackBaseScript GetBallPack(BallPackTypeEnum ballPackType)
    {
        return _ballPackBases?.FirstOrDefault(x => x.ballPackType == ballPackType);
    }




}
