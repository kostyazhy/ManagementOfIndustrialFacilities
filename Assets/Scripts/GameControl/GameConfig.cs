using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    [Header("Crane")]
    public Vector3 PosCrane;
    public GameObject prefabCrane;

    [Header("Tower")]
    public Vector3 StartPositionTower;
    public float SpeedTowerCrane;
    public float minDistanceForDeadLine;
    public GameObject prefabTower;
    
    [Header("Windlass")]
    public Vector3 StartPositionWindlass;
    public float SpeedWindlass;
    public GameObject prefabWindlass;

    [Header("Magnet")]
    public Vector3 StartPositionMagnet;
    public Vector3 SpeedMagnet;
    public float MagnetPower;
    public GameObject prefabMagnet;

    [Header("ControlPanel")]
    public Vector3 StartPositionControlPanel;
    public GameObject prefabControlPanel;

    [Header("SwitchForward")]
    public Vector3 StartPositionSwitchForward;
    public GameObject prefabSwitchForward;
    public Vector3 StartPositionSwitchBack;
    public GameObject prefabSwitchBack;
    public Vector3 StartPositionWindlassLeft;
    public GameObject prefabWindlassLeft;
    public Vector3 StartPositionWindlassRight;
    public GameObject prefabWindlassRight;
    public Vector3 StartPositionButtonDownForWindlass;
    public Vector3 StartPositionButtonUpForWindlass;
    public GameObject prefabButtonForWindlass;
    public Vector3 StartPositionButtonMagnet;
    public GameObject prefabButtonForMagnet;

    [Header("Events")]
    public GameEvent GameEventMoveTowerForward;
    public GameEvent GameEventMoveTowerBack;
    public GameEvent GameEventMoveWindlassLeft;
    public GameEvent GameEventMoveWindlassRight;
    public GameEvent GameEventMoveMagnetDown;
    public GameEvent GameEventMoveMagnetUp;
}
