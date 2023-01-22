using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float size;
    private Transform tf;
    private Vector2 center;

    private void Start()
    {
        tf = GetComponent<Transform>();
        center = new Vector2(tf.position.x, tf.position.y);
    }

    public void Spawn()
    {
        Instantiate(prefab, center, Quaternion.identity);
        Debug.Log(center.x + " " + center.y);
    }

    public void SpawnInArea()
    {
        float x = center.x;
        float y = center.y;
        Vector3 randomSpawnPosition = new Vector3(Random.Range(x - size, x + size), Random.Range(y - size, y + size));
        Instantiate(prefab, randomSpawnPosition, Quaternion.identity);
    }
}

/*
if (Input.GetKeyDown(KeyCode.Space))
{
    int randomIndex = Random.Range(0, myObjects.Length);
    Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));

    Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
*/