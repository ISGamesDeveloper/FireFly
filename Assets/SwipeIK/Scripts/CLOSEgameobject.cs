using UnityEngine;

public class CLOSEgameobject : MonoBehaviour {

    public GameObject Object;
    public void CloseGO()
    {
        Object.SetActive(false);
    }
}
