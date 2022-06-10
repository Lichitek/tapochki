using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1 : MonoBehaviour
{
    public GameObject[] block; //������ �� ��-��, ������� ����� �������� ��� ������� ������
    public Sprite btnDown; //������ ������, ����� ��� ���
    public GameObject butTon;

    private void OnCollisionEnter2D(Collision2D collision) //����� 
    {

        if (collision.gameObject.tag == "mark") //���� ������ ������������ �������
        {

            butTon.GetComponent<SpriteRenderer>().sprite = btnDown; //����������� ����� ������
            butTon.GetComponent<BoxCollider2D>().enabled = false; //��������� ���������, ����� ������ ���

            foreach (GameObject obj in block) //���� ��� ������� ������� �� ��������, ����� ��� ������
            {
                obj.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "block") //���� ������ ������������ �������
        {

            GetComponent<SpriteRenderer>().sprite = btnDown; //����������� ����� ������
            GetComponent<BoxCollider2D>().enabled = false; //��������� ���������, ����� ������ ���
            collision.gameObject.GetComponent<Rigidbody2D>().Sleep();

            foreach (GameObject obj in block) //���� ��� ������� ������� �� ��������, ����� ��� ������
            {
                obj.SetActive(true);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mark") //���� ������ ������������ �������
        {

            butTon.GetComponent<SpriteRenderer>().sprite = btnDown; //����������� ����� ������
            butTon.GetComponent<BoxCollider2D>().enabled = false; //��������� ���������, ����� ������ ���

            foreach (GameObject obj in block) //���� ��� ������� ������� �� ��������, ����� ��� ������
            {
                obj.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "block") //���� ������ ������������ �������
        {

            GetComponent<SpriteRenderer>().sprite = btnDown; //����������� ����� ������
            GetComponent<BoxCollider2D>().enabled = false; //��������� ���������, ����� ������ ���
            collision.gameObject.GetComponent<Rigidbody2D>().Sleep();

            foreach (GameObject obj in block) //���� ��� ������� ������� �� ��������, ����� ��� ������
            {
                obj.SetActive(true);
            }
        }
    }
}
