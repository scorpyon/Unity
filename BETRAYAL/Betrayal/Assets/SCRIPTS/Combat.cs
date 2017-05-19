using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour
{

    public const int MaxHealth = 100;

    [SyncVar]
    public int Health = MaxHealth;
    public bool DestroyOnDeath;

    public void TakeDamage(int amount)
    {
        // Only apply health changes on the server
        if (!isServer) return;

        Health -= amount;
        if (Health <= 0)
        {
            if (DestroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                Health = MaxHealth;
                Debug.Log("Dead!");

                // called on the server, will be invoked on the clients
                RpcRespawn();
            }
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // move back to zero location
            transform.position = Vector3.zero;
        }
    }
}
