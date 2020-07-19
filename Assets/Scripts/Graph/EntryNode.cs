using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryNode : Node<int>
{
    public Vector3 position {get;}
    override public string RoomType {get {return "Entry Room";} }
    public Mesh spawnMesh;

   public EntryNode(int _cunt, Vector3 _position): base(_cunt, _position)
   {
        int cunt = _cunt;
        position = _position;
   }
}
