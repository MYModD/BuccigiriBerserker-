using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    private float _timer;
    private ParticleSystem longparticleSystem;
    private bool _isParticlesActive = false;
    private Collider beamCol;
    [SerializeField]
    float distance = 10f;
    void Start()
    {
        beamCol = GetComponent<BoxCollider>();
        longparticleSystem = GetComponent<ParticleSystem>();
        longparticleSystem.Stop();
        _timer = 0f;
    }

    void Update()
    {

        if (Input.GetButtonDown("Beam"))
        {
            _isParticlesActive = true;
            longparticleSystem.Play();
            if (_isParticlesActive == true)
            {
                Vector3 origin = transform.position; // Boxcastの始点（この例ではオブジェクト自身の位置）
                Vector3 direction = transform.forward; // Boxcastの方向（この例ではオブジェクトの正面方向）
                float distance = 250f; // Boxcastの距離

                Vector3 size = new Vector3(12f, 12f, 1f); // Boxcastのサイズ（この例では幅1、高さ1、奥行き1のBox）
                Quaternion orientation = Quaternion.identity; // Boxcastの向き（この例では回転なし）

                RaycastHit hitInfo; // 衝突情報を受け取るための変数

                // Boxcastを実行して衝突判定を行う
                bool hit = Physics.BoxCast(origin, size, direction, out hitInfo, orientation, distance);

                if (hit)
                {
                    Debug.Log("Boxcast hit object: " + hitInfo.collider.gameObject.name);

                }
                else
                {
                    Debug.Log("Boxcast did not hit anything.");
                    // 衝突しなかった場合の処理を記述する
                }

                Invoke(nameof(Delay), 4f);
            }




        }

    }
    IEnumerator Delay()
    {

       
        
           
            longparticleSystem.Stop();
            _isParticlesActive = false;
            _timer = 0f;
        

        yield return new WaitForSeconds(3f);
    }

}







