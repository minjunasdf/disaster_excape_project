using UnityEngine;
using Unity.MLAgents;

public class ExcapeAgent : Agent
{
    public GameObject Area;
    //�ʱ�ȭ �۾��� ���� �ѹ� ȣ��Ǵ� �޼ҵ�
    public override void Initialize()
    {
        
    }
    //���Ǽҵ�(�н�����)�� �����Ҷ����� ȣ��
    public override void OnEpisodeBegin()
    {
        Area = GameObject.Find("Area");
        Area.GetComponent<CreateRescueNeeded>().Init();
    }
    

    /*
    //ȯ�� ������ ���� �� ������ ��å ������ ���� �극�ο� �����ϴ� �޼ҵ�
    public override void CollectObservations()
    {

    }
    */


    /*
    //�극��(��å)���� ���� ���� ���� �ൿ�� �����ϴ� �޼ҵ�
    public override void OnActionReceived()
    {

    }

    //������(�����)�� ���� ����� ������ ȣ���ϴ� �޼ҵ�(�ַ� �׽�Ʈ�뵵 �Ǵ� ����н��� ���)
    public override void Heuristic()
    {

    }
    */
}

