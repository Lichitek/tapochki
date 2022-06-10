using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;									
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	
	[SerializeField] private bool m_AirControl = false;							
	[SerializeField] private LayerMask m_WhatIsGround;							
	[SerializeField] private Transform m_GroundCheck;																	
	const float k_GroundedRadius = .2f; 
	private bool m_Grounded;            
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }


	int coins = 0;

	public Image coinCounter;
	public Image coinCounterTens;
	public Sprite[] numbers = new Sprite[10];



	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}


    private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;
		dataBank.nameLv = SceneManager.GetActiveScene().name;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

    public void Update()
    {
		switch (coins % 10)
		{
			case 0: coinCounter.sprite = numbers[0]; break;
			case 1: coinCounter.sprite = numbers[1]; break;
			case 2: coinCounter.sprite = numbers[2]; break;
			case 3: coinCounter.sprite = numbers[3]; break;
			case 4: coinCounter.sprite = numbers[4]; break;
			case 5: coinCounter.sprite = numbers[5]; break;
			case 6: coinCounter.sprite = numbers[6]; break;
			case 7: coinCounter.sprite = numbers[7]; break;
			case 8: coinCounter.sprite = numbers[8]; break;
			case 9: coinCounter.sprite = numbers[9]; break;
		}

		switch (coins / 10)
		{
			case 0: coinCounterTens.enabled = false; break;
			case 1: { coinCounterTens.enabled = true; coinCounterTens.sprite = numbers[1]; break; }
			case 2: coinCounterTens.sprite = numbers[2]; break;
			case 3: coinCounterTens.sprite = numbers[3]; break;
			case 4: coinCounterTens.sprite = numbers[4]; break;
			case 5: coinCounterTens.sprite = numbers[5]; break;
			case 6: coinCounterTens.sprite = numbers[6]; break;
			case 7: coinCounterTens.sprite = numbers[7]; break;
			case 8: coinCounterTens.sprite = numbers[8]; break;
			case 9: coinCounterTens.sprite = numbers[9]; break;
		}
	}

    public void Move(float move, bool jump)
	{
		if (m_Grounded || m_AirControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		}
		if (m_Grounded && jump)
		{
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	private void Flip()
	{
		m_FacingRight = !m_FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        if (collision.gameObject.tag == "Coin") 
        {
            coins++; //(ведем счет монет)
            Destroy(collision.gameObject); //удалили ключ
			int i = dataBank.idLv - 1;
			dataBank.score[i] = coins;
			
            print("Количество монет: " + coins); //добавили монету в карман (счетчик на экране)
        }

		if (collision.gameObject.tag == "Enemy") //если столкнулись с ключем
		{
			coins = 0;
			Time.timeScale = 0f;
			dataBank.isgame = false;

		}
		if (collision.gameObject.tag == "end") //если столкнулись с ключем
		{
			
			for(int i=0; i<5; i++)
            {
				coins += dataBank.score[i];
            }

		}


	}
}
