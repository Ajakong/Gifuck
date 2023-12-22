using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpImpact : MonoBehaviour
{

    private JumpImpact jumpImpact;
    //�@�p�[�e�B�N���V�X�e��
    private ParticleSystem ps;
    //�@ScaleUp�p�̌o�ߎ���
    private float elapsedScaleUpTime = 0f;
    //�@Scale��傫������Ԋu����
    [SerializeField]
    private float scaleUpTime = 0.06f;
    //�@ScaleUp���銄��
    [SerializeField]
    private float scaleUpParam = 0.1f;
    //�@�p�[�e�B�N���폜�p�̌o�ߎ���
    private float elapsedDeleteTime = 0f;
    //�@�p�[�e�B�N�����폜����܂ł̎���
    [SerializeField]
    private float deleteTime = 20f;



    //�@���̃p�[�e�B�N���̓����x
    private float alphaValue = 1f;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        jumpImpact = this.GetComponent<JumpImpact>();
        ps.trigger.SetCollider(0, jumpImpact.transform);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedScaleUpTime += Time.deltaTime;
        elapsedDeleteTime += Time.deltaTime;

        if (elapsedDeleteTime >= deleteTime)
        {
            Destroy(gameObject);
        }

        if (elapsedScaleUpTime > scaleUpTime)
        {
            transform.localScale += new Vector3(scaleUpParam, scaleUpParam, scaleUpParam);
            elapsedScaleUpTime = 0f;
        }
    }

    public void OnParticleTrigger()
    {

        if (ps != null)
        {

            //�@Particle�^�̃C���X�^���X����
            List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();
            List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();


            if (ps != null)
            {

                //�@�p�[�e�B�N����i�X�Ɠ��������鏈��
                List<ParticleSystem.Particle> outside = new List<ParticleSystem.Particle>();

                int numOutside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Outside, outside);

                alphaValue -= (1f / deleteTime) * Time.deltaTime;

                alphaValue = (alphaValue <= 0f) ? 0f : alphaValue;

                for (int i = 0; i < numOutside; i++)
                {
                    ParticleSystem.Particle p = outside[i];
                    p.startColor = new Color(1f, 1f, 1f, alphaValue);
                    outside[i] = p;
                }

                ps.SetTriggerParticles(ParticleSystemTriggerEventType.Outside, outside);

                //�@Inside�AEnter�̃p�[�e�B�N�����擾
                int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
                int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
                //�@�f�[�^������΃L�����N�^�[�ɐڐG����
                if (numInside != 0 || numEnter != 0)
                {
                    Debug.Log("�ڐG");

                }

                //�@�킩��₷���L�����N�^�[�ƐڐG�����p�[�e�B�N���̐F��ԂɕύX
                for (int i = 0; i < numInside; i++)
                {
                    ParticleSystem.Particle p = inside[i];
                    p.startColor = new Color32(255, 0, 0, 255);
                    inside[i] = p;
                }

                for (int i = 0; i < numEnter; i++)
                {
                    ParticleSystem.Particle p = enter[i];
                    p.startColor = new Color32(255, 0, 0, 255);
                    enter[i] = p;
                }

                //�@�p�[�e�B�N���f�[�^�̐ݒ�
                ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
                ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
            }
        }
    }
}