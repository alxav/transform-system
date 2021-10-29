using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisibleAthlete : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> meshRenderers;
    [SerializeField] private TextMeshPro numberText;

    public void Instantiate(Color color, int number)
    {
        meshRenderers.ForEach((mesh) =>
        {
            mesh.material.color = color;
            numberText.text = number.ToString();
        });
    }

}
