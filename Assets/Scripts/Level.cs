using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Room> rooms;
    public Room currentRoom;
    public GameObject playerParty;

    public GameManager gm;

    void Start()
    {
        gm = GameManager.instance;

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
            else
                room.SetExplored(false);

            rooms.Add(room);
        }

        playerParty = GameObject.FindGameObjectWithTag("Player");
    }

    public void MoveParty(Room room)
    {

        if (room.IsVisible())
        {
            currentRoom = room;

            // move player party to center of next room
            playerParty.transform.position = currentRoom.transform.position;

            if(!room.IsExplored())
                room.SetExplored(true);
        }
    }

    public void ExitGame()
    {
        gm.ExitGame();
    }

}
