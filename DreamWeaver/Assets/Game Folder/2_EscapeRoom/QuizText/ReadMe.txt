폴더 구성>
1. QuizText폴더
- 1. Prefabs (2개)
: QuizManager, QuizUI
- 2. Scripts (5+3개)
: 실제로 사용되는 5가지 스크립트(Room_~~) + 안쓰는 임시 스크립트 3개(R_Quiz_~~)

2. Common폴더 (1개)
: Singleton 템플릿 스크립트 있음
※ 이미 Singleton 스크립트가 있으면 받을 필요없음



사용 방법>
1. Player에 Room_PlayerQuizRaycasting 스크립트를 추가한다. 그리고 Raycast 거리 변수를 설정한다.

2. Canvas(UI)에 QuizUI 프리팹을 추가한다.

3. QuizManager 프리팹을 추가한다.

4. QuizManager의 컴포넌트중 비어있는 'Quiz UI'와 'Player Raycasting' 부분을 채워준다. 참고로 후자는 Player 오브젝트 자체를 넣어주면 된다.

5. Quiz UI에서 자식 오브젝트중 'QuizButton' 오브젝트를 선택한다. 거기서 on Click() 이벤트를 한개 추가한다.
QuizManager오브젝트의 Room_QuizManager스크립트의 SetRaycasting메서드를 추가해주면 된다.

6. 퀴즈를 만들고 싶은 오브젝트에 'Room_QuizObject' 스크립트를 추가한다.

단, 여기서 해당 오브젝트는 반드시 콜라이더가 존재해야만 한다 (레이캐스팅)

7. 스크립트 컴포넌트에서 'Quiz Dialog'를 클릭해서 원하는 텍스트만큼 추가해준다. 참고로 너무 긴 문장이면 화면에 보기 안좋게 나올수도 있으니, 적당한 문자열로 나눠 기록한다.

8. 퀴즈로 만들었던 오브젝트의 Layer 설정에서 'Quiz'부분을 설정해준다. 만약 안만들어져 있으면, 새로운 (User) Layer를 추가해준다. 9번만 아니면 상관없다. 단, 이름의 대소문자 철자는 틀려서는 안된다. (레이캐스팅의 LayerMask)

9. 게임을 실행해서 문제없이 작동하는지 확인한다.