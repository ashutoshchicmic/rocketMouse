using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newroomGenerator : MonoBehaviour
{
    public GameObject[] availableRooms;
    public List<GameObject> myObjectsList;
    public GameObject[] availableObjects;
    float ScreenWidth;
    float firstRoomX;
    float LastRoomX;
    Camera mainCamera;
    Queue<GameObject> myQueue = new Queue<GameObject>();
    Queue<GameObject> myObjects = new Queue<GameObject>();
    public GameObject room1;
    public float objectsMinDistance = 5.0f;
    public float objectsMaxDistance = 10.0f;
    public float objectsMinY = -1.4f;
    public float objectsMaxY = 1.4f;
    public float objectsMinRotation = -45.0f;
    public float objectsMaxRotation = 45.0f;
    float lastObjectX;
    float firstObjectX;
    

    void Start()
    {
        myQueue.Enqueue(room1);
        mainCamera = Camera.main;
        ScreenWidth = mainCamera.aspect * mainCamera.orthographicSize * 2;
        print(ScreenWidth + ",orthographic size  " + mainCamera.orthographicSize + ",height  " + mainCamera.orthographicSize * 2);
        float firstRoomWidth = room1.transform.Find("floor").localPosition.x;
        firstRoomX = firstRoomWidth/2+room1.transform.position.x;
        LastRoomX = firstRoomX;
        AddObject();
        firstObjectX = lastObjectX;
    }
    private void FixedUpdate()
    {
        if (gameObject.transform.position.x+ScreenWidth> LastRoomX)
        {
            addRoom();
        }
        if (gameObject.transform.position.x-ScreenWidth > firstRoomX)
        {
            deleteRoom();
        }
        if (gameObject.transform.position.x + ScreenWidth > lastObjectX)
        {
            AddObject();
        }
        if (gameObject.transform.position.x - ScreenWidth > firstObjectX)
        {
            removeObject();
        }


    }
    void addRoom()
    {
        int randomRoomIndex = Random.Range(0, availableRooms.Length);
        GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);
        float roomWidth = room.transform.Find("floor").localScale.x;
        float roomCentre = roomWidth * 0.5f;
        room.transform.position = new Vector3(LastRoomX+roomWidth, availableRooms[randomRoomIndex].transform.position.y, 0);
        myQueue.Enqueue(room);
        LastRoomX += roomWidth;

    }
    void deleteRoom()
    {
        GameObject room = myQueue.Dequeue();
        Destroy(room);
        firstRoomX= myQueue.Peek().transform.position.x;
    }
    void AddObject()
    {
        int randomRoomIndex = Random.Range(0, availableObjects.Length);
        GameObject obj = (GameObject)Instantiate(availableObjects[randomRoomIndex]);
        float objectPositionX = lastObjectX + Random.Range(objectsMinDistance, objectsMaxDistance);
        float randomY = Random.Range(objectsMinY, objectsMaxY);
        obj.transform.position = new Vector3(objectPositionX, randomY, 0);
        float rotation = Random.Range(objectsMinRotation, objectsMaxRotation);
        obj.transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
        myObjects.Enqueue(obj);
        lastObjectX = objectPositionX;
        
    }
    void removeObject()
    {
        GameObject obj = myObjects.Dequeue();
        Destroy(obj);
        firstObjectX = myObjects.Peek().transform.position.x;
    }
}
