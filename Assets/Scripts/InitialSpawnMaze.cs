using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InitialSpawnMaze : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        var player1 = PlayerInput.Instantiate(prefab, 0, "WASD", 0, Keyboard.current);
        var player2 = PlayerInput.Instantiate(prefab, 1, "Arrows", 1, Keyboard.current);

        player1.transform.position = new Vector3(36.9f, 0.5f, -38.2f);
        player2.transform.position = new Vector3(34.9f, 0.5f, -38.2f);

        player1.transform.parent.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
        player2.transform.parent.GetChild(0).GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
        
        player1.transform.parent.GetChild(0).GetComponent<Camera>().GetComponent<AudioListener>().enabled = true;

        player1.GetComponent<PlayerController>().playerIndex = 0;
        player2.GetComponent<PlayerController>().playerIndex = 1;
    }


}