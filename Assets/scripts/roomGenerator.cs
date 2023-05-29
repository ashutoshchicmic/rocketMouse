//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class roomGenerator : MonoBehaviour
//{
//    public GameObject[] availableRooms;
//    public List<GameObject> currentRooms;
//    float ScreenWidth;
//    Camera mainCamera;
//    float mid = 0;
//    public Transform mouse;
//    Queue<GameObject> myQueue = new Queue<GameObject>();

//    void Start()
//    {
//        mainCamera = Camera.main;
//        ScreenWidth = mainCamera.aspect * mainCamera.orthographicSize * 2;
//        print(ScreenWidth + ",orthographic size  " + mainCamera.orthographicSize + ",height  " + mainCamera.orthographicSize * 2);
//        //StartCoroutine(GeneratorCheck());
//    }
//    //void AddRoom(float farthestRoomEndX)
//    //{
//    //    int randomRoomIndex = Random.Range(0, availableRooms.Length);
//    //    GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);

//    //    float roomWidth = room.transform.Find("floor").localScale.x;
//    //    float roomCentre = farthestRoomEndX + roomWidth * 0.5f;

//    //    room.transform.position = new Vector3(roomCentre, 0, 0);
//    //    currentRooms.Add(room);
//    //}

//    //void GenerateRoomIfRequired()
//    //{
//    //    List<GameObject> roomsToRemove = new List<GameObject>();
//    //    bool addRoom = true;
//    //    float playerX = transform.position.x;
//    //    float removeX = playerX - ScreenWidth;
//    //    float addRoomX = playerX + ScreenWidth;
//    //    float farthestRoomEndX = 0;

//    //    foreach (var room in currentRooms)
//    //    {
//    //        float roomWidth = room.transform.Find("floor").localScale.x;
//    //        float roomStartX = room.transform.position.x - roomWidth * 0.5f;
//    //        float roomEndX = roomStartX + roomWidth;
//    //        if (roomStartX > addRoomX)
//    //        {
//    //            addRoom = false;
//    //        }
//    //        if (roomEndX < removeX)
//    //        {
//    //            roomsToRemove.Add(room);
//    //        }
//    //        farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);
//    //    }
//    //    foreach (var room in roomsToRemove)
//    //    {
//    //        currentRooms.Remove(room);
//    //        Destroy(room);
//    //    }
//    //    if (addRoom)
//    //    {
//    //        AddRoom(farthestRoomEndX);
//    //    }
//    //}
//    //IEnumerator GeneratorCheck()
//    //{
//    //    while (true)
//    //    {
//    //        GenerateRoomIfRequired();
//    //        yield return new WaitForSeconds(0.25f);
//    //    }
//    //}

    

//}






