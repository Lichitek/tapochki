using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject[] block; //������ �� ��-��, ������� ����� �������� ��� ������� ������
    public Sprite btnDown; //������ ������, ����� ��� ���
    public GameObject butTon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) //����� 
    {
        if (collision.gameObject.tag == "mark") //���� ������ ������������ �������
        {

            butTon.GetComponent<SpriteRenderer>().sprite = btnDown; //����������� ����� ������
            butTon.GetComponent<BoxCollider2D>().enabled = false; //��������� ���������, ����� ������ ���

            foreach (GameObject obj in block) //���� ��� ������� ������� �� ��������, ����� ��� ������
            {
                Destroy(obj); //�������
            }
        }
    }
}
