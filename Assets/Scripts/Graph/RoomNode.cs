using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNode : Node<int>
{
    public Vector3 position {get;}
    public Mesh roomMesh;
    override public string RoomType {get {return "Standard Room";} }
    public RoomNode(int _cunt, Vector3 _position): base(_cunt, _position)
    {
        int cunt = _cunt;
        position = _position;
    }
}
