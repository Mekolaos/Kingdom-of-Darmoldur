using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitNode : Node<int>
{
    public Vector3 position {get;}
    public Mesh exitMesh;
    override public string RoomType {get {return "Exit Room";} }
    public ExitNode(int _cunt, Vector3 _position): base(_cunt, _position)
    {
        int cunt = _cunt;
        position = _position;
    }
}
