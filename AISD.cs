﻿### Двусвязный список
using System;

public class Node
{
    public int Data;
    public Node Next;
    public Node Prev;

    public Node(int data)
    {
        Data = data;
    }
}

public class DoublyLinkedList
{
    public Node Head;

    public void AddNode(int data)
    {
        Node newNode = new Node(data);

        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Prev = current;
        }
    }

    public void PrintList()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write($"{current.Data} ");
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.AddNode(1);
        list.AddNode(2);
        list.AddNode(3);

        list.PrintList();
    }
}


### Кольцевой список
using System;

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
    }
}

public class CircularLinkedList
{
    private Node Head;

    public void AddNode(int data)
    {
        Node newNode = new Node(data);

        if (Head == null)
        {
            Head = newNode;
            Head.Next = Head;
        }
        else
        {
            Node tail = Head;
            while (tail.Next != Head)
            {
                tail = tail.Next;
            }
            tail.Next = newNode;
            newNode.Next = Head;
        }
    }

    public void PrintList()
    {
        if (Head == null)
            return;

        Node current = Head;
        do
        {
            Console.Write($"{current.Data} ");
            current = current.Next;
        } while (current != Head);
    }
}

class Program
{
    static void Main()
    {
        CircularLinkedList list = new CircularLinkedList();
        list.AddNode(1);
        list.AddNode(2);
        list.AddNode(3);

        list.PrintList();
    }
}


### Бинарное дерево поиска
using System;

public class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    public Node(int data)
    {
        Data = data;
    }
}

public class BinarySearchTree
{
    private Node Root;

    public void AddNode(int data)
    {
        Root = InsertRec(Root, data);
    }

    private Node InsertRec(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data < root.Data)
        {
            root.Left = InsertRec(root.Left, data);
        }
        else if (data > root.Data)
        {
            root.Right = InsertRec(root.Right, data);
        }

        return root;
    }

    public void InOrderTraversal(Node node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.Write($"{node.Data} ");
            InOrderTraversal(node.Right);
        }
    }
}

class Program
{
    static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();
        tree.AddNode(5);
        tree.AddNode(3);
        tree.AddNode(7);
        tree.AddNode(2);

        tree.InOrderTraversal(tree.Root);
    }
}

граф:
-списки смежности
using System;
using System.Collections.Generic;

class Graph
{
    private int V; // количество вершин
    private List<int>[] adj; // списки смежности

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            adj[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
        adj[w].Add(v); // если граф ненаправленный
    }

    public void PrintGraph()
    {
        for (int i = 0; i < V; i++)
        {
            Console.Write("Вершина " + i + " смежна с: ");
            foreach (var vertex in adj[i])
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Graph g = new Graph(4);

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 3);

        g.PrintGraph();
    }
}

матрица смежности:

using System;

class Graph
{
    private int V; // количество вершин
    private int[,] adjMatrix; // матрица смежности

    public Graph(int v)
    {
        V = v;
        adjMatrix = new int[V, V];
    }

    public void AddEdge(int v, int w)
    {
        adjMatrix[v, w] = 1;
        adjMatrix[w, v] = 1; // если граф ненаправленный
    }

    public void PrintGraph()
    {
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                Console.Write(adjMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Graph g = new Graph(4);

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 3);

        g.PrintGraph();
    }
}

Обход в ширину (BFS):
using System;
using System.Collections.Generic;

class Graph
{
    private int V; // количество вершин
    private List<int>[] adjList; // список смежности

    public Graph(int v)
    {
        V = v;
        adjList = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            adjList[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adjList[v].Add(w);
    }

    public void BFS(int s)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count != 0)
        {
            s = queue.Dequeue();
            Console.Write(s + " ");

            foreach (int n in adjList[s])
            {
                if (!visited[n])
                {
                    visited[n] = true;
                    queue.Enqueue(n);
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Graph g = new Graph(4);

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 3);

        Console.WriteLine("BFS traversal starting from vertex 0:");
        g.BFS(0);
    }
}


Обход в глубину (DFS):

using System;
using System.Collections.Generic;

class Graph
{
    private int V; // количество вершин
    private List<int>[] adjList; // список смежности

    public Graph(int v)
    {
        V = v;
        adjList = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            adjList[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adjList[v].Add(w);
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int n in adjList[v])
        {
            if (!visited[n])
            {
                DFSUtil(n, visited);
            }
        }
    }

    public void DFS(int s)
    {
        bool[] visited = new bool[V];
        DFSUtil(s, visited);
    }
}

class Program
{
    static void Main()
    {
        Graph g = new Graph(4);

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 3);

        Console.WriteLine("DFS traversal starting from vertex 0:");
        g.DFS(0);
    }
}

быстрая сортировка:
using System;

class QuickSort
{
    public void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            Sort(arr, low, pi - 1);
            Sort(arr, pi + 1, high);
        }
    }

    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        return i + 1;
    }
}

class Program
{
    static void Main()
    {
        int[] arr = { 38, 27, 43, 3, 9, 82, 10 };

        QuickSort qs = new QuickSort();
        qs.Sort(arr, 0, arr.Length - 1);

        Console.WriteLine("Sorted array:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
    }
}


Сортировка слиянием:
using System;

class MergeSort
{
    public void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            Sort(arr, left, middle);
            Sort(arr, middle + 1, right);

