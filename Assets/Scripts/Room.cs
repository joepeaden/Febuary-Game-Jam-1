using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private bool explored;
    private SpriteRenderer roomRenderer;

    public Level level;
    public List<Room> adjacentRooms;

    void Start()
    {
        // each room should be child of level object
        level = transform.parent.gameObject.GetComponent<Level>();

        // each room is unexplored initially
        explored = false;

        // need a reference to the renderer each time a room is explored
        roomRenderer = GetComponent<SpriteRenderer>();

    }
   
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // on click, attempt to move party to this room
            level.MoveParty(this);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // make sure that all rooms are tagged in this way or update this
        if (other.gameObject.tag == "StartRoom" || other.gameObject.tag == "Room" || other.gameObject.tag == "EndRoom")
        {
            // add each adjacent room to list of adjacent rooms
            if (adjacentRooms == null)
                adjacentRooms = new List<Room>();
            adjacentRooms.Add(other.GetComponent<Room>());
        }

        // make adjacent rooms visible/invisible
        // should only occur at start, for special case (to initialize starting visible rooms)
        if (gameObject.tag == "StartRoom")
            foreach (Room r in adjacentRooms)
                r.roomRenderer.enabled = true;
    }

    public void SetExplored(bool isExplored)
    {
        explored = isExplored;

        // make room visible/invisible
        roomRenderer.enabled = isExplored;

        if (isExplored)
        {
            // make adjacent rooms visible/invisible
            foreach (Room room in adjacentRooms)
                room.roomRenderer.enabled = isExplored;
        }
    }

    public bool IsExplored()
    {
        return explored;
    }
}