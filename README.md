## 24/02:
  -	Giang:
    o	Build Game Android
      	https://youtu.be/Ska81xpB-Po
      	Kích thước màn hình Android
      	InputManager android
        •	Thêm nút di chuyển trên màn hình
        •	Tham khảo:
    o	Code InputManager: https://stackoverflow.com/questions/63219332/unity-define-ui-buttons-in-input-manager
    o	Standard Asset Library: https://youtu.be/RqomLumqwCk
    o	Input System: https://youtu.be/5tOOstXaIKE 
      	Sửa tên Game, Icon
  -	Hà:
    o	Level 3:
      	Code
      	Movement bơi (đợi xong Input Android đã)
  -	Kiên:
    o	Animation chuyển Scene
    o	Design nút cho Android
    o	Code chuyển Scene từ Level 1 sang Level 2:
      	Khi đi đến cuối Map: có biển chỉ dẫn: “nhảy xuống để sang Level 2”
      	khi nhảy xuống sẽ có 1 gameobject ẩn detect collision → trong đó thì code chuyển sang Scene 2


# Later
  -	Thêm nhạc nền cho game
    o	nhạc chơi
    o	nhạc game menu
    o	nhạc game over
  -	Code chuyển Level (sau khi đã có nhiều Level)
  -	Code Level 
    o	Level 2: Block ball game
    o	Level 3: Water
      	optional:
        •	trong map sẽ có thêm vật phẩm làm Double Jump
        •	khó nhận vật phẩm, tác dụng ở phần sau
  -	From Teacher: 
    o	Code trong Script thay vì để ở Start() thì nên để ở Awake() => đỡ lag, load các tài nguyên thì load hết 1 lượt ở lúc khởi chạy game luôn thay vì đang chơi thì nó load
  -	Thêm Sound cho Game:
    o	Sound lúc chết
    o	Sound lúc đá rơi
    o	Sound lúc nổ (bóng phá tường trong level 2 chẳng hạn)

  -	Khi ở Game Menu thì nhấn 1 tổ hợp phím nhất định để chuyển sang hack mode → có thêm:
    o	nút Go To Checkpoint
    o	Vô hạn mạng
  -	Build Game Android:
    o	[Optional]:
      	Auto chuyển sang màn hình ngang
