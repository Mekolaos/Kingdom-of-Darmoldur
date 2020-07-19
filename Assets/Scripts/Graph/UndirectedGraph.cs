using System;
using System.Collections.Generic;
using UnityEngine;


public class UndirectedGraph<T>
{
    private List<Node<T>> nodes;
    public int size {get;}
    

    public List<Node<T>> Nodes {get { return nodes;}}
    public int Size {get { return nodes.Count; }}

    public UndirectedGraph(int initialSize)
    {
        if(size < 0)
        {
            throw new ArgumentException("Number of vertices cannot be negative.");
        }

        size = initialSize;
        nodes = new List<Node<T>>(initialSize);
    }

    public UndirectedGraph(List<Node<T>> initialNodes)
    {
        nodes = initialNodes;
        size = nodes.Count;
    }

    public void AddNode(Node<T> node)
    {
        nodes.Add(node);
    }

    public void RemoveNode(Node<T> node)
    {
        nodes.Remove(node);
    }

    public void AddNodes(List<Node<T>> nodes_t)
    {
        nodes.AddRange(nodes_t);
    }

    

    public bool ContainsNode(Node<T> node)
    {
        return nodes.Contains(node);
    }

    

    


}
