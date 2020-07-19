using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGraph : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float Probability = 0.2f;
    int gSize;
    public GameObject room;
    public int scale = 5;
    UndirectedGraph<int> myGraph;
    System.Random nNodes;
    // Singleton pattern. THERE CAN BE ONLY YIN !
    private static GenerateGraph _instance;

    // ONLY YIN !1!!!1
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        nNodes = new System.Random();
        genGraphDbg();


    }

    // Generate corridors using door positions.
    public void GenerateCorridors()
    {

    }

    // Generates a new random dungeon and renders the rooms.
    public void genGraphDbg()
    {
        GameObject[] garbage = GameObject.FindGameObjectsWithTag("Room");
        foreach (var vRoom in garbage)
        {
            Destroy(vRoom);
        }
        myGraph = GenerateUndirectedGraph(nNodes.Next(15, 30), Probability);
        foreach (var item in myGraph.Nodes)
        {
            var roomInstance = Instantiate(room, item.Position, room.transform.rotation);
            roomInstance.name = item.RoomType;
        }
    }

    // Generates a new undirected graph using an adjacency matrix.
    public UndirectedGraph<int> GenerateUndirectedGraph(int size, float probability)
    {
        UndirectedGraph<int> graph = new UndirectedGraph<int>(size);
        System.Random rPos = new System.Random();
        int[,] adjMat = GenerateAdjacencyMatrix(size, probability);

        for (int x = 0; x < size; x++)
        {
            if (x == 0)
            {
                graph.AddNode(new EntryNode(x, Vector3.zero));

            }
            else if (x == size - 2)
            {
                graph.AddNode(new BossRoom(x, new Vector3(rPos.Next(x-3, x + 3) * scale, 0, rPos.Next(x-3, x + 3) * scale)));
            }
            else if (x == size - 1)
            {
                graph.AddNode(new ExitNode(x, new Vector3(rPos.Next(x-3, x + 3) * scale, 0, rPos.Next(x-3, x + 3) * scale)));
            }

            else
            {
                graph.AddNode(new RoomNode(x, new Vector3(rPos.Next(x-3, x + 3) * scale, 0, rPos.Next(x-3, x + 3) * scale)));
            }
        }

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                // int difference = Mathf.Abs(y) + x;
                if (adjMat[x, y] == 1 && !graph.Nodes[x].Neighbours.Contains(graph.Nodes[y]))
                {
                    graph.Nodes[x].AddEdge(graph.Nodes[y]);

                }
            }
        }

        return graph;
    }

    // Generates an adjacency matrix using a RNG and a probability parameter.
    // Possibly redundant.
    public int[,] GenerateAdjacencyMatrix(int size, float probability)
    {
        System.Random diceRoll = new System.Random();
        int[,] adjMat = new int[size, size];
        for (int x = 0; x < size; x++)
        {
            if(x == (int)size/2) probability -= 0.2f;
            
            for (int y = 0; y < size; y++)
            {
                int difference = Mathf.Abs(y) - x;
                if (diceRoll.NextDouble() < probability && x != y && difference < 3 && difference > 0)
                {
                    adjMat[x, y] = 1;
                }
            }
        }
        return adjMat;
    }

    // Draws Gizmos to debug the dungeon.
    void OnDrawGizmos()
    {
        if (myGraph != null)
        {
            for (int i = 0; i < myGraph.Size; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(myGraph.Nodes[i].Position, 0.1f);
                if (i != myGraph.Size - 1)
                {
                    // Add a line for all neighbours
                    Gizmos.color = Color.blue;
                    foreach (var nodulon in myGraph.Nodes[i].Neighbours)
                    {
                        Gizmos.DrawLine(myGraph.Nodes[i].Position, nodulon.Position);
                    }
                }
            }
        }

    }
}
