using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayObjectSpawner : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer obstacleRenderer;
    public PolygonCollider2D polygonCollider;
    public int moveSpeed;
    private Spawner spawner;

    private void Start()
    {
        // Find the Spawner.
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();

        // Gets a random prefab.
        obstacleRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        // Gets the collider of the sprite.
        polygonCollider = GetComponent<PolygonCollider2D>();

        // Makes objects and renders their path.
        List<Vector2> path = new List<Vector2>();
        path.Clear();
        obstacleRenderer.sprite.GetPhysicsShape(0, path);
        polygonCollider.SetPath(0, path.ToArray());
    }

    void FixedUpdate()
    {
        // Get speed from spawner.
        moveSpeed = spawner.GetSpeed();

        // Move at a fixed rate to the left.
        transform.position -= transform.right * moveSpeed * Time.deltaTime;
    }
}
