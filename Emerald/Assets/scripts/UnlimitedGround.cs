using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitedGround : MonoBehaviour
{
    [SerializeField] private GameObject normalBlock;
    [SerializeField] private GameObject crackedBlock;
    [SerializeField] private int number_Block;
    [SerializeField] private float length_block, minY, maxY;
    [SerializeField] private Vector2 spcg; // start point of creating ground

    void Start()
    {
       produceGround(normalBlock,crackedBlock,number_Block,length_block,minY,maxY,spcg);
    }

    public void produceGround(GameObject block, GameObject cracked_Block,
        int Numner_Blocks, float length_block, float minY, float maxY , Vector2 SPCG)
    {
        int number = Random.Range(0, 4);
        if(number == 1)
        {
            for(int i = 0;  i < Numner_Blocks; i++)
            {
                float exactY = Random.Range(minY,maxY);
                Vector3 startPoint = new Vector3(SPCG.x+(i*length_block), SPCG.y+exactY, 0);
                GameObject clone = Instantiate(cracked_Block, startPoint,Quaternion.identity);
                clone.transform.localScale = new Vector3(length_block, length_block, 1);
            }
        }
        else
        {
            for (int i = 0; i < Numner_Blocks; i++)
            {
                float exactY = Random.Range(minY, maxY);
                Vector3 startPoint = new Vector3(SPCG.x + (i * length_block), SPCG.y + exactY, 0);
                GameObject clone = Instantiate(block, startPoint, Quaternion.identity);
                clone.transform.localScale = new Vector3(length_block, length_block, 1);
            }
        }

        transform.position += new Vector3(0.5f * Numner_Blocks * length_block, 0, 0);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            produceGround(normalBlock, crackedBlock, number_Block, length_block, minY, maxY, spcg);
        }
    }
}
