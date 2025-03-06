using System.Collections;
using UnityEngine;

public class DropCubesCheckpoint : MonoBehaviour
{
    public GameObject cubes;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = cubes.GetComponent<Rigidbody>();
    }

    public IEnumerator DropCubes()
    {
        rb.isKinematic = false;
        yield return new WaitForSeconds(3);
        Destroy(cubes);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DropCubes());
            Destroy(gameObject);
        }
    }
}
