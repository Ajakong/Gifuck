using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //NavMeshAgent���g�����߂̐錾
using UnityEngine.Playables; //PlayableDirector���g�����߂̐錾
public class BossController : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Chase,
        Attack,
        Freeze
    };

    //�p�����[�^�֐��̒�`
    public EnemyState state; //�L�����̏��
    private Transform targetTransform; //�^�[�Q�b�g�̏��
    private NavMeshAgent navMeshAgent; //NavMeshAgent�R���|�[�l���g
    public Animator animator; //Animator�R���|�[�l���g
    [SerializeField]
    private PlayableDirector timeline; //PlayableDirector�R���|�[�l���g
    private Vector3 destination; //�ړI�n�̈ʒu�����i�[���邽�߂̃p�����[�^

    void Start()
    {
        //�L������NavMeshAgent�R���|�[�l���g��navMeshAgent���֘A�t����
        navMeshAgent = GetComponent<NavMeshAgent>();

        //�L�������f����Animator�R���|�[�l���g��animator���֘A�t����
        animator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();

        SetState(EnemyState.Idle); //������Ԃ�Idle��Ԃɐݒ肷��
    }

    void Update()
    {
        //�v���C���[��ړI�n�ɂ��ĒǐՂ���
        if (state == EnemyState.Chase)
        {
            if (targetTransform == null)
            {
                SetState(EnemyState.Idle);
            }
            else
            {
                SetDestination(targetTransform.position);
                navMeshAgent.SetDestination(GetDestination());
            }
            //�@�G�̌������v���C���[�̕����ɏ����Âς���
            var dir = (GetDestination() - transform.position).normalized;
            dir.y = 0;
            Quaternion setRotation = Quaternion.LookRotation(dir);
            //�@�Z�o���������̊p�x��G�̊p�x�ɐݒ�
            transform.rotation = Quaternion.Slerp(transform.rotation, setRotation, navMeshAgent.angularSpeed * 0.1f * Time.deltaTime);
        }
    }

    //��Ԉڍs���ɌĂ΂�鏈��
    public void SetState(EnemyState tempState, Transform targetObject = null)
    {
        state = tempState;

        if (tempState == EnemyState.Idle)
        {
            if (navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
            {
                navMeshAgent.isStopped = true; //�L�����̈ړ����~�߂�
                animator.SetBool("chase", false); //�A�j���[�V�����R���g���[���[�̃t���O�ؑցiChase��Idle��������Freeze��Idle�j
            }
        }
        else if (tempState == EnemyState.Chase)
        {
            if (navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
            {
                targetTransform = targetObject; //�^�[�Q�b�g�̏����X�V
                navMeshAgent.SetDestination(targetTransform.position); //�ړI�n���^�[�Q�b�g�̈ʒu�ɐݒ�
                navMeshAgent.isStopped = false; //�L�����𓮂���悤�ɂ���
                animator.SetBool("chase", true); //�A�j���[�V�����R���g���[���[�̃t���O�ؑցiIdle��Chase�j
            }
        }
        else if (tempState == EnemyState.Attack)
        {
            if (navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
            {
                navMeshAgent.isStopped = true; //�L�����̈ړ����~�߂�
                animator.SetBool("chase", false);
                timeline.Play();//�U���p�̃^�C�����C�����Đ�����
            }
        }
        else if (tempState == EnemyState.Freeze)
        {
            Invoke("ResetState", 2.0f);
        }
    }

    //�@�G�L�����N�^�[�̏�Ԏ擾���\�b�h
    public EnemyState GetState()
    {
        return state;
    }

    //�@�ړI�n��ݒ肷��
    public void SetDestination(Vector3 position)
    {
        destination = position;
    }

    //�@�ړI�n���擾����
    public Vector3 GetDestination()
    {
        return destination;
    }

    public void FreezeState()
    {
        SetState(EnemyState.Freeze); ;
    }

    private void ResetState()
    {
        SetState(EnemyState.Idle); ;
    }
}
