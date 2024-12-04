using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private bool ignoreSavedCheckpointInspector = false; // Configurable desde el Inspector
    private static bool ignoreSavedCheckpointInitialized = false; // Garantiza inicialización única
    private static bool ignoreSavedCheckpoint = false; // Controla el comportamiento durante la sesión

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
            // Forzar posición en (0, 0, 0)
            transform.position = Vector3.zero;

            // Desactivar para futuras ejecuciones
            ignoreSavedCheckpoint = false;
        }
        else if (PlayerPrefs.HasKey("LastCheckpointID"))
        {
            // Recuperar posición guardada
            float x = PlayerPrefs.GetFloat("RespawnX");
            float y = PlayerPrefs.GetFloat("RespawnY");
            float z = PlayerPrefs.GetFloat("RespawnZ");

            Vector3 respawnPosition = new Vector3(x, y, z);

            // Ajustar posición del jugador al último checkpoint
            transform.position = respawnPosition;
        }
    }
}
