using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    SerialPort sp = new SerialPort("COM4", 9600);
    public string receivedstring; 
    public GameObject test_data;

    public string[] datas;

    private void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1000;
    }

    private void Update()
    {
      if (sp.IsOpen)
      {
                if(sp.ReadByte()==3){
                    print(sp.ReadByte());
                    direction = Vector3.up * strength;
                }
                direction.y += gravity * Time.deltaTime;
                transform.position += direction * Time.deltaTime;
     }
     
     
     /*   receivedstring = data_stream.ReadLine();
        string[] datas = receivedstring;


        if(Input.GetKeyDown(KeyCode.Space)){
            direction = Vector3.up * strength;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; */
    }
}
