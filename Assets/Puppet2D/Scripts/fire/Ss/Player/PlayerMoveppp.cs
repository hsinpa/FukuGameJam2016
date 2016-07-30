using UnityEngine;
using System.Collections;

public class PlayerMoveppp : MonoBehaviour
{
	public string num;
	public float hp;
	public GameObject deadeffect;

	public Transform m_CameraDir;	//攝影機角度

	public float m_RotaSpeed;
	public float m_MoveSpeed;
	public CharacterController m_CharCtrl;
	public Vector3 MoveDir;

	public bool fire;
	public GameObject buttel;
	public float cd = 2f;
	float tt = 0;
    void Start () 
	{
        
        
      


	}

	void Update()
	{
		if (fire == true&&Input.GetButtonDown("sAttack"+num)&&Time.time>tt) {
			Instantiate (buttel, transform.position, transform.rotation);
			tt = Time.time + cd;
		}
	}



	void LateUpdate() 
	{
        
		if(hp <=0){
			Instantiate (deadeffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}
           
           
			       
           // Ray();
		CharacterMove();
		CharacterRotation ();

          
        
        m_CharCtrl.Move (MoveDir * Time.deltaTime);
	}


    /*
    void Ray()
    {
        RaycastHit hit;
        Vector3 Linmon = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+1, gameObject.transform.position.z);
        if (Physics.Raycast(Linmon, -gameObject.transform.up, out hit, 500f,1023))
        {
            
            DS = Vector3.Distance(gameObject.transform.position, hit.point);
            H = hit.collider.tag;
        }

        if (DS> j_DonHi && JampSpeed > 0.1)
        {
            JampSpeed -= 0.05f;
        }
        if (DS <= j_DonHi && JampSpeed <= 1)
        {
            JampSpeed += 0.05f;
        }
    }

	*/

     
       
   


    //移動計算
    public void CharacterMove()
	{
			

     
		if (Input.GetAxis("sMoveX"+num) > 0.5 || Input.GetAxis("sMoveY"+num) > 0.5 || Input.GetAxis("sMoveX"+num) < -0.5 || Input.GetAxis("sMoveY"+num) < -0.5)
            {                //移動時以角色的正前方 * 移動速度為移動向量

               // MoveDir = transform.forward * m_MoveSpeed + new Vector3(0, -10, 0);


            }
        
        else
        {
            MoveDir.x = 0;
            MoveDir.z = 0;
        }
		
		

		
	}
    //旋轉計算
    public void CharacterRotation()
    {

     
            float yVelocity = 1F;
		/*
            if (Input.GetAxis("MoveX") < -0.5 & Input.GetAxis("MoveY") > 0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 45, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveX") > 0.5 & Input.GetAxis("MoveY") > 0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 45, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveX") < -0.5 & Input.GetAxis("MoveY") < -0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y - 135, ref yVelocity, m_RotaSpeed), 0);
            }
            else if (Input.GetAxis("MoveX") > 0.5 & Input.GetAxis("MoveY") < -0.5)
            {
                transform.eulerAngles = new Vector3(0, Mathf.SmoothDampAngle(transform.eulerAngles.y, m_CameraDir.eulerAngles.y + 135, ref yVelocity, m_RotaSpeed), 0);
            }
            else*/ 
		if (Input.GetAxis("sMoveY"+num) > 0.5)
            {
			
              // transform.eulerAngles = new Vector3(0 ,m_CameraDir.eulerAngles.y+0, 0);
				MoveDir = transform.forward * m_MoveSpeed + new Vector3(0, -10, 0);
            }
		else if (Input.GetAxis("sMoveX"+num) < -0.5)
            {
			
               // transform.eulerAngles = new Vector3(0, m_CameraDir.eulerAngles.y - 90, 0);
			MoveDir = transform.right * -m_MoveSpeed + new Vector3(0, -10, 0);

            }
		else if (Input.GetAxis("sMoveY"+num) < -0.5)
            {
			
             //   transform.eulerAngles = new Vector3(0,m_CameraDir.eulerAngles.y - 180, 0);
				MoveDir = transform.forward * -m_MoveSpeed + new Vector3(0, -10, 0);
            }
		else if (Input.GetAxis("sMoveX"+num) > 0.5)
            {
			MoveDir = transform.right * m_MoveSpeed + new Vector3(0, -10, 0);
			//transform.eulerAngles = new Vector3(0,m_CameraDir.eulerAngles.y +90, 0);
            }
        



    }

   
}
