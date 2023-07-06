using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private Transform spawnedObjectPrefab;
    private Transform spawnedObjectTransform;
    
    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1);

    public struct MyCustomData : INetworkSerializable
    {
        public int _int;
        
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _int);
        }
    }

    void Update()
    {
        if(!IsOwner) return;

        if(Input.GetKeyDown(KeyCode.T))
        {
            spawnedObjectTransform = Instantiate(spawnedObjectPrefab);
            spawnedObjectTransform.position = transform.position;
            spawnedObjectTransform.GetComponent<NetworkObject>().Spawn(true);
        }
        
        var moveDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)) moveDir.z = +1;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -1;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1;
        if (Input.GetKey(KeyCode.D)) moveDir.x = +1;

        transform.position += moveDir * (3f * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Y))
        {
            Destroy(spawnedObjectTransform);
        }
    }

    [ServerRpc]
    private void TestServerRpc()
    {
        
    }
}
