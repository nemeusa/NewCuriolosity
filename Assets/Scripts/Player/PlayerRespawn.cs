using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private void Start()
    {
        // Check if there is a saved checkpoint
        if (PlayerPrefs.HasKey("LastCheckpointID"))
        {
            // Retrieve saved position
            float x = PlayerPrefs.GetFloat("RespawnX");
            float y = PlayerPrefs.GetFloat("RespawnY");
            float z = PlayerPrefs.GetFloat("RespawnZ");

            Vector3 respawnPosition = new Vector3(x, y, z);

            // Set player position to the last checkpoint
            transform.position = respawnPosition;
        }
    }
}
