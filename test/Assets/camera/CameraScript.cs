using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    private Vector3 velocity = Vector3.zero;
    
    public float smoothTime = 0.3f;
    
    private void Start()
    {

    }
    void Update()
    {
        //// �}�E�X�̈ړ��ʂ��擾
        //mx = Input.GetAxis("Mouse X");
        //my = Input.GetAxis("Mouse Y");

        //// X�����Ɉ��ʈړ����Ă���Ή���]
        //if (Mathf.Abs(mx) > 0.001f)
        //{
        //    // ��]���̓��[���h���W��Y��
        //    transform.RotateAround(player.transform.position, Vector3.up, mx * 5f);
        //}

        //// Y�����Ɉ��ʈړ����Ă���Ώc��]
        //if (Mathf.Abs(my) > 0.001f)
        //{
        //    // ��]���̓J�������g��X��
        //    transform.RotateAround(transform.position, transform.right, my * 0.5f);
        //}
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}