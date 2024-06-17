using UnityEngine;

public class Clickers : MonoBehaviour
{
    protected float positionx;
    protected float positiony;

    protected virtual void Start()
    {
        positionx = Random.Range(-0.85f, -7.6f);
        positiony = Random.Range(-3.7f, 3.8f);
        gameObject.transform.position = new Vector3 (positionx, positiony, 0);
    }
}
