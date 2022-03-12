using UnityEngine;

public class PoliceOfficerCaught : MonoBehaviour
{
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
