using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// I use this Heap Class instead of a list for effeciency

// Creates a class where T is a placeholder for the data type that will be used when creating an instance of the class
// This means that this class can work with many different data types as long as they implement the interface IHeapItem<T>
public class Heap<T> where T : IHeapItem<T>
{
    // Creates an array of T items
    T[] items;
    // Stores how many items there are currently in the array
    int currentItemCount;
    // When Heap is used a maxHeapsize must also be passed in as a parameter
    public Heap(int maxHeapSize)
    {
        items = new T[maxHeapSize];
    }
    // The method to add an item to the heap
    public void Add(T item)
    {
        item.HeapIndex = currentItemCount;
        items[currentItemCount] = item;
        Sortup(item);
        currentItemCount++;
    }
    public T RemoveFirst()
    {
        // the equivalent of pop
        T firstItem = items[0];
        currentItemCount --;
        items[0] = items[currentItemCount];
        items[0].HeapIndex = 0;
        // need to resort the new root after removing the old root
        SortDown(items[0]);
        return firstItem;

    }
    public bool Contains(T item)
    {
        return Equals(items[item.HeapIndex], item);
    }
    public int Count
    {
        get
        {
            return currentItemCount;
        }
    }
    public void UpdateITem(T item)
    {
        Sortup(item);
    }
    void SortDown (T item)
    {
        while (true)
        {
            // root nodes are always going to be: left=2n+1 right=2n+2
            int childIndexLeft = item.HeapIndex * 2 + 1;
            int childIndexRight = item.HeapIndex * 2 + 2;
            int swapIndex  = 0;
            // keeps swapping until sorted
            if(childIndexLeft< currentItemCount)
            {
                swapIndex = childIndexLeft;
                if(childIndexRight < currentItemCount)
                {
                    if (items[childIndexLeft].CompareTo(items[childIndexRight]) < 0)
                    {
                        swapIndex = childIndexRight;
                    }
                }
                if (item.CompareTo(items[swapIndex]) < 0)
                {
                    Swap(item, items[swapIndex]);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
    void Sortup(T item)
    {
        // To find the parent of the node in the array it is always (n-1)/2
        int parentIndex = (item.HeapIndex - 1) / 2;
        while (true)
        {
            T parentItem = items[parentIndex];
            //higher priority returns 1 same = returns 0 lower returns -1 if it has higher than means it got lower fcost we want to swap it
            if (item.CompareTo(parentItem) > 0)
            {
                Swap(item, parentItem);
            }
            else
            {
                break;
            }
            // change the parent index again after swapping
            parentIndex = (item.HeapIndex - 1) / 2;
        }
    }
    void Swap(T itemA, T itemB)
    {
        // Swaps the two items in the array 
        items[itemA.HeapIndex] = itemB;
        items[itemB.HeapIndex] = itemA;
        // temp value to store index
        int itemAIndex = itemA.HeapIndex;
        itemA.HeapIndex = itemB.HeapIndex;
        itemB.HeapIndex = itemAIndex;
    }
}
public interface IHeapItem<T> : IComparable<T>
{
    // any type that uses a heap must contain a heap index
    int HeapIndex { get; set; }
}