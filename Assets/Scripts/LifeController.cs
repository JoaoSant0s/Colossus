using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {

    private Renderer[] renders;
    void Start () {
        renders = GetComponentsInChildren<Renderer>();
        UpdateTexture(0);
    }

    void Awake() {
        PlayerManager.OnDamageTexture += UpdateTexture;
    }

    void OnDestroy() {
        PlayerManager.OnDamageTexture -= UpdateTexture;
    }

    void UpdateTexture(int lifeDifference) {
        for (int i = 1; i < renders.Length; i++) {
            if(i <= lifeDifference) {                
                renders[i].enabled = true;
            }else {
                renders[i].enabled = false;
            } 
        }
    }
}
