using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : Node<int>
{
    public Vector3 position {get;}
    public Mesh roomMesh;
    override public string RoomType {get {return "Boss Room";} }

    public BossRoom(int _id, Vector3 _position): base(_id, _position)
    {
        int id = _id;
        position = _position;
    }
}
