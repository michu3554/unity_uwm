using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
    public GameObject myPrefab;
    public int NumberOfObjects = 10;

    public float planeWidth = 10f;
    public float planeLength = 10f;

    public float objectWidth = 1f;
    public float objectLength = 1f;

    void Start()
    {
        List<Vector3> takenPositions = new List<Vector3>();

        for (int i = 0; i < NumberOfObjects; i++)
        {
            Vector3 randomPosition = GetPosition(takenPositions);
            Instantiate(myPrefab, randomPosition, Quaternion.identity);
            takenPositions.Add(randomPosition);
        }
    }

    Vector3 GetPosition(List<Vector3> takenPositions)
    {
        float halfObjectWidth = objectWidth / 2;
        float halfObjectLength = objectLength / 2;

        Vector3 position = new Vector3(Random.Range(-planeWidth / 2 + halfObjectWidth, planeWidth / 2 - halfObjectWidth), 0f, Random.Range(-planeLength / 2 + halfObjectLength, planeLength / 2 - halfObjectLength));

        while (IsOverlapping(position, takenPositions))
        {
            position = new Vector3(Random.Range(-planeWidth / 2 + halfObjectWidth, planeWidth / 2 - halfObjectWidth), 0f, Random.Range(-planeLength / 2 + halfObjectLength, planeLength / 2 - halfObjectLength));
        }

        return position;
    }

    bool IsOverlapping(Vector3 position, List<Vector3> takenPositions)
    {
        foreach (Vector3 takenPosition in takenPositions)
        {
            if (Vector3.Distance(position, takenPosition) < (objectWidth + objectLength) / 2)
            {
                return true;
            }
        }
        return false;
    }
}
