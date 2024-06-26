using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    private float _timer;
    private ParticleSystem longparticleSystem;
    public bool _isParticlesActive = false;
    private Collider beamCol;

    void Start()
    {
        beamCol = GetComponent<BoxCollider>();
        longparticleSystem = GetComponent<ParticleSystem>();
        longparticleSystem.Stop();
        _timer = 0f;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 5f)
        {
            if (Input.GetButtonDown("Beam") && !_isParticlesActive)
            {
                _isParticlesActive = true;
                longparticleSystem.Play();

                RaycastHit hit;
                if (Physics.BoxCast(transform.position, Vector3.one * 0.5f, -transform.up, out hit, transform.rotation, 6.0f))
                {
                    // ビームが何かに衝突した場合の処理
                    Debug.Log("Hit object: " + hit.collider.gameObject.name);
                    ShowBeamImpact(hit.point);
                    // ここで何かしらの処理を行う（例えばダメージを与える、特定の効果を発生させるなど）
                }
                else
                {
                    // BoxCast が何にも衝突しなかった場合の処理
                    Debug.Log("No hit detected.");
                }

                beamCol.enabled = true;

                StartCoroutine(StopParticlesAfterDelay(7f));
            }
        }
    }

    IEnumerator StopParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (longparticleSystem != null)
        {
            beamCol.enabled = false;
            longparticleSystem.Stop();
            _isParticlesActive = false;
            _timer = 0f;
        }
    }

    void ShowBeamImpact(Vector3 position)
    {
        // 衝突点を示すエフェクトやラインを描画する処理をここに記述する
        // 例えば、パーティクルを再生する、ラインを引く、オブジェクトを生成するなどの方法があります。
        Debug.Log("DDAA");
        Debug.DrawRay(position, Vector3.forward * 10f, Color.red, 7.0f);
        // ここでその他のビジュアルエフェクトを追加することもできます。
    }
}



