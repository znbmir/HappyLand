using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tools
{
    public class MultyTouch : MonoBehaviour
    {
      public bool IsInEditor;
      private Ray _tileDetectRay;
      private RaycastHit _tileHit;

      public float cubeSize = 0.2f;
      public int cubesInRow = 5;
      float cubesPivotDistance;
      Vector3 cubesPivot;
      public float explosionForce = 50f;
      public float explosionRadius = 4f;
      public float explosionUpward = 0.4f;
      public AudioSource theBeepMusic;
      public SpawnNote theSpawnNote;

      float _timePressed = 0;
      float _timeLastPress = 0;
      public float WaitingSeconds = 1;

      public float waitTime;




        private void Update()
        {
            if (IsInEditor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                  TouchPlayer.isTouchPlayer = false;
                  TouchPlayerLH.isTouchPlayerLH = false;

                    _tileDetectRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    Debug.DrawRay(_tileDetectRay.origin , _tileDetectRay.direction * 1000 , Color.green);
                    if (Physics.Raycast(_tileDetectRay, out _tileHit, 1000))
                    {
                      if (_tileHit.collider.tag == "Player")
                      {
                        TouchPlayer.isTouchPlayer = true;
                      }

                        else if (_tileHit.collider.tag == "PlayerLH"){
                          TouchPlayerLH.isTouchPlayerLH = true;
                      }

                    }
                    if(!TouchPlayer.isTouchPlayer && !TouchPlayerLH.isTouchPlayerLH && theSpawnNote.hasStarted == true){
                      theBeepMusic.Play();
                      Debug.Log("Player not Detected **************************");
                    }
                }

                if(Input.GetMouseButtonUp(0))
                {
                  TouchPlayer.isTouchPlayer = false;
                  TouchPlayerLH.isTouchPlayerLH = false;
                }
            }

            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount ; i++)
                {
                    var touch = Input.GetTouch(i);
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                      _timePressed = Time.time - _timeLastPress;
                      TouchPlayer.isTouchPlayer = false;
                      TouchPlayerLH.isTouchPlayerLH = false;

                      _tileDetectRay = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                      Debug.DrawRay(_tileDetectRay.origin , _tileDetectRay.direction * 1000 , Color.green);
                      if (Physics.Raycast(_tileDetectRay, out _tileHit, 1000))
                        {
                          if (_tileHit.collider.tag == "Player")
                          {
                            TouchPlayer.isTouchPlayer = true;
                          }

                              else if (_tileHit.collider.tag == "PlayerLH")
                              {
                                TouchPlayerLH.isTouchPlayerLH = true;
                              }

                        }
                        if(!TouchPlayer.isTouchPlayer && !TouchPlayerLH.isTouchPlayerLH && theSpawnNote.hasStarted == true){
                          theBeepMusic.Play();
                          Debug.Log("Player not Detected **************************");
                        }
                    }

                    if (Input.touches[0].phase == TouchPhase.Ended)
                    {
                      TouchPlayer.isTouchPlayer = false;
                      TouchPlayerLH.isTouchPlayerLH = false;
                    }

                }
            }
        }



  /*      bool CheckForLongPress()
        {
          if (Input.touches[0].phase == TouchPhase.Began) { // If the user puts her finger on screen...
            _timePressed = Time.time - _timeLastPress;
          }

          if (Input.touches[0].phase == TouchPhase.Ended) { // If the user raises her finger from screen
            _timeLastPress = Time.time;
            if (_timePressed > WaitingSeconds/2f) { // Is the time pressed greater than our time delay threshold?
              return true;
            }
          }
          return false;
        }*/



        public void explode(GameObject gameObjectHit)
        {
            //make object disappear
            gameObjectHit.SetActive(false);

            //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
            for (int x = 0; x < cubesInRow; x++)
            {
                for (int y = 0; y < cubesInRow; y++)
                {
                    for (int z = 0; z < cubesInRow; z++)
                    {
                        createPiece(x, y, z);
                    }
                }
            }

            //get explosion position
            Vector3 explosionPos = transform.position;
            //get colliders in that position and radius
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            //add explosion force to all colliders in that overlap sphere
            foreach (Collider hit in colliders)
            {
                //get rigidbody from collider object
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    //add explosion force to this body with given parameters
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
                }
            }

        }

        void createPiece(int x, int y, int z)
        {

            //create piece
            GameObject piece;
            piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

            //set piece position and scale
            piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
            piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

            //add rigidbody and set mass
            piece.AddComponent<Rigidbody>();
            piece.GetComponent<Rigidbody>().mass = cubeSize;
        }
    }
}
