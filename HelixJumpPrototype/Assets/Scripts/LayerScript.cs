using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerScript : MonoBehaviour
{
    //3 possibilities for slices: Safe slice, killer slice, no slice
    private int chosenForm;
    private GameObject[] slices;
    
    public Material[] sliceColors;
    private void Awake()
    {
        slices = new GameObject[12];
        for(int i = 0; i < 12; i++)
        {
            slices[i] = gameObject.transform.GetChild(i).gameObject;
        }
        DetermineSlices();        
    }

    void DetermineSlices()
    {
        for(int i = 0; i < 12; i++)
        {
            chosenForm = (int)Random.Range(0, 2.9f);
            if(chosenForm == 1)
            {
                slices[i].gameObject.tag = "Killer";
                slices[i].gameObject.GetComponent<Renderer>().material = sliceColors[1];
            }
            else if(chosenForm == 2)
            {
                Destroy(slices[i].gameObject);
            }
            else //Safe slice
            {
                slices[i].gameObject.GetComponent<Renderer>().material = sliceColors[0];
            }
        }
    }
}
