using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class HighlightSelectable : MonoBehaviour
{
    private Renderer _renderer;
    private MaterialPropertyBlock _matblock;
    bool activated = false;
    
    void Awake()
    {
        _matblock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }


    void OnMouseEnter()
    {
        if(!activated)
        {
            _renderer.GetPropertyBlock(_matblock);
            _matblock.SetFloat("_Activate", 1f);
            _renderer.SetPropertyBlock(_matblock);
        }
        activated = true;
    }

    void OnMouseExit()
    {
        if(activated)
        {
            _renderer.GetPropertyBlock(_matblock);
            _matblock.SetFloat("_Activate", 0f);
            _renderer.SetPropertyBlock(_matblock);
        }
        activated = false;
    }
}
