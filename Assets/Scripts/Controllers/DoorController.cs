using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : AbstractColor
{
    private ParticleSystem particle;
    private StackController stack;
    private CharacterController character;

    private void Start()
    {
        stack = FindObjectOfType<StackController>();
        character = FindObjectOfType<CharacterController>();
        material = gameObject.GetComponent<Renderer>().material;
        particle = GetComponentInChildren<ParticleSystem>();
        particle.startColor = GetColor();

    }

    private void OnTriggerEnter(Collider other)
    {
        character.ChangeColor(colorType);
        stack.ChangeColor(colorType);
        for (int i = 0; i < stack.listCube.Count; i++)
        {
            stack.listCube[i].ChangeColor(colorType);
        }
    }

}
