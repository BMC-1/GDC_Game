using UnityEngine;

public class PoliceOfficerCaught : MonoBehaviour
{
   /// <summary>
   /// This script is following by a sphere collider on the second game object of the pollice officer,
   /// Sphere collider must always be on Trigger = true;
   /// When this collider enters the mainCharacter collider the policePanel on Canvas is opening.
   /// </summary>
   [Header("Police Panel")] 
   public GameObject policePanel;

   private void OnTriggerEnter(Collider other)
   {
      CaughtByPolice();
   }
   private void CaughtByPolice()
   {
      //FINISH THE SCENE
      Debug.Log("You get Caught");
      policePanel.SetActive(true);
      StaticHelper.freezePlayer = true;
   }
}
