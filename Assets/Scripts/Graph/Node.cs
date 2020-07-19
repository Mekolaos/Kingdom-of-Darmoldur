using System.Text;
using System.Collections.Generic;
using UnityEngine;

abstract public class Node<T>
{
    List<Node<T>> neighbours;
    T value;
    abstract public string RoomType {get;}
    Vector3 position;
    public List<Node<T>> Neighbours {get {return neighbours;} set { neighbours = value;}}
    public T Value {get {return value;} set {this.value = value;}}
    public int NeighbourCount {get {return neighbours.Count;}}
    public Vector3 Position {get {return position;}}

    public Node(T value, Vector3 position)
    {
        this.value = value;
        neighbours = new List<Node<T>>();
        this.position = position;
    }
    public Node(T value, List<Node<T>> neighbours)
    {
        this.value = value;
        this.neighbours = neighbours;
    }


    public void AddEdge(Node<T> node)
    {
        neighbours.Add(node);
        node.neighbours.Add(this);
    }

    public void AddEdges(List<Node<T>> nodes)
    {
        neighbours.AddRange(nodes);
    }

    public void RemoveEdge(Node<T> node)
    {
        neighbours.Remove(node);
    }

    public override string ToString()
    {
        StringBuilder allNeighbours = new StringBuilder("");
        allNeighbours.Append(value + ": ");

        foreach (Node<T> neighbour in neighbours)
        {
            allNeighbours.Append(neighbour.value + " ");
        }

        return allNeighbours.ToString();
    }
    
}
