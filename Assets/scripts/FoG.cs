using FunkyCode;
using UnityEngine;

public class FoG : MonoBehaviour
{
    public bool FoGCheckBox = true;
    public LightCollider2D lightCollider2D;

    void Update()
    {
        if(FoGCheckBox)
        {
            lightCollider2D.shadowType = LightCollider2D.ShadowType.SpritePhysicsShape;
        }
        else
        {
            lightCollider2D.shadowType= LightCollider2D.ShadowType.None;
        }
    }
}
