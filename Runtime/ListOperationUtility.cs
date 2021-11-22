﻿using UnityEngine;
namespace SoulShard.Utils
{
    /// <summary>
    /// contains some basic functions to generate and manager collections
    /// </summary>
    public struct CollectionUtility
    {
        /// <summary>
        /// generates a new 2d array with a default value
        /// </summary>
        /// <typeparam name="T">the type of the collection</typeparam>
        /// <param name="xLength">the x length of the array</param>
        /// <param name="yLength">the y length of the array</param>
        /// <param name="defaultValue">the default value for the array</param>
        /// <returns>the new collection</returns>
        public static T[,] GenerateNew2dArray<T>(int xLength, int yLength, T defaultValue) where T : new()
        {
            T[,] @return = new T[xLength, yLength];
            if (defaultValue == null)
                return null;
            for (int i = 0; i < xLength; i++)
            {
                for (int e = 0; e < yLength; e++)
                    @return[i, e] = defaultValue;
            }
            return @return;
        }
        /// <summary>
        /// generates a new array with a default value
        /// </summary>
        /// <typeparam name="T">the type of the collection</typeparam>
        /// <param name="length">the length of the new collection</param>
        /// <param name="defaultValue">the default value of the collection</param>
        /// <returns>the new collection</returns>
        public static T[] GenerateNewArray<T>(int length, T defaultValue)
        {
            T[] @return = new T[length];
            for (int i = 0; i < length; i++)
                @return[i] = defaultValue;
            return @return;
        }
        /// <summary>
        /// gets a specific component from every gameobject in the list, and returns a list of the components.
        /// </summary>
        /// <typeparam name="T">the component to get from every object</typeparam>
        /// <param name="toGetComponentFrom">the array to get the components from</param>
        /// <returns>the collection of monobehaviors</returns>
        public static T[] GetComponentFromGameObjectList<T>(GameObject[] toGetComponentFrom) where T : MonoBehaviour
        {
            T[] @return = new T[toGetComponentFrom.Length];
            for (int i = 0; i < toGetComponentFrom.Length; i++)
                @return[i] = toGetComponentFrom[i].GetComponent<T>();
            return @return;
        }
        /// <summary>
        /// takes in a boolean list and checks if all the values are the same
        /// </summary>
        /// <typeparam name="T">the type of the collection</typeparam>
        /// <param name="list">the collection to compare</param>
        /// <returns>whether the list contains all of the same values</returns>
        public static bool? ListIsRepeatedValues<T>(T[] list) where T: System.IEquatable<T>
        {
            if (list.Length == 0)
                return null;
            T start = list[0];
            foreach (T t in list)
                if (!t.Equals(start))
                    return false;
            return true;
        }
    }
}