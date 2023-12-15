using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneTenta : MonoBehaviour
{
    public GameObject cube;
    private const int nBaseObje = 5;//�쐬���鎲�I�u�W�F�N�g�Q�̃I�u�W�F�N�g��
    private const int nBranchObje = 5;//�G��I�u�W�F�N�g�Q�̃I�u�W�F�N�g��
    private const float fInterval = 0.5f;//���΋���
    private Vector3 v3Interval1 = new Vector3(0.0f, 0.5f, 0.0f);//�G�肪�L�тĂ�������
    
    public Renderer rend;

    // Use this for initialization
    void Start()
    {
       

        /*���I�u�W�F�N�g�Q�̍쐬�p�̕ϐ�*/
        int i;
        GameObject TempObj, lastGameObje, RootObje;
        Vector3 v3Position = transform.position;

        /*�I�u�W�F�N�g�̎擾�Ə�����*/
        RootObje = this.gameObject;
        RootObje.transform.position = v3Position;//�����ʒu�̐ݒ�
        RootObje.transform.parent = null; //�e�̐ݒ�
        //���X�g�I�u�W�F�N�g�̏�����
        lastGameObje = RootObje;
        //�[�x�̏�����
        int nDepth = 1;

        ///*���I�u�W�F�N�g�Q�̍쐬���[�v*/
        //for (i = 1; i <= nBaseObje; i++)
        //{
        //    v3Position.x += fInterval;//�V�K�����̃I�u�W�F�N�g�̑��΋�������
        //    TempObj = MyInstantiate(v3Position, lastGameObje, nDepth);//�V�����C���X�^���X�̍쐬
        //    lastGameObje = TempObj;//���X�g�I�u�W�F�N�g�̍X�V
        //    nDepth++;//�[�x�̍X�V
        //}

        /*�G��I�u�W�F�N�g�Q�쐬�p�̕ϐ�*/
        GameObject lastGameObje1 = lastGameObje;
        GameObject lastGameObje2 = lastGameObje;
        Vector3 v3Position1 = v3Position;
        Vector3 v3Position2 = v3Position;

        /*�G��I�u�W�F�N�g�Q�̍쐬���[�v*/
        for (i = 1; i <= nBranchObje; i++)
        {
            //��ڂ̐G��̍쐬
            v3Position1 += v3Interval1;
            TempObj = MyInstantiate(v3Position1, lastGameObje1, nDepth);
            lastGameObje1 = TempObj;
            
            nDepth++;
        }
    }

    
    GameObject MyInstantiate(Vector3 v3GenPos, GameObject GenParent, int nDepth)
    {
        //Cube�̐���
        GameObject GameObje = Instantiate(cube);
        //��������Cube�̈ʒu��ݒ�
        GameObje.transform.position = v3GenPos;
        //��������Cube�̐e��ݒ�
        GameObje.transform.parent = GenParent.transform;
        //��������Cube�̃X�N���v�g���擾
        EneTentaMove ScRef = GameObje.GetComponent<EneTentaMove>();
        //�擾�����X�N���v�g�ɐ[�x����
        ScRef.nDepth = nDepth;
        //�擾�����X�N���v�g��v3BasePos�ɐe�Ƃ̑��΋�������
        ScRef.v3BasePos = GameObje.transform.position - GameObje.transform.parent.position;
        //��������Cube�̎Q�Ƃ�Ԃ�
        return GameObje;
    }
}
