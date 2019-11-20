using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 baseDirection;
    public Vector3 windDirection;
    // Start is called before the first frame update
    void Start()
    {
        baseDirection = new Vector3(-1.0f, 0.0f, 0.0f);
        windDirection = new Vector3(-1.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction2 = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f) * baseDirection;
        //print(gameObject.transform.Find("Mast").eulerAngles);
        //print(Vector3.SignedAngle(windDirection, gameObject.transform.Find("Mast").eulerAngles,new Vector3(1,0,1)));
        //print(Vector3.Angle(windDirection, gameObject.transform.Find("Mast").eulerAngles));
        float ang = Mathf.Atan2(windDirection.x, windDirection.z) * Mathf.Rad2Deg;                  //kat wiatru od poczatku ukladu
        float ang2 = Mathf.Abs(ang - gameObject.transform.Find("Deck").rotation.eulerAngles.y);        //kat pomiedzy wiatrem a deckiem
        float ang3 = Mathf.Abs(ang - gameObject.transform.Find("Mast").rotation.eulerAngles.y);
        

        if (ang3 > 180)
        {
            ang3 = Mathf.Abs(360 - ang3);
        }

        if(ang2 > 180)
        {
            ang2 = Mathf.Abs(360 - ang2);
        }

        bool czyZWiatrem = false;

        if (ang2 <= 135)
        {
            czyZWiatrem = true;
        }
        /* print(ang);
         print(gameObject.transform.Find("Deck").rotation.eulerAngles.y);
         print(ang2);
         print(czyZWiatrem);*/
        // print(czyZWiatrem);
        //print(ang3);
        //print(Mathf.Abs(Mathf.Sin(ang3 * Mathf.Deg2Rad)));
        //ChangeWind();
        float windForce = 0.2f;

        if (czyZWiatrem)
        {
            windForce = Mathf.Max(Mathf.Sin(Mathf.Deg2Rad * ang3), 0.2f);
        }

        transform.position += direction2 * Time.deltaTime * speed * windForce;

        float rudderAngle = gameObject.transform.Find("Rudder").GetComponent<HingeJoint>().angle;
        transform.Rotate(0.0f, -rudderAngle * Time.deltaTime * windForce * 0.5f, 0.0f);

        float arrowAngle = GameObject.Find("Arrow").transform.eulerAngles.z;
        float cameraAngle = GameObject.Find("Main Camera").transform.eulerAngles.y;

        float arrowRot = ang - arrowAngle + cameraAngle - 90;
        GameObject.Find("Arrow").transform.Rotate(0.0f, 0.0f, arrowRot);


    }

    /*private void ChangeWind()
    {
        windDirection.x -= ChangeWindCoordinate(wind.x);
        windDirection.z -= ChangeWindCoordinate(wind.z);
    }

    private float ChangeWindCoordinate(float coordinate)
    {
        if (Mathf.Abs(coordinate) > 2.0f)
        {
            return Random.Range(0.0f, 1.0f / Mathf.Pow(coordinate, 3.0f));
        }
        else
        {
            return Random.Range(-0.1f, 0.1f);
        }
    }*/

}
