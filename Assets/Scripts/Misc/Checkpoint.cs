using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointID;              // Unique ID for each checkpoint
    public Transform respawnPoint;
    public bool isTrigger;
    public ParticleSystem chkpntParticles;
    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        PlayerRespawn player = other.GetComponent<PlayerRespawn>();
        if (isTrigger)
        {
            SaveCheckpoint();
            PlayParticles();
            Debug.Log("Checkpoint: " + checkpointID);
        }
    }

    private void SaveCheckpoint()
    {
        // Save checkpoint ID and position in PlayerPrefs
        PlayerPrefs.SetInt("LastCheckpointID", checkpointID);
        PlayerPrefs.SetFloat("RespawnX", respawnPoint.position.x);
        PlayerPrefs.SetFloat("RespawnY", respawnPoint.position.y);
        PlayerPrefs.SetFloat("RespawnZ", respawnPoint.position.z);
        PlayerPrefs.Save();
    }

    private void PlayParticles()
    {
        if (isTrigger)
        {
            chkpntParticles.Play();
        }
    }
}
