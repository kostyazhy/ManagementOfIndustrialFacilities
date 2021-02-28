using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    public Vector3 PosCrane;
    public Vector3 PositionTowerСrane;
    public Vector3 StartPositionTower;
    public Vector3 StartPositionMagnet;

    public float SpeedTowerCrane;
    public float minDistanceForDeadLine;

    public GameObject prefabCrane;
    public GameObject prefabTower;
}
