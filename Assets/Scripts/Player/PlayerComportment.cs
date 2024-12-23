using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComportment : MonoBehaviour
{
    public Transform spawnPoint;

    public void Respawn()
    {
        transform.position = spawnPoint.position;
        Debug.Log("Player respawned!");
    }
}
