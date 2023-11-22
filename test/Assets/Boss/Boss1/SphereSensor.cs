using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SphereSensor : MonoBehaviour
{
    [SerializeField]
    private SphereCollider searchArea = default;
    [SerializeField]
    private float searchAngle = 45f;
    private LayerMask obstacleLayer = default;
    private BossController enemyMove = default;

    private void Start()
    {
        enemyMove = transform.parent.GetComponent<BossController>();
    }

    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {
            var playerDirection = target.transform.position - transform.position;

            var angle = Vector3.Angle(transform.forward, playerDirection);

            if (angle <= searchAngle)
            {
                //obstacleLayer = LayerMask.GetMask("Block", "Wall");

                if (!Physics.Linecast(transform.position + Vector3.up, target.transform.position + Vector3.up, obstacleLayer))�@//�v���C���[�Ƃ̊Ԃɏ�Q�����Ȃ��Ƃ�
                {
                    if (Vector3.Distance(target.transform.position, transform.position) <= searchArea.radius * 0.5f
                        && Vector3.Distance(target.transform.position, transform.position) >= searchArea.radius * 0.05f)
                    {
                        enemyMove.SetState(BossController.EnemyState.Attack);
                    }
                    else if (Vector3.Distance(target.transform.position, transform.position) <= searchArea.radius
                        && Vector3.Distance(target.transform.position, transform.position) >= searchArea.radius * 0.5f
                        && enemyMove.state == BossController.EnemyState.Idle)
                    {
                        enemyMove.SetState(BossController.EnemyState.Chase, target.transform); // �Z���T�[�ɓ������v���C���[���^�[�Q�b�g�ɐݒ肵�āA�ǐՏ�ԂɈڍs����B
                    }
                }
            }
            else if (angle > searchAngle)
            {
                enemyMove.SetState(BossController.EnemyState.Idle);
            }
        }
    }
#if UNITY_EDITOR
    //�@�T�[�`����p�x�\��
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -searchAngle, 0f) * transform.forward, searchAngle * 2f, searchArea.radius);
    }
#endif
}
