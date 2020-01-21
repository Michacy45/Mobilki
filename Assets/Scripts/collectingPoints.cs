using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class collectingPoints : MonoBehaviour
{
    public GameObject words;
    public PauseGame pauseGame;
    public GameObject logo;
    public GameObject letters;
    public static int count;
    public Image sg;
    public Image ag;
    public Image ig;
    public Image lg;
    public Image sy;
    public Image ay;
    public Image iy;
    public Image ly;
    public GameObject A;
    public GameObject S;
    public GameObject I;
    public GameObject L;
    public Text timeText;
    private float gameTime;
    private int iter;
    private float step;
    private int child;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        gameTime = 0;
        iter = 20;
        step = 1.0f / iter;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        timeText.text = "Your time: " + gameTime.ToString("0.00");
    }


    void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<AudioSource>().Play();
        if (other.gameObject.CompareTag("A"))
        {
            other.gameObject.SetActive(false);
            ag.gameObject.SetActive(false);
            ay.gameObject.SetActive(true);
            count += 1;
            child = Random.Range(0, 3);
            child = child % 3 + 3;
            iter = 0;
            A.SetActive(true);
            dbajOAKtywnoscSwojegoDziecka();
            ;
        }
        else if (other.gameObject.CompareTag("S"))
        {
            other.gameObject.SetActive(false);
            sg.gameObject.SetActive(false);
            sy.gameObject.SetActive(true);
            count += 1;
            child = Random.Range(0, 3);
            child = child % 3;
            iter = 0;
            S.SetActive(true);
            dbajOAKtywnoscSwojegoDziecka();
        }
        else if (other.gameObject.CompareTag("I"))
        {
            other.gameObject.SetActive(false);
            ig.gameObject.SetActive(false);
            iy.gameObject.SetActive(true);
            count += 1;
            child = Random.Range(0, 3);
            child = child % 3 + 6;
            iter = 0;
            I.SetActive(true);
            dbajOAKtywnoscSwojegoDziecka();
        }
        else if (other.gameObject.CompareTag("L"))
        {
            other.gameObject.SetActive(false);
            lg.gameObject.SetActive(false);
            ly.gameObject.SetActive(true);
            count += 1;
            child = Random.Range(0, 3);
            child = child % 3 + 9;
            iter = 0;
            L.SetActive(true);
            dbajOAKtywnoscSwojegoDziecka();

        }


    }
    void LateUpdate()
    {
        if (iter < 20)
        {
            words.transform.localScale += new Vector3(step, step, 0.0f);
            iter++;
            if(iter == 20)
            {
                StartCoroutine(animate());
            }
        }
    }

    void dbajOAKtywnoscSwojegoDziecka()
    {
        letters.SetActive(false);
        logo.SetActive(true);
        words.transform.GetChild(child).gameObject.SetActive(true);
    }

    private IEnumerator animate()
    {   
        if(count == 4)
        {
            Wind.speed = 0;
        }
        yield return new WaitForSeconds(1.0f);
        words.transform.GetChild(child).gameObject.SetActive(false);
        letters.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        logo.SetActive(false);
        words.transform.localScale = new Vector3(0, 0, 0);
        if (count == 4)
        {
            pauseGame.EndGame();

        }
    }

}
