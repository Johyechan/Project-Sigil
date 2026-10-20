using UnityEngine;

namespace Lobby.UI.Button.Sigil
{
    // 작성자: 조혜찬
    // 문양 버튼 부모 클래스
    public class SigilButtonBase : MonoBehaviour
    {
        [SerializeField] protected Transform sigilListPanel; // 문양 이미지들을 자식으로 담을 객체

        // 클릭했을 때 실행될 함수
        public virtual void OnClick()
        {

        }
    }
}
// 마지막 작성 일자: 2026.10.16