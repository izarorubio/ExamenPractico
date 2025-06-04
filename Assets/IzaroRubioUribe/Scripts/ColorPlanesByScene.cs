using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class ColorPlanesByScene : MonoBehaviour
{
    ARPlaneManager planeManager;

    Color targetColor;

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();

        // Determinar color según escena
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "EscenaRoja")
        {
            targetColor = Color.red;
        }
        else if (currentScene == "EscenaAmarilla")
        {
            targetColor = Color.yellow;
        }
        else
        {
            targetColor = Color.white;
        }

        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnDestroy()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            SetPlaneColor(plane);
        }

        foreach (var plane in args.updated)
        {
            SetPlaneColor(plane);
        }
    }

    void SetPlaneColor(ARPlane plane)
    {
        var meshRenderer = plane.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.material.color = targetColor;
        }
    }
}