            Merge(arr, left, middle, right);
        }
    }

    private void Merge(int[] arr, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, middle + 1, R, 0, n2);

        int i = 0, j = 0;
        int k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }
}

class Program
{
    static void Main()
    {
        int[] arr = { 38, 27, 43, 3, 9, 82, 10 };

        MergeSort ms = new MergeSort();
        ms.Sort(arr, 0, arr.Length - 1);

        Console.WriteLine("Sorted array:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
    }
}

хэш - таблицы(с перехэшированием):
-открытая адресация(двойное хэширование)
using System;

class HashTable
{
    private int[] keys;
    private int[] values;
    private int size;

    public HashTable(int size)
    {
        this.size = size;
        keys = new int[size];
        values = new int[size];
    }

    private int HashFunction1(int key)
    {
        return key % size;
    }

    private int HashFunction2(int key)
    {
        return 5 - key % 5; // пример второй хэш-функции
    }

    public void Insert(int key, int value)
    {
        int index = HashFunction1(key);

        if (keys[index] == 0)
        {
            keys[index] = key;
            values[index] = value;
        }
        else
        {
            int index2 = HashFunction2(key);
            int i = 1;

            while (true)
            {
                int newIndex = (index + i * index2) % size;

                if (keys[newIndex] == 0)
                {
                    keys[newIndex] = key;
                    values[newIndex] = value;
                    break;
                }

                i++;
            }
        }
    }

    public int Search(int key)
    {
        int index = HashFunction1(key);

        if (keys[index] == key)
        {
            return values[index];
        }
        else
        {
            int index2 = HashFunction2(key);
            int i = 1;

            while (true)
            {
                int newIndex = (index + i * index2) % size;

                if (keys[newIndex] == key)
                {
                    return values[newIndex];
                }

                if (keys[newIndex] == 0) // элемент не найден
                {
                    return -1;
                }

                i++;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        HashTable hashTable = new HashTable(10);

        hashTable.Insert(5, 10);
        hashTable.Insert(15, 20);
        hashTable.Insert(25, 30);

        Console.WriteLine("Value for key 5: " + hashTable.Search(5));
        Console.WriteLine("Value for key 15: " + hashTable.Search(15));
        Console.WriteLine("Value for key 25: " + hashTable.Search(25));
    }
}

хэш - таблицы(с перехэшированием):
-метод цепочек
using System;
using System.Collections.Generic;

class HashTable
{
    private List<KeyValuePair<int, int>>[] table;
    private int size;

    public HashTable(int size)
    {
        this.size = size;
        table = new List<KeyValuePair<int, int>>[size];
        for (int i = 0; i < size; i++)
        {
            table[i] = new List<KeyValuePair<int, int>>();
        }
    }

    private int HashFunction(int key)
    {
        return key % size;
    }

    public void Insert(int key, int value)
    {
        int index = HashFunction(key);
        table[index].Add(new KeyValuePair<int, int>(key, value));
    }

    public int Search(int key)
    {
        int index = HashFunction(key);
        foreach (KeyValuePair<int, int> pair in table[index])
        {
            if (pair.Key == key)
            {
                return pair.Value;
            }
        }
        return -1; // элемент не найден
    }
}

class Program
{
    static void Main()
    {
        HashTable hashTable = new HashTable(10);

        hashTable.Insert(5, 10);
        hashTable.Insert(15, 20);
        hashTable.Insert(25, 30);

        Console.WriteLine("Value for key 5: " + hashTable.Search(5));
        Console.WriteLine("Value for key 15: " + hashTable.Search(15));
        Console.WriteLine("Value for key 25: " + hashTable.Search(25));
    }
}

хэш - таблицы(с перехэшированием):
-метод цепочек
using System;
using System.Collections.Generic;

class HashTable
{
    private List<KeyValuePair<int, int>>[] table;
    private int size;

    public HashTable(int size)
    {
        this.size = size;
        table = new List<KeyValuePair<int, int>>[size];
        for (int i = 0; i < size; i++)
        {
            table[i] = new List<KeyValuePair<int, int>>();
        }
    }

    private int HashFunction(int key)
    {
        return key % size;
    }

    public void Insert(int key, int value)
    {
        int index = HashFunction(key);
        table[index].Add(new KeyValuePair<int, int>(key, value));
    }

    public int Search(int key)
    {
        int index = HashFunction(key);
        foreach (KeyValuePair<int, int> pair in table[index])
        {
            if (pair.Key == key)
            {
                return pair.Value;
            }
        }
        return -1; // элемент не найден
    }
}

class Program
{
    static void Main()
    {
        HashTable hashTable = new HashTable(10);

        hashTable.Insert(5, 10);
        hashTable.Insert(15, 20);
        hashTable.Insert(25, 30);

        Console.WriteLine("Value for key 5: " + hashTable.Search(5));
        Console.WriteLine("Value for key 15: " + hashTable.Search(15));
        Console.WriteLine("Value for key 25: " + hashTable.Search(25));
    }
}