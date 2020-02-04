using UnityEngine;

public struct ID
{
    private int id;

    public int Id
    {
        get
        {
            return id++;
        }
    }
}