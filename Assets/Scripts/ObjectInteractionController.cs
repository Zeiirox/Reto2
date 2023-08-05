using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractionController : MonoBehaviour
{
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private GameObject[] childObject;

    [SerializeField] private bool enableInteraction = true;

    private SpriteRenderer spriteRenderer = null;
    private GameObject obj;

    public static int numberOfObjects;

    private void Start()
    {
        numberOfObjects = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && enableInteraction)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (spriteRenderer.enabled)
                {
                    spriteRenderer.enabled = false;
                    if (childObject.Length > 0)
                    {
                        foreach (GameObject item in childObject)
                        {
                            SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
                            if (sr)
                            {
                                sr.enabled = false;
                            }
                            else
                            {
                                item.SetActive(false);
                            }
                        }
                    }
                    if (prefab != null)
                    {
                        obj = Instantiate(prefab, transform.position, transform.rotation);
                        obj.transform.SetParent(gameObject.transform);
                    }
                    numberOfObjects++;
                }
            }
        }
    }

}
