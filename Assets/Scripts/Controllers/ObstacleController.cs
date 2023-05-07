using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private StackController stack;
    private CubeController cube;
    private int count;
    private List<CubeController> tempList;
    private CameraController camera;
    private bool control = true;
    private int cubeIndex;
    private void Start()
    {
        camera = CameraController.GetInstance();
        tempList = new List<CubeController>();
        stack = FindObjectOfType<StackController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<BoxCollider>().isTrigger = false;
        if (control)
        {
            StartCoroutine(coolDown());
            control = false;
            other.GetComponent<IObstacleable>()?.Obstacled(Obstacled);
        }

    }

    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(0.1F);
        control = true;
    }

    public void Obstacled(CubeController cube)
    {
        /*
        Debug.Log("a");
        count = stack.listCube.Count;
        int a = stack.listCube.IndexOf(cube);
        for (int i = count-1; i >= a; i--)
        {
            tempList.Add(stack.listCube[i]);
            camera.OnCubeDecreeasePosition();
            stack.listCube[i].GetComponent<Rigidbody>().isKinematic = false;
            stack.listCube[i].GetComponent<BoxCollider>().isTrigger = false;
        }
        for (int i = count-1; i >= a; i--)
        {
            stack.listCube[i].Remove(3);
            stack.listCube.RemoveAt(i);
        }*/

        cubeIndex = stack.listCube.IndexOf(cube);
        for (int i = 0; i < cubeIndex; i++)
        {
            CubeController tempCube = stack.listCube[0];
            tempCube.GetComponent<BoxCollider>().isTrigger = false;
            Rigidbody cubeRigidbody = tempCube.GetComponent<Rigidbody>();
            cubeRigidbody.isKinematic = false;
            tempCube.Remove(3);
            stack.listCube.RemoveAt(0);


        }
    }
}