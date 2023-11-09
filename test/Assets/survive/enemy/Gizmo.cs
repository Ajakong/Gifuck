using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour
{
    public GameObject enemy;
    EnemyState state;
    Vector3 localScale;
    float barLongX;

    public float gizmoSize = 0.3f;
	public Color gizmoColor = Color.yellow;


    GameObject camera;

    private void Start()
    {
        state = enemy.GetComponent<EnemyState>();


        camera = GameObject.Find("Main Camera");
    }

    private void Update()
    {

        // this.transform.rotation = camera.transform.rotation;
        transform.rotation = Quaternion.identity;

    }

    void OnDrawGizmos()
	{
		Gizmos.color = gizmoColor;
		Gizmos.DrawWireSphere(transform.position, gizmoSize);
	}
}