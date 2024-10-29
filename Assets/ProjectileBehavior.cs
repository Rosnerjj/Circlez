using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.position * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bottom")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
