using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    private GameController controller;
    
    public GameObject[] prefabs;       // لیست پریفب‌ها (در Inspector بذار)
    public Transform spawnPoint;       // نقطه ساخت (Transform). اگر خالی باشه از پوزیشن خود اسکریپت استفاده میشه

    //void Start()
    //{
    //    controller = FindObjectOfType<GameController>();
    //}

    //void Update()
    //{
    //    if (!controller.canJump)
    //        return;
            
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        SpawnRandom();
    //    }
    //}

    //void SpawnRandom()
    //{
    //    if (prefabs.Length == 0) return; // اگر لیست خالی باشه هیچی نسازه

    //    // انتخاب رندوم یک پریفب از لیست
    //    int index = Random.Range(0, prefabs.Length);
    //    GameObject prefabToSpawn = prefabs[index];

    //    // مشخص کردن نقطه ساخت
    //    Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;

    //    // ساخت پریفب در صحنه
    //    Instantiate(prefabToSpawn, position, Quaternion.identity);
    //}
}
