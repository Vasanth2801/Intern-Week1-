using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{
    [System.Serializable]  //to access this class in inspector
    public class ObjectPoolItem  // created a seprate class to hold object pool items
    {
        public string objectTag;  // tag for the object pool
        public GameObject prefab; //prefab for the object pool
        public int objectSize;    //size of the object pool
    }

    public List<ObjectPoolItem> pools; //created a list to hold the items 
    public Dictionary<string, Queue<GameObject>> dictionaryofPools;  // created a dictionary to hold the object pools(according to thier tags)

    void Start()
    {
        dictionaryofPools = new Dictionary<string, Queue<GameObject>>(); //intializing the dictionary 

        foreach(ObjectPoolItem item in pools)  //looping through each item in list 
        {
            Queue<GameObject> obj = new Queue<GameObject>();    //new queue for each item

            for(int i =0; i<item.objectSize; i++)   //lopping for the size of each item 
            {
                GameObject objPool = Instantiate(item.prefab);  //instantiating the prefab
                objPool.SetActive(false);  //setting it to false(for beggining of the scene)
                obj.Enqueue(objPool);    //adding it to the queue(Enqueue)
            } 

            dictionaryofPools.Add(item.objectTag, obj);    //adding the queue to the dictionary with its tag as key 
        }
    }

    public GameObject SpawnObjects(string tag, Vector2 position, Quaternion rotation)   //A new function to spawn the objects 
    {
       GameObject objectToSpawn = dictionaryofPools[tag].Dequeue(); //removing the object from the queue(making it active)
        objectToSpawn.SetActive(true);                              //setting it to true (activating it)
        objectToSpawn.transform.position = position;                //position of the object 
        objectToSpawn.transform.rotation = rotation;                //rotation of the object 


        dictionaryofPools[tag].Enqueue(objectToSpawn);              //adding it back to the queue( deactivating it)

        return objectToSpawn;                                       //returning the object 
    }
}