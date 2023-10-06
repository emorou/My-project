using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]

    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }

    public List<Drops> drops;
    
    void OnDestroy()
    {
        float randomNumber = UnityEngine.Random.Range(0f, 100f);
        foreach (Drops rate in drops)
        {

            if (randomNumber <= rate.dropRate)
            {
                Instantiate(rate.itemPrefab, transform.position, Quaternion.identity);
            }
        }

    // Drop two or more items if available
        // int numItemsToDrop = Random.Range(2, itemsToDrop.Count + 1);

        // for (int i = 0; i < numItemsToDrop; i++)
        // {
        //     if (itemsToDrop.Count > 0)
        //     {
        //         int randomIndex = Random.Range(0, itemsToDrop.Count);
        //         GameObject itemToInstantiate = itemsToDrop[randomIndex];
        //         Instantiate(itemToInstantiate, transform.position, Quaternion.identity);
        //         itemsToDrop.RemoveAt(randomIndex);

        //     // Destroy the instantiated item after a delay or when it's no longer needed
               
        // }
        // }
    }
}
