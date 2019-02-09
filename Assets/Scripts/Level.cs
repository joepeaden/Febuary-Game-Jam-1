using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Room> rooms;
    public Room currentRoom;
    public GameObject playerParty;

    void Start()
    {
        // each room should be child of level object, so can
        // get them directly from that
        rooms = new List<Room>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Room room = transform.GetChild(i).gameObject.GetComponent<Room>();
            
            // be sure to tag the first room
            if (room.gameObject.tag == "StartRoom")
            {
                // first room would be current and explored room
                currentRoom = room;
                room.SetExplored(true);
            }

            rooms.Add(room);
        }

        playerParty = GameObject.FindGameObjectWithTag("Player");
    }

    public void MoveParty(Room room)
    {
        // if party is not in adjacent room and not explored, do not move
        if (!currentRoom.adjacentRooms.Contains(room) && !room.IsExplored())
            return;

        currentRoom = room;

        // move player party to center of next room
        playerParty.transform.position = currentRoom.transform.position;

        room.SetExplored(true);
    }

}
