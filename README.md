# STRIKERS1945
 STRIKERS1945 모작


※ 새로 배운 것


CompareTag
 - 동적할당 없이 tag 비교가 가능하도록 구현된 메소드
 - 인자로 전달받은 string 이 실제로 존재하는지까지 확인하기 때문에 안정적
 - 예시로 [ gameOBject.tag == "tag" ] 사용 시 getter로 호출하고, string 을 복사 생성하기에 비효율적

Physic Material 2D
[ Friction ]
 - 마찰 : 0과 1사이 > 0이면 미끄러지고 1이면 움직이기 어려워짐

[ Bounciness ]
 - 탄성 : 0과 1사이 > 0이면 바운스하지 않고 1이면 에너지 손실 없이 바운스
