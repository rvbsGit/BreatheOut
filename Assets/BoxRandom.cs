using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRandom : MonoBehaviour
{
    public float maxTime; //Tiden der g�r f�r en ny kasse kommer. Dette tal s�ttes inde i Unity
    private float timer = 0; //T�lleren indtil n�ste kasse bliver lavet
    public float height; //H�jden hvor i kasser kan blive lavet i. Dette tal s�ttes inde i Unity

    public List<GameObject> gameObjectsPool; //Listen af kasser, her s�tter der inde i Unity objektet BadBox og GoodBox ind
    public GameObject baaad; // Et almindeligt dumt gameObjekt, s� vi kun sender d�rlige bokse ud n�r player-manden har fuldt liv

    public void gameObjectsBad()
    {
        Vector2 pos; // G�r det muligt for os at s�tte bokses position
        pos = new Vector2(15, Random.Range(-height, height)); //S�tter h�jden for kassen
        Instantiate(baaad, pos, baaad.transform.rotation); //Oprettelse af boksen  
    }

    public void gameObjects()
    {
        int randomItem = 0; // Et eller andet random tal
        GameObject toRandom; // Lavet en lille fake gameObject
        Vector2 pos; // Dens position

        randomItem = Random.Range(0, gameObjectsPool.Count); //Tager et tal fra listen, her bliver det random tal sat ind i randomItem 
        toRandom = gameObjectsPool[randomItem]; //Inds�tter tallet fra randomItem til et gameObject
        pos = new Vector2(15, Random.Range(-height, height)); //S�tter h�jden for boksen

        Instantiate(toRandom, pos, toRandom.transform.rotation); //Laver s� boksen, ud fra h�jden, og det fake gameObject, som nu bliver til et "rigtigt" ud fra det random tal vi fandt.
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime) //Tjekker om tiden er g�et over, hvor lang tid, der m� g� f�r der m� komme en ny kasse
        {
            if(Player.lives == 3) // Hvis player-mandens liv er lig med 3
            {
                Debug.Log("Solo baaaaad boxes :(");
                gameObjectsBad(); // S� kalder vi metoden, der kun laver d�rlige og dumme bokse
                timer = 0; //S�tter tiden til nul, s� vi ved hvorn�r vi skal lave en ny kasse
            }
            else // Hvis player-manden har alt andet end 3 liv,
            {
                Debug.Log("Random boxes!");
                gameObjects(); // S� kalder vi metoden, der laver alle mulige bokse
                timer = 0; //S�tter tiden til nul, s� vi ved hvorn�r vi skal lave en nu kasse
            }
        }
        timer += Time.deltaTime; //Opt�ller tiden til ny kasse
    }
}

