using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    [SerializeField] private AnimasiPintu pintu;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        //gameObject.SetActive(false);
        pintu.BukaPintu();
    }
}
