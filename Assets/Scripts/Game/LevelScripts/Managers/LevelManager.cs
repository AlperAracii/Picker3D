using Assets.Data;
using Assets.Scripts.Game.PlatformScripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<PlatformBaseScript> _platform;
    public List<BallPackBaseScript> _ballPack;

    public PlatformBaseScript GetPlatformForActivate(PlatformTypeEnum platformType)
    {
        var platform = _platform.FirstOrDefault(aa => !aa.IsActive && aa.PlatformType == platformType);
        if (platform == null)
        {
            platform = AssetManager.Instance.GetPlatform(platformType);
            platform = Instantiate(platform, transform);
            platform.Initialize();
            _platform?.Add(platform);
        }

        platform.Activate();
        return platform;
    }

    public BallPackBaseScript GetBallPackForActivate(BallPackTypeEnum ballPackType)
    {
        var ballPack = _ballPack.FirstOrDefault(aa => !aa.isActive && aa.ballPackType == ballPackType);
        if (ballPack == null)
        {
            ballPack = AssetManager.Instance.GetBallPack(ballPackType);
            ballPack = Instantiate(ballPack, transform);
            ballPack.Initialize();
            _ballPack?.Add(ballPack);
        }
        ballPack.Activate();
        return ballPack;
    }

    public void DeactivateWholeGame()
    {
        if (_platform.Count <= 0)
            return;

        foreach (var platform in _platform)
        {
            platform.Deactivate();
        }

        foreach (var ball in _ballPack)
        {
            ball.Deactivate();
        }
    }
}
