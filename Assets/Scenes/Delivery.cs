using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

[SerializeField] Color32 hasPackageColor = new Color32 (82, 198, 24, 255);
[SerializeField] Color32 noPackageColor = new Color32 (117, 0, 0, 255);
[SerializeField] float destroyDelay = 0.5f;
  bool hasPackage = false;

  SpriteRenderer spriteRenderer;

  void Start()
  {
    Debug.Log(hasPackage);
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void OnCollisionEnter2D(Collision2D other) 
  {
    Debug.Log("Çarptın LOOOOOO!");
  }
  
  void OnTriggerEnter2D(Collider2D other) 
  {
    if (other.tag == "Package" && !hasPackage)
    {
      Debug.Log("Package picked up!");
      hasPackage = true;
      Destroy(other.gameObject, destroyDelay);
      spriteRenderer.color = hasPackageColor;
    }
    else if(other.tag == "Customer" && hasPackage)
    {
      Debug.Log("Package was delivered");
      hasPackage = false;
      spriteRenderer.color = noPackageColor;
    }
  }
}
