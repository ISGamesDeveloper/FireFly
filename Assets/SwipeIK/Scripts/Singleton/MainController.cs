using UnityEngine;
using System.Collections;

public class MainController : SingletonBehaviour<MainController> 
{
    [HideInInspector]
    public UIController uiController;
    [HideInInspector]
    public PlayerController playerController;
    [HideInInspector]
    public MapController mapController;
} 