using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Letter : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TextMeshProUGUI tMesh;
    public Renderer tRend;
    public bool big = false;
    private char _c;
    private Renderer rend;

    private void Awake()
    {
        tMesh = GetComponentInChildren<TextMeshProUGUI>();
        tRend = tMesh.GetComponent<Renderer>();
        rend = GetComponent<Renderer>();
        visible = false;
    }

    public char c
    {
        get { return _c; }
        set
        {
            _c = value;
            tMesh.text = _c.ToString();
        }
    }

    public string str
    {
        get { return _c.ToString(); }
        set { c=value[0]; } 
    }

    public bool visible
    {
        get { return tRend.enabled; }
        set { tRend.enabled = value; }
    }

    public Color color
    {
        get { return rend.material.color; }
        set { rend.material.color = value; } 
    }

    public Vector3 pos
    {
        set
        {
            transform.position = value;
        }
    }
}
