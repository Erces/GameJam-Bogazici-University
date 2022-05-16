using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPointController : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 2f;
    [SerializeField] Image fillImage;
    float enterTime;

    [SerializeField] GameObject[] objectsToEnable;
    [SerializeField] GameObject[] objectsToDisable;
    [SerializeField] int pointValue;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Human"))
            enterTime = Time.time;
        //    Destroy(gameObject);
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Human"))
        {
            float timePassed = Time.time - enterTime;
            fillImage.fillAmount = timePassed / startingTime;
            if (timePassed / startingTime >= 1f)
            {
                CompletePoint(collider.gameObject.GetComponent<HumanController>());
            }
        }
        //currentTime = startingTime;

        //if (collider.gameObject.tag == "Player")
        //{
        //    do
        //    {
        //        currentTime -= 1 * Time.deltaTime;
        //    } while (currentTime > 0);

        //    Funcc();

        //}
    }

    private void OnTriggerExit(Collider other)
    {
        fillImage.fillAmount = 0;
    }

    void CompletePoint(HumanController human)
    {
        if (objectsToEnable.Length > 0)
        {
            foreach(GameObject obj in objectsToEnable)
            {
                obj.SetActive(true);
            }
        }
        if (objectsToDisable.Length > 0)
        {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }

        human.AddPoint(pointValue);
        gameObject.SetActive(false);
    }

    private void Funcc()
    {
        print("Function called");
    }

}
