using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public delegate void DamageTexture(int currenDamage);
    public static event DamageTexture OnDamageTexture;

    [SerializeField]
    private int hp = 4;

    private const int MAX_HP = 4;
    private const int MIN_HP = 0;

    public int HP {
        get { return hp; }

        set {
            hp += value;
            hp = Mathf.Min(MAX_HP, Mathf.Max(MIN_HP, hp));
        }
    }

    public void InflictDamage(int currenDamage) {
        HP = currenDamage;
        Debug.Log(HP);
        if (OnDamageTexture != null) OnDamageTexture(MAX_HP - hp);
    }

    void Update() {
        if (Input.GetButtonDown("Damage")) InflictDamage(-1);
        if (Input.GetButtonDown("Recover")) InflictDamage(1);
    }
}
