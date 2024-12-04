using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private bool ignoreSavedCheckpointInspector = false; // Configurable desde el Inspector
    private static bool ignoreSavedCheckpointInitialized = false; // Garantiza inicializaci�n �nica
    private static bool ignoreSavedCheckpoint = false; // Controla el comportamiento durante la sesi�n

    private void Awake()
    {
        // Solo sincronizar la primera vez
        if (!ignoreSavedCheckpointInitialized)
        {
            ignoreSavedCheckpoint = ignoreSavedCheckpointInspector;
            ignoreSavedCheckpointInitialized = true;
        }
    }

    private void Start()
    {
        if (ignoreSavedCheckpoint)
        {
            // Forzar posici�n en (0, 0, 0)
            transform.position = Vector3.zero;

            // Desactivar para futuras ejecuciones
            ignoreSavedCheckpoint = false;
        }
        else if (PlayerPrefs.HasKey("LastCheckpointID"))
        {
            // Recuperar posici�n guardada
            float x = PlayerPrefs.GetFloat("RespawnX");
            float y = PlayerPrefs.GetFloat("RespawnY");
            float z = PlayerPrefs.GetFloat("RespawnZ");

            Vector3 respawnPosition = new Vector3(x, y, z);

            // Ajustar posici�n del jugador al �ltimo checkpoint
            transform.position = respawnPosition;
        }
    }
}
